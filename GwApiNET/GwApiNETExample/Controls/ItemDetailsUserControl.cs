using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET;
using GwApiNET.ResponseObjects;
using GwApiNET.ResponseObjects.Parsers;
using RestSharp;

namespace GwApiNETExample.Controls
{
    public partial class ItemDetailsUserControl : UserControlBase
    {
        public ItemDetailsEntry Item { get; private set; }
        public string Description
        {
            get { return Item.Description; }
            private set { labelDescription.Text = "Description: " + value; }
        }
        
        public string ItemName
        {
            get { return Item.Name; }
            private set { labelName.Text = "Name: " + value; }
        }

        public int Level
        {
            get { return Item.Level; }
            private set { labelLevel.Text = "Level: " + value; }
        }

        public int VendorValue
        {
            get { return Item.VendorValue; }
            private set { labelVendorValue.Text = "VendorValue: " + value; }
        }

        public string[] Restrictions
        {
            get { return Item.Restrictions; }
            private set
            {
                StringBuilder sb = new StringBuilder();
                foreach (var res in value)
                {
                    sb.AppendLine(res);
                }
                labelRestrictions.Text = "Restrictions: " + sb.ToString();
            }
        }

        public ItemDetailsUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public void SetItem(ItemDetailsEntry item)
        {
            Item = item;
            Description = item.Description;
            ItemName = item.Name;
            Level = item.Level;
            VendorValue = item.VendorValue;
            Restrictions = item.Restrictions;
            var img = GwApi.GetRenderServiceAssetEntry(item.IconFileSignature, item.IconFileId, ".png");
            pictureBox1.Image = img.Asset;
            labelDetails.Text = _getDetails(item);
            groupBox2.Text = _getDetailsType(item);
        }

        private string _getDetailsType(ItemDetailsEntry item)
        {
            if (item.ArmorDetails != null)
                return item.ArmorDetails.GetType().Name;
            if (item.BackDetails != null)
                return item.BackDetails.GetType().Name;
            if (item.BagDetails != null)
                return item.BagDetails.GetType().Name;
            if (item.ConsumableDetails != null)
                return item.ConsumableDetails.GetType().Name;
            if (item.ContainerDetails != null)
                return item.ContainerDetails.GetType().Name;
            if (item.CraftingMaterialDetails != null)
                return item.CraftingMaterialDetails.GetType().Name;
            if (item.GizmoDetails != null)
                return item.GizmoDetails.GetType().Name;
            if (item.ToolDetails != null)
                return item.ToolDetails.GetType().Name;
            if (item.TrinketDetails != null)
                return item.TrinketDetails.GetType().Name;
            if (item.TrophyDetails != null)
                return item.TrophyDetails.GetType().Name;
            if (item.WeaponDetails != null)
                return item.WeaponDetails.GetType().Name;
            return "";
        }

        private string _getDetails(ItemDetailsEntry item)
        {
            StringBuilder sb = new StringBuilder();
            if (item.ArmorDetails != null)
                sb.Append(item.ArmorDetails.ToString());
            if (item.BackDetails != null)
                sb.Append(item.BackDetails.ToString());
            if (item.BagDetails != null)
                sb.Append(item.BagDetails.ToString());
            if (item.ConsumableDetails != null)
                sb.Append(item.ConsumableDetails.ToString());
            if (item.ContainerDetails != null)
                sb.Append(item.ContainerDetails.ToString());
            if (item.CraftingMaterialDetails != null)
                sb.Append(item.CraftingMaterialDetails.ToString());
            if (item.GizmoDetails != null)
                sb.Append(item.GizmoDetails.ToString());
            if (item.ToolDetails != null)
                sb.Append(item.ToolDetails.ToString());
            if (item.TrinketDetails != null)
                sb.Append(item.TrinketDetails.ToString());
            if (item.TrophyDetails != null)
                sb.Append(item.TrophyDetails.ToString());
            if (item.WeaponDetails != null)
                sb.Append(item.WeaponDetails.ToString());
            return sb.ToString();
        }
    }
}
