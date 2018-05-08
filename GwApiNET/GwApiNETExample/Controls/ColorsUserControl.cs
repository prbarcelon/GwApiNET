using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET.ResponseObjects;
using GwApiNETExample.Forms;
using GwApiNETExample.Managers;

namespace GwApiNETExample.Controls
{
    public partial class ColorsUserControl : UserControlBase
    {
        public ColorsUserControl()
        {
            InitializeComponent();
        }

        void Instance_ColorsUpdated(IDictionary<int, ColorEntry> colors)
        {
            ThreadPool.QueueUserWorkItem(_loadColors, colors);
        }

        void _loadColors(object obj)
        {
            lock (this)
            {
                var colors = obj as IDictionary<int, ColorEntry>;
                if (colors != null)
                {
                        MainForm.Invoke(this, () =>
                            {
                                dataGridView1.Rows.Clear();
                                dataGridView1.Rows.Add(colors.Count-1);
                            });
                    int row = 0;
                    for (int i = 0; i < colors.Keys.Max(); i++)
                    {
                        if (colors.ContainsKey(i))
                        {
                            MainForm.Invoke(this, () => _setRow(dataGridView1.Rows[row++], colors[i]));
                        }
                    }
                }
            }
            Status = "Done";
        }

        private string RGBStringFormat = "ARGB: {0:X8}";
        private void _setRow(DataGridViewRow row, ColorEntry color)
        {
            row.HeaderCell.Value = row.Index.ToString();
            row.Cells["Id"].Value = string.Format("{0}:{1}", color.Id, color.Name);
            row.Cells["Cloth"].Style.BackColor = color.Cloth.RGB;
            row.Cells["Cloth"].ToolTipText = string.Format(RGBStringFormat, color.Cloth.RGB.ToArgb());
            row.Cells["Leather"].Style.BackColor = color.Leather.RGB;
            row.Cells["Leather"].ToolTipText = string.Format(RGBStringFormat, color.Leather.RGB.ToArgb());
            row.Cells["Metal"].Style.BackColor = color.Metal.RGB;
            row.Cells["Metal"].ToolTipText = string.Format(RGBStringFormat, color.Metal.RGB.ToArgb());
        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_refresh);
        }

        private void _refresh(object state)
        {
            Status = "Loading Colors";
            ColorsManager.Instance.Refresh(checkBoxForceUpdate.Checked);
        }

        private void ColorsUserControl1_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            ColorsManager.Instance.ColorsUpdated += Instance_ColorsUpdated;
            var col = dataGridView1.Columns[0];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col = dataGridView1.Columns[1];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col = dataGridView1.Columns[2];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col = dataGridView1.Columns[3];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
        }
    }
}
