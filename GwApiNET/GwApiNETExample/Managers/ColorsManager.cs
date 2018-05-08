using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using GwApiNETExample.Controls;

namespace GwApiNETExample.Managers
{
    public class ColorsManager : ApiManagerBase
    {
        private static ColorsManager _instance = null;

        public static ColorsManager Instance
        {
            get { return _instance ?? (_instance = new ColorsManager()); }
        }

        static ColorsManager()
        {
            Constants.CacheStrategies[typeof (EntryDictionary<int, ColorEntry>).Name] = NullCacheStrategy.NullStrategy;
        }
        private ColorsManager()
        {
            Colors = new EntryDictionary<int, ColorEntry>();
        }
        public event Updated<IDictionary<int, ColorEntry>> ColorsUpdated;

        private void OnColorsUpdated(IDictionary<int, ColorEntry> colors)
        {
            Updated<IDictionary<int, ColorEntry>> handler = ColorsUpdated;
            if (handler != null) handler(colors);
        }

        public EntryDictionary<int, ColorEntry> Colors { get; private set; } 

        public void Refresh(bool forceUpdate = false)
        {
            EntryDictionary<int, ColorEntry> colors = null;
            lock (Colors)
            {
                Status = "Updating";
                colors = GwApi.GetColors(forceUpdate);
                Status = "Done";
                Colors = colors;
            }
            OnColorsUpdated(colors);
        }

        private string _status = "Done";
        public override string Status
        {
            get
            {
                return _status;
            }
            protected set
            {
                if (UpdateStatusHelper.CheckStatusChanged(_status, value))
                {
                    _status = value;
                    OnStatusChanged(_status);
                }
            }
        }
    }
}
