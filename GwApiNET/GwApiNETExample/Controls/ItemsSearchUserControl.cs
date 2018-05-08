using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using GwApiNET.ResponseObjects.Parsers;
using GwApiNETExample.Managers;
using RestSharp;
using Timer = System.Windows.Forms.Timer;

namespace GwApiNETExample.Controls
{
    public partial class ItemsSearchUserControl : UserControlBase
    {
        static ItemsSearchUserControl()
        {
            Constants.CacheStrategies[typeof(ItemDetailsEntry).ToString()] = NullCacheStrategy.NullStrategy;
        }
        public ComboBox ComboBoxIds
        {
            get { return comboBoxItemIds; }
        }

        private Stopwatch stopwatch = new Stopwatch();
     
        public ItemsSearchUserControl()
        {
            InitializeComponent();
            _init();
        }

        private void _init()
        {
            this.Dock = DockStyle.Fill;
            ItemManager.Instance.DownloadProgressUpdated += ItemManager_DownloadProgressUpdated;
            ItemManager.Instance.ItemsUpdated += ItemManager_ItemsUpdated;
            ItemManager.Instance.IdListUpdated += ItemManager_IdListUpdated;
            _updateTimer.Tick += _updateTimer_Tick;
        }

        private void _initAsync(object none)
        {
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;
            File.WriteAllLines("Keys.txt", ResponseCache.Cache.gethashes());
            if (items != null) ItemManager.Items.AddRange(items);
        }

        private Timer _updateTimer = new System.Windows.Forms.Timer()
            {
                Interval = 1000,
            };


        #region GUI Events

        private void _updateTimer_Tick(object sender, EventArgs e)
        {
            if (progressBarItemDownload.Value < 100)
            {
                progressBarItemDownload.Value = ItemManager.Instance.DownloadProgress;
                labelPercent.Text = progressBarItemDownload.Value + "%";
                labelSeconds.Text = stopwatch.Elapsed.TotalSeconds.ToString("0.00") + "s";
                labelItemCount.Text = ItemManager.Instance.DownloadCount + "/" + ItemManager.Instance.DownloadTotal;
            }
            else
            {
                progressBarItemDownload.Visible = false;
                labelPercent.Visible = false;
                labelSeconds.Visible = false;
                labelItemCount.Visible = false;
                _updateTimer.Stop();
            }
        }

        void ItemManager_IdListUpdated(IdList itemIds)
        {
            _updateControl(() => comboBoxItemIds.DataSource = itemIds.ToArray());
        }

        void ItemManager_ItemsUpdated(IDictionary<int, ItemDetailsEntry> items)
        {
            stopwatch.Stop();
            MessageBox.Show("Done Downloading after " + stopwatch.Elapsed.TotalSeconds + " Seconds");
            _updateControl(() =>
            {
                progressBarItemDownload.Visible = false;
                labelPercent.Visible = false;
                labelSeconds.Visible = false;
                labelItemCount.Visible = false;
            });
        }

        void ItemManager_DownloadProgressUpdated(int progressPercent)
        {
            _updateControl(() => progressBarItemDownload.Value = progressPercent);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRefreshIds_Click(object sender, EventArgs e)
        {
            ItemManager.Instance.RefreshItemIds();
        }

        private void buttonDownloadItems_Click(object sender, EventArgs e)
        {
            progressBarItemDownload.Visible = true;
            labelSeconds.Visible = true;
            labelPercent.Visible = true;
            labelItemCount.Visible = true;
            _updateTimer.Start();
            stopwatch.Restart();
            ItemManager.Instance.DownloadMissingItems(ItemManager.Instance.ItemIds, ItemManager.Items);
        }

        private void comboBoxItemIds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion GUI Events

        private void _updateControl(Action a)
        {
            Invoke(a);
        }
        public override string Status
        {
            get { return ItemManager.Instance.Status; }
            protected set
            {
                base.Status = value;
            }
        }
        private void ItemsSearchUserControl_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_initAsync);
        }
    }

}
