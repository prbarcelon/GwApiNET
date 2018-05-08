using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;

namespace GwApiNETExample.Managers
{

    public class ItemManager : ApiManagerBase
    {
        private static ItemManager _instance;
        public static EntryDictionary<int, ItemDetailsEntry> Items { get; set; }
        public static ItemManager Instance
        {
            get { return _instance ?? (_instance = new ItemManager()); }
        }

        private ItemManager()
        {
            _worker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
            };
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            Items = new EntryDictionary<int, ItemDetailsEntry>();
            ItemIds = new IdList();
        }
        public IdList ItemIds { get; private set; }
        //public EntryDictionary<int, ItemDetailsEntry> Items { get; set; }
        
        public async Task<ItemDetailsEntry> GetItem(int id, bool ignoreCache = false)
        {
            if (ignoreCache || Items.ContainsKey(id) == false)
            {
                await DownloadItemDetails(id, ignoreCache);
            }
            return Items.ContainsKey(id) ? Items[id] : null;
        }

        private static async Task<ItemDetailsEntry> DownloadItemDetails(int id, bool ignoreCache = false)
        {
            var item = await Task.Run(
                () => GwApi.GetItemDetails(id, ignoreCache));
            Items[id] = item;
            return item;
        }

        #region Events/Handling

        public delegate void IdListUpdatedEvent(IdList itemIds);

        public delegate void ItemsUpdatedEvent(IDictionary<int, ItemDetailsEntry> items);

        public delegate void DownloadProgressUpdatedEvent(int progressPercent);

        public event IdListUpdatedEvent IdListUpdated;

        private void OnIdListUpdated(IdList itemids)
        {
            IdListUpdatedEvent handler = IdListUpdated;
            if (handler != null) handler(itemids);
        }

        public event ItemsUpdatedEvent ItemsUpdated;

        private void OnItemsUpdated(IDictionary<int, ItemDetailsEntry> items)
        {
            ItemsUpdatedEvent handler = ItemsUpdated;
            if (handler != null) handler(items);
        }

        public event DownloadProgressUpdatedEvent DownloadProgressUpdated;

        private void OnDownloadProgressUpdated(int progresspercent)
        {
            DownloadProgressUpdatedEvent handler = DownloadProgressUpdated;
            if (handler != null) handler(progresspercent);
        }

        #endregion Events/Handling

        static ItemManager()
        {
        }

        #region Items Downloading

        private readonly object _downloadLock = new object();
        public int DownloadProgress { get; private set; }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DownloadProgress = 100;
            //Items.AddRange(e.Result as IDictionary<int, ItemDetailsEntry>);
            // Lets save the items as a full set.  This will make retrieving in the future MUCH faster.
            // Lets save the response cache now just incase.
            // Don't want to download all those again if not needed
            ResponseCache.Cache.Add("ItemsDictionary", e.Result as EntryDictionary<int, ItemDetailsEntry>);
            ResponseCache.Cache.Save();
            OnItemsUpdated(e.Result as EntryDictionary<int, ItemDetailsEntry>);
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (DownloadProgress == e.ProgressPercentage) return;
            DownloadProgress = e.ProgressPercentage;
            OnDownloadProgressUpdated(DownloadProgress);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var idList = e.Argument as IList<int>;
            var items = Items ?? new EntryDictionary<int, ItemDetailsEntry>();
            e.Result = items;
            lock (_downloadLock)
            {
                e.Result = items;
                DownloadTotal = idList.Count;
                for (int i = 0; i < idList.Count; i++)
                {
                    var item = GwApi.GetItemDetails(idList[i]);
                    try
                    {
                        items.Add(item.ItemId, item);
                    }
                    catch (Exception)
                    {
                    }
                    DownloadCount = i;
                    DownloadProgress = (int)(100 * ((double)i / idList.Count));
                    //_worker.ReportProgress((int) (100*((double) i/idList.Count)));
                    if (e.Cancel) return;
                }
            }
        }
        /// <summary>
        /// Total items to retrieve
        /// </summary>
        public int DownloadTotal { get; set; }
        /// <summary>
        /// total items retrieved
        /// </summary>
        public int DownloadCount { get; set; }

        private readonly BackgroundWorker _worker;

        /// <summary>
        /// Downloading missing items
        /// </summary>
        /// <param name="itemIdList">List of item ids to download.  This will be offset by the knownItems list.</param>
        /// <param name="knownItems">list of known ItemDetailsEntry values.  This list will augement the itemIdList.</param>
        public void DownloadMissingItems(IdList itemIdList, IDictionary<int, ItemDetailsEntry> knownItems)
        {
            ThreadPool.QueueUserWorkItem(_downloadItems, new Tuple<IdList, IDictionary<int, ItemDetailsEntry>>(itemIdList, knownItems));
        }

        // gets a list of unknown items, and starts the downloader to retrieve the missing items.
        private void _downloadItems(object tuple)
        {
            lock (_downloadLock)
            {
                DownloadProgress = 0;
                DownloadTotal = 0;
                DownloadCount = 0;
                var tup = tuple as Tuple<IdList, IDictionary<int, ItemDetailsEntry>>;
                IdList itemIdList = tup.Item1;
                IDictionary<int, ItemDetailsEntry> knownItems = tup.Item2;
                // If there are no new items to get just return
                int cap = itemIdList.Count - knownItems.Values.Count > 0
                              ? itemIdList.Count - knownItems.Values.Count
                              : 0;
                IList<int> unknownItems = new List<int>(cap);
                if (cap <= 0) return;
                else if (cap != itemIdList.Count)
                {
                    // Our unknown item ids and our sorted list (sorted list for efficiency
                    var sortedItems = new SortedList<int, ItemDetailsEntry>(knownItems);
                    // now we make our list of known item ids.
                    foreach (var id in itemIdList)
                    {
                        if (sortedItems.ContainsKey(id) == false)
                        {
                            unknownItems.Add(id);
                        }
                    }
                }
                else unknownItems = itemIdList;

                // now lets download the items we don't already have
                // We'll use a backgroundworker to provide progress updates
                _worker.RunWorkerAsync(unknownItems);
            }
        }
        #endregion Items Downloading


        #region Item Ids

        public void RefreshItemIds(bool ignoreCache = true)
        {
            ThreadPool.QueueUserWorkItem(_getItemIds);
        }
        private void _getItemIds(object none)
        {
            ItemIds = GwApi.GetItemIds();
            OnIdListUpdated(ItemIds);
        }

        #endregion Item Ids
    }
}
