using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwApiNETExample.Controls
{
    public partial class UserControlBase : UserControl, IUpdateStatus
    {
        public UserControlBase()
        {
            InitializeComponent();
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

        public virtual string Description { get; protected set; }


        protected virtual void OnStatusChanged(string status)
        {
            StatusChangeEvent handler = StatusChanged;
            if (handler != null) handler(status);
        }

    }
}
