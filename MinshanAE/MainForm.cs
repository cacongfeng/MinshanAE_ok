using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;

using stdole;

namespace MinshanAE
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//设置窗体最大化显示
        }

        //植被覆盖类型属性查询
        private void TypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "植被覆盖类型");
            attTable.Show(this);
        }

        //水系图层属性查询
        private void WaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "水系");
            attTable.Show(this);
        }

        //居民地图层属性查询
        private void ResidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "居民地");
            attTable.Show(this);
        }

        //交通图层属性查询
        private void TrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "交通");
            attTable.Show(this);
        }

        //主窗口加载函数
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainFormFunction myFunc = new MainFormFunction(axMapControl1, axTOCControl1);
            myFunc.InitializeMainForm();
        }

        //关于对话框
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        //显示、隐藏水系图层标注
        private void WaterCB_CheckedChanged(object sender, EventArgs e)
        {
            ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "水系");
            if (WaterCB.Checked == true)
            {
                MainFormFunction.AddLable(axMapControl1, layer, "NAME");
            }
            if (WaterCB.Checked == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, layer);
            }

        }

        //显示、隐藏交通图层标注
        private void TrafficCB_CheckedChanged(object sender, EventArgs e)
        {
            ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "交通");
            if (TrafficCB.Checked == true)
            {
                MainFormFunction.AddLable(axMapControl1, layer, "CODE");
            }
            if (TrafficCB.Checked == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, layer);
            }

        }

        //显示、隐藏居民地图层标注
        private void ResidentCB_CheckedChanged(object sender, EventArgs e)
        {
            ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "居民地");
            if (ResidentCB.Checked == true)
            {
                MainFormFunction.AddLable(axMapControl1, layer, "RNAME");
            }
            if (ResidentCB.Checked == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, layer);
            }
        }

        //显示、隐藏植被覆盖图层标注
        private void TypeCB_CheckedChanged(object sender, EventArgs e)
        {
            ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "植被覆盖");
            if (TypeCB.Checked == true)
            {
                MainFormFunction.AddLable(axMapControl1, layer, "NAME1");
            }
            if (TypeCB.Checked == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, layer);
            }
        }

        //显示、隐藏行政区图层标注
        private void RegionCB_CheckedChanged(object sender, EventArgs e)
        {
            ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "行政区");
            if (RegionCB.Checked == true)
            {
                MainFormFunction.AddLable(axMapControl1, layer, "FIRST_NAME");
            }
            if (RegionCB.Checked == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, layer);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ItemSel = comboBox1.Text;
            UsefulFunctions.SelectFeatures(axMapControl1,ItemSel);
        }

        private void AttCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttCalculatorForm attCalForm = new AttCalculatorForm(this);
            attCalForm.Show(this);
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            ILayer Waterlayer = UsefulFunctions.GetLayerByName(axMapControl1, "水系");
            if (Waterlayer.Visible == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, Waterlayer);
                WaterCB.Checked = false;
            }

            ILayer Trafficlayer = UsefulFunctions.GetLayerByName(axMapControl1, "交通");
            if (Trafficlayer.Visible == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, Trafficlayer);
                TrafficCB.Checked = false;
            }

            ILayer Residentlayer = UsefulFunctions.GetLayerByName(axMapControl1, "居民地");
            if (Residentlayer.Visible == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, Residentlayer);
                ResidentCB.Checked = false;
            }

            ILayer Typelayer = UsefulFunctions.GetLayerByName(axMapControl1, "植被覆盖");
            if (Typelayer.Visible == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, Typelayer);
                TypeCB.Checked = false;
            }

            ILayer Regionlayer = UsefulFunctions.GetLayerByName(axMapControl1, "行政区");
            if (Regionlayer.Visible == false)
            {
                MainFormFunction.DeleteLabel(axMapControl1, Regionlayer);
                RegionCB.Checked = false;
            }
        }

       

       
        private void copyToPageLayout() 
        { 
            IObjectCopy objectCopy = new ObjectCopyClass(); 
            object copyFromMap = axMapControl1.Map; 
            object copyMap = objectCopy.Copy(copyFromMap); 
            object copyToMap = axPageLayoutControl1.ActiveView.FocusMap; 
            objectCopy.Overwrite(copyMap, ref copyToMap); 
        }
       

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap; 
            IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation; 
            displayTransformation.VisibleBounds = axMapControl1.Extent; 
            axPageLayoutControl1.ActiveView.Refresh(); 
            copyToPageLayout(); 
        }
    }
}
