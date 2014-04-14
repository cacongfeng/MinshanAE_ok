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
            AttributeTable attTable = new AttributeTable(this.axMapControl1,"植被覆盖类型");
            attTable.ShowDialog(this);
        }

        //水系图层属性查询
        private void WaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "水系");
            attTable.ShowDialog(this);
        }

        //居民地图层属性查询
        private void ResidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "居民地");
            attTable.ShowDialog(this);
        }

        //交通图层属性查询
        private void TrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "交通");
            attTable.ShowDialog(this);
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
            if (WaterCB.Checked==true)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "水系");
                MainFormFunction.AddLable(axMapControl1, layer, "NAME");
            }
            if (WaterCB.Checked == false)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "水系");
                MainFormFunction.DeleteLabel(axMapControl1, Layer, "NAME");
            }
            
        }

        //显示、隐藏交通图层标注
        private void TrafficCB_CheckedChanged(object sender, EventArgs e)
        {
            if (WaterCB.Checked == true)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "交通");
                MainFormFunction.AddLable(axMapControl1, layer, "CODE");
            }
            if (WaterCB.Checked == false)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "交通");
                MainFormFunction.DeleteLabel(axMapControl1, Layer, "CODE");
            }

        }

        //显示、隐藏居民地图层标注
        private void ResidentCB_CheckedChanged(object sender, EventArgs e)
        {
            if (WaterCB.Checked == true)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "居民地");
                MainFormFunction.AddLable(axMapControl1, layer, "RNAME");
            }
            if (WaterCB.Checked == false)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "居民地");
                MainFormFunction.DeleteLabel(axMapControl1, Layer, "RNAME");
            }
        }

        //显示、隐藏植被覆盖图层标注
        private void TypeCB_CheckedChanged(object sender, EventArgs e)
        {
            if (WaterCB.Checked == true)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "植被覆盖a");
                MainFormFunction.AddLable(axMapControl1, layer, "NAME1");
            }
            if (WaterCB.Checked == false)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "植被覆盖a");
                MainFormFunction.DeleteLabel(axMapControl1, Layer, "NAME1");
            }
        }

        private void RegionCB_CheckedChanged(object sender, EventArgs e)
        {
            if (WaterCB.Checked == true)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "行政区");
                MainFormFunction.AddLable(axMapControl1, layer, "NAME");
            }
            if (WaterCB.Checked == false)
            {
                ILayer layer = UsefulFunctions.GetLayerByName(axMapControl1, "行政区");
                MainFormFunction.DeleteLabel(axMapControl1, Layer, "NAME");
            }
        }
    }
}
