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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;

namespace MinshanAE
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1,"植被覆盖类型");
            attTable.ShowDialog(this);
        }

        private void WaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "水系");
            attTable.ShowDialog(this);
        }

        private void ResidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "居民地");
            attTable.ShowDialog(this);
        }

        private void TrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttributeTable attTable = new AttributeTable(this.axMapControl1, "交通");
            attTable.ShowDialog(this);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IWorkspaceFactory worFact = new FileGDBWorkspaceFactory();
            string filePath = @"D:\岷山地区地理数据库.gdb";
            IWorkspace workspace = worFact.OpenFromFile(filePath, 0);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace.WorkspaceFactory.OpenFromFile(filePath, axMapControl1.hWnd);

            //添加居民地
            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.Name = "居民地";
            featureLayer.Visible = true;
            featureLayer.FeatureClass = featureWorkspace.OpenFeatureClass("居民地");

            axMapControl1.Map.AddLayer((ILayer)featureLayer);
            //添加水系
            IFeatureLayer featureLayer0 = new FeatureLayer();
            featureLayer0.Name = "水系";
            featureLayer0.Visible = true;
            featureLayer0.FeatureClass = featureWorkspace.OpenFeatureClass("水系");
            axMapControl1.Map.AddLayer((ILayer)featureLayer0);
            //添加交通
            IFeatureLayer featureLayer1 = new FeatureLayer();
            featureLayer1.Name = "交通";
            featureLayer1.Visible = true;
            featureLayer1.FeatureClass = featureWorkspace.OpenFeatureClass("交通");
            axMapControl1.Map.AddLayer((ILayer)featureLayer1);
            //添加植被覆盖a
            IFeatureLayer featureLayer2 = new FeatureLayer();
            featureLayer2.Name = "植被覆盖a";
            featureLayer2.Visible = true;
            featureLayer2.FeatureClass = featureWorkspace.OpenFeatureClass("植被覆盖a");
            axMapControl1.Map.AddLayer((ILayer)featureLayer2);

        }
    }
}
