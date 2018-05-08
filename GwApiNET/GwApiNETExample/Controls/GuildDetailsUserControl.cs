using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET;
using GwApiNET.ResponseObjects;
using RestSharp;

namespace GwApiNETExample.Controls
{
    public partial class GuildDetailsUserControl : UserControlBase
    {
        public GuildDetailsUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Status = "Searching";
                if (listView1.Items.ContainsKey(GuildNameSearch) == false)
                {
                    var guildDetails = GwApi.GetGuildDetailsByName(GuildNameSearch);
                    _addToListView(guildDetails);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("Error adding guild '{0}'\n{1}", GuildNameSearch, exception.Message), "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Status = "Done";
        }

        public string GuildNameSearch
        {
            get { return textBoxGuildName.Text; }
            set { textBoxGuildName.Text = value; }
        }

        void _addToListView(GuildDetailsEntry entry)
        {
            if (entry != null)
            {
                string[] data = new[] {entry.GuildName, entry.Tag, entry.GuildId.ToString()};
                var item = new ListViewItem(data){Name = entry.GuildName};
                listView1.Items.Add(item);
            }
        }

    }
}
