using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNETExample.Controls;

namespace GwApiNETExample.Managers
{

    public class ApiManagerBase : IUpdateStatus
    {
        public virtual string Description { get; protected set; }
        public void Save()
        {
            ThreadPool.QueueUserWorkItem(_saveCache);
        }

        private void _saveCache(object none)
        {
            lock (ResponseCache.Cache)
            {
                ResponseCache.Cache.Save();
            }
        }

        private string _status = "Done";
        public event StatusChangeEvent StatusChanged;

        public virtual string Status
        {
            get { return _status; }
            protected set
            {
                if (UpdateStatusHelper.CheckStatusChanged(_status, value))
                {
                    _status = value;
                    OnStatusChanged(_status);
                }
            }
        }

        protected virtual void OnStatusChanged(string status)
        {
            StatusChangeEvent handler = StatusChanged;
            if (handler != null) handler(status);
        }

    }
}
