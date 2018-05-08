using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET;
using GwApiNETExample.Controls;
using GwApiNETExample.Managers;

namespace GwApiNETExample.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateStatus(SelectedTabStatus);
        }

        private Timer timer = new Timer();
        private void MainForm_Load(object sender, EventArgs e)
        {
            _initAll();
        }

        private void _initAll()
        {
            GwApi.RegisterErrorHandler<ResponseException>(_exceptionHandler);
            BuildLabel.Text = GwApi.Build.ToString();
            _initItemsTab();
            _initGuildDetailsTab();
            _initColorsTab();
            _initMapTab();
            _initRecipeTab();
        }

        private void _exceptionHandler(object exception)
        {
            var e = exception as Exception;
            string message = (e == null) ? "Error occured" : e.Message;
            Action display = () => MessageBox.Show(message, "Error");
            Invoke(display);
        }

        #region Tab Items Demo
        private void _initMapTab()
        {
            GwMapUserControl map = new GwMapUserControl();
            var page = tabControl1.TabPages["tabPageMap"];
            page.Controls.Add(map);
            page.Tag = map;
            map.Dock = DockStyle.Fill;
        }

        void _initItemsTab()
        {
            itemsSearchUserControl1.ComboBoxIds.SelectedValueChanged += ComboBoxIds_SelectedValueChanged;
            tabControl1.TabPages["tabPageItems"].Tag = itemsSearchUserControl1;
        }
        void ComboBoxIds_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                itemDetailsUserControl1.SetItem(ItemManager.Items[int.Parse(itemsSearchUserControl1.ComboBoxIds.Text)]);
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        #endregion Tab Items Demo

        #region Tab Guild Details
        void _initGuildDetailsTab()
        {
            tabControl1.TabPages["tabPageGuildDetails"].Tag = guildDetailsUserControl1;
        }
        #endregion 

        #region Tab Colors
        void _initColorsTab()
        {
            tabControl1.TabPages["tabPageColors"].Tag = colorsUserControl1;
        }
        #endregion

        #region Tab Recipe
        private void _initRecipeTab()
        {
            tabControl1.TabPages["tabPageRecipes"].Tag = recipeViewerUserControl1;
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();
            ResponseCache.Cache.Save();
            base.OnClosing(e);
        }

        public static void Invoke(Control c, Action a)
        {
            c.Invoke(a);
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus(SelectedTabStatus);
        }

        public void UpdateStatus(string status)
        {
            StatusLabel.Text = status;
        }

        public TabPage SelectedTab
        {
            get { return tabControl1.SelectedTab; }
        }

        public string SelectedTabStatus
        {
            get
            {
                if (SelectedTab == null) return "Done";
                IUpdateStatus o = SelectedTab.Tag as IUpdateStatus;
                if (o != null)
                    return o.Status;
                return "Done";
            }
        }
    }
}
