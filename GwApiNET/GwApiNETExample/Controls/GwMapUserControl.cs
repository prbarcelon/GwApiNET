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
    public partial class GwMapUserControl : UserControlBase
    {
        public GwMapUserControl()
        {
            InitializeComponent();
        }

        private void GwMapUserControl_Load(object sender, EventArgs e)
        {
            map = new GwMapControl();
            panel1.Controls.Add(map);
            map.ShowTileGridLines = checkBoxShowGridLines.Checked;
        }

        private GwMapControl map;

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            map.ShowTileGridLines = checkBoxShowGridLines.Checked;
        }

        public override string Status
        {
            get { return map.Status; }
            protected set
            {
                base.Status = value;
            }
        }
    }
}
