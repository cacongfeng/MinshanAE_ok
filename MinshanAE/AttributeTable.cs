﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace MinshanAE
{
    public partial class AttributeTable : Form
    {
        private AxMapControl m_mapControl;
        private string m_attForm;//获取属性表类型

        public AttributeTable(AxMapControl pMapControl, string attForm)
        {
            InitializeComponent();
            m_mapControl = pMapControl;
            m_attForm = attForm;
        }



        /// <summary>
        /// 加载相应的属性表，由于需要对不同文件的属性表进行字段封装，因此每个属性表单独加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributeTable_Load(object sender, EventArgs e)
        {
            if (m_attForm == "植被覆盖类型")
            {
                LoadTypeAttTable();
            }

            if (m_attForm == "水系")
            {
                LoadWaterAttTable();
            }

            if (m_attForm == "交通")
            {
                LoadTrafficAttTable();
            }

            if (m_attForm == "居民地")
            {
                LoadResidentAttTable();
            }

        }

        /// <summary>
        /// 加载植被覆盖类型属性表
        /// </summary>
        private void LoadTypeAttTable()
        {
            ILayer pLayer = UsefulFunctions.GetLayerByName(m_mapControl, "植被覆盖");
            if (pLayer == null)
            {
                MessageBox.Show("没有植被覆盖图层，属性表将为空！");
                return;
            }

            this.Text = "植被覆盖类型";
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFClass = pFLayer.FeatureClass;
            IFeatureCursor pFCursor = pFClass.Search(null, false);
            IFeature pFeature = pFCursor.NextFeature();

            //新建属性表的列头
            DataTable pTable = new DataTable();
            DataColumn pColumnID = new DataColumn("ID");
            DataColumn pColumnType = new DataColumn("植被覆盖类型");
            DataColumn pColumnTypeArea = new DataColumn("植被覆盖面积");
            DataColumn pColumnRegion = new DataColumn("所属行政区");
            DataColumn pColumnCounty = new DataColumn("所属县");
            DataColumn pColumnCountyArea = new DataColumn("县面积");

            //设置列数据类型
            pColumnID.DataType = System.Type.GetType("System.String");
            pColumnType.DataType = System.Type.GetType("System.String");
            pColumnRegion.DataType = System.Type.GetType("System.String");
            pColumnCounty.DataType = System.Type.GetType("System.String");
            pColumnCountyArea.DataType = System.Type.GetType("System.String");
            pColumnTypeArea.DataType = System.Type.GetType("System.String");

            //把各个列头添加到属性表Table
            pTable.Columns.Add(pColumnID);
            pTable.Columns.Add(pColumnType);
            pTable.Columns.Add(pColumnTypeArea);
            pTable.Columns.Add(pColumnRegion);
            pTable.Columns.Add(pColumnCounty);
            pTable.Columns.Add(pColumnCountyArea);

            //找到各个属性所在索引
            int indexOfID = pFClass.FindField("OBJECTID");
            int indexOfType = pFClass.FindField("NAME1");
            int indexOfTypeArea = pFClass.FindField("Shape_Area");
            int indexOfRegion = pFClass.FindField("DQNAME1");
            int indexOfCounty = pFClass.FindField("XJNAME1");
            int indexOfCountyArea = pFClass.FindField("MJ");


            while (pFeature != null)
            {
                string id = pFeature.get_Value(indexOfID).ToString();
                string type = pFeature.get_Value(indexOfType).ToString();
                string typeArea = pFeature.get_Value(indexOfTypeArea).ToString();
                string region = pFeature.get_Value(indexOfRegion).ToString();
                string county = pFeature.get_Value(indexOfCounty).ToString();
                string countyArea = pFeature.get_Value(indexOfCountyArea).ToString();

                DataRow pRow = pTable.NewRow();
                pRow[0] = id;
                pRow[1] = type;
                pRow[2] = typeArea;
                pRow[3] = region;
                pRow[4] = county;
                pRow[5] = countyArea;
                pTable.Rows.Add(pRow);

                pFeature = pFCursor.NextFeature();
            }
            this.dataGridView1.DataSource = pTable;
        }/*LoadTypeAttTable*/

        /// <summary>
        /// 加载水系属性表
        /// </summary>
        private void LoadWaterAttTable()
        {
            ILayer pLayer = UsefulFunctions.GetLayerByName(m_mapControl, "水系");
            if (pLayer == null)
            {
                MessageBox.Show("没有水系图层，属性表将为空！");
                return;
            }

            this.Text = "水系";
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFClass = pFLayer.FeatureClass;
            IFeatureCursor pFCursor = pFClass.Search(null, false);
            IFeature pFeature = pFCursor.NextFeature();

            //新建属性表的列头
            DataTable pTable = new DataTable();
            DataColumn pColumnID = new DataColumn("ID");
            DataColumn pColumnName = new DataColumn("名称");
            DataColumn pColumnLength = new DataColumn("长度(km)");
            DataColumn pColumnGB = new DataColumn("GB");

            //设置列数据类型
            pColumnID.DataType = System.Type.GetType("System.String");
            pColumnName.DataType = System.Type.GetType("System.String");
            pColumnLength.DataType = System.Type.GetType("System.String");
            pColumnGB.DataType = System.Type.GetType("System.String");

            //把各个列头添加到属性表Table
            pTable.Columns.Add(pColumnID);
            pTable.Columns.Add(pColumnName);
            pTable.Columns.Add(pColumnLength);
            pTable.Columns.Add(pColumnGB);

            //找到各个属性所在索引
            int indexOfID = pFClass.FindField("OBJECTID");
            int indexOfName = pFClass.FindField("NAME");
            int indexOfLength = pFClass.FindField("LENGTH");
            int indexOfGB = pFClass.FindField("GB");

            while (pFeature != null)
            {
                string id = pFeature.get_Value(indexOfID).ToString();
                string name = pFeature.get_Value(indexOfName).ToString();
                string length = pFeature.get_Value(indexOfLength).ToString();
                string GB = pFeature.get_Value(indexOfGB).ToString();

                DataRow pRow = pTable.NewRow();
                pRow[0] = id;
                pRow[1] = name;
                pRow[2] = length;
                pRow[3] = GB;

                pTable.Rows.Add(pRow);

                pFeature = pFCursor.NextFeature();
            }
            this.dataGridView1.DataSource = pTable;
        }/*LoadWaterAttTable8*/

        /// <summary>
        /// 加载交通属性表
        /// </summary>
        private void LoadTrafficAttTable()
        {
            ILayer pLayer = UsefulFunctions.GetLayerByName(m_mapControl, "交通");
            if (pLayer == null)
            {
                MessageBox.Show("没有交通图层，属性表将为空！");
                return;
            }

            this.Text = "交通";
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFClass = pFLayer.FeatureClass;
            IFeatureCursor pFCursor = pFClass.Search(null, false);
            IFeature pFeature = pFCursor.NextFeature();

            //新建属性表的列头
            DataTable pTable = new DataTable();
            DataColumn pColumnID = new DataColumn("ID");
            DataColumn pColumnLength = new DataColumn("长度(km)");
            DataColumn pColumnCode = new DataColumn("编码");
            DataColumn pColumnGB = new DataColumn("GB");

            //设置列数据类型
            pColumnID.DataType = System.Type.GetType("System.String");
            pColumnLength.DataType = System.Type.GetType("System.String");
            pColumnCode.DataType = System.Type.GetType("System.String");
            pColumnGB.DataType = System.Type.GetType("System.String");

            //把各个列头添加到属性表Table
            pTable.Columns.Add(pColumnID);
            pTable.Columns.Add(pColumnLength);
            pTable.Columns.Add(pColumnCode);
            pTable.Columns.Add(pColumnGB);

            //找到各个属性所在索引
            int indexOfID = pFClass.FindField("OBJECTID");
            int indexOfLength = pFClass.FindField("LENGTH");
            int indexOfCode = pFClass.FindField("CODE");
            int indexOfGB = pFClass.FindField("GB");

            while (pFeature != null)
            {
                string id = pFeature.get_Value(indexOfID).ToString();
                string length = pFeature.get_Value(indexOfLength).ToString();
                string code = pFeature.get_Value(indexOfCode).ToString();
                string GB = pFeature.get_Value(indexOfGB).ToString();

                DataRow pRow = pTable.NewRow();
                pRow[0] = id;
                pRow[1] = length;
                pRow[2] = code;
                pRow[3] = GB;

                pTable.Rows.Add(pRow);

                pFeature = pFCursor.NextFeature();
            }
            this.dataGridView1.DataSource = pTable;
        }/*LoadTrafficAttTable*/

        /// <summary>
        /// 加载居民地属性表
        /// </summary>
        private void LoadResidentAttTable()
        {
            ILayer pLayer = UsefulFunctions.GetLayerByName(m_mapControl, "居民地");
            if (pLayer == null)
            {
                MessageBox.Show("没有居民地图层，属性表将为空！");
                return;
            }

            this.Text = "居民地";
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFClass = pFLayer.FeatureClass;
            IFeatureCursor pFCursor = pFClass.Search(null, false);
            IFeature pFeature = pFCursor.NextFeature();

            //新建属性表的列头
            DataTable pTable = new DataTable();
            DataColumn pColumnID = new DataColumn("ID");
            DataColumn pColumnCode = new DataColumn("编码");
            DataColumn pColumnGB = new DataColumn("GB");
            DataColumn pColumnName = new DataColumn("名称");

            //设置列数据类型
            pColumnID.DataType = System.Type.GetType("System.String");
            pColumnCode.DataType = System.Type.GetType("System.String");
            pColumnGB.DataType = System.Type.GetType("System.String");
            pColumnName.DataType = System.Type.GetType("System.String");

            //把各个列头添加到属性表Table
            pTable.Columns.Add(pColumnID);
            pTable.Columns.Add(pColumnCode);
            pTable.Columns.Add(pColumnGB);
            pTable.Columns.Add(pColumnName);

            //找到各个属性所在索引
            int indexOfID = pFClass.FindField("OBJECTID");
            int indexOfCode = pFClass.FindField("CODE");
            int indexOfGB = pFClass.FindField("GB");
            int indexOfName = pFClass.FindField("RNAME");

            while (pFeature != null)
            {
                string id = pFeature.get_Value(indexOfID).ToString();
                string code = pFeature.get_Value(indexOfCode).ToString();
                string GB = pFeature.get_Value(indexOfGB).ToString();
                string name = pFeature.get_Value(indexOfName).ToString();

                DataRow pRow = pTable.NewRow();
                pRow[0] = id;
                pRow[1] = code;
                pRow[2] = GB;
                pRow[3] = name;

                pTable.Rows.Add(pRow);

                pFeature = pFCursor.NextFeature();
            }
            this.dataGridView1.DataSource = pTable;
        }/*LoadResidentAttTable*/

        private void StatisticToolStripButton_Click(object sender, EventArgs e)
        {
            StatisticForm SForm = new StatisticForm();
            SForm.ShowDialog();
        }

        /// <summary>
        ///  用户双击行标题时，地图缩放到该要素位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ICommand pCommand = new ControlsZoomToSelectedCommandClass();
            pCommand.OnCreate(m_mapControl.Object);
            pCommand.OnClick();
        }

        /// <summary>
        /// 用户选择的要素改变时，在地图上高亮显示当前选择要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection pSelRowCollction = dataGridView1.SelectedRows;
            IQueryFilter pQueryFilter = new QueryFilterClass();//定义查询类
            if (pSelRowCollction.Count<=0)
            {
                return;
            }
            m_mapControl.Map.ClearSelection();
            m_mapControl.ActiveView.Refresh();
            #region 根据不同图层的属性表，设置不同的获取不同的layer
            ILayer layer = null;
            if (this.Text == "植被覆盖类型")
            {
                layer = UsefulFunctions.GetLayerByName(m_mapControl, "植被覆盖");
            }
            if (this.Text == "居民地")
            {
                layer = UsefulFunctions.GetLayerByName(m_mapControl, "居民地");
            }
            if (this.Text == "水系")
            {
                layer = UsefulFunctions.GetLayerByName(m_mapControl, "水系");
            }
            if (this.Text == "交通")
            {
                layer = UsefulFunctions.GetLayerByName(m_mapControl, "交通");
            }
            if (this.Text == "行政区")
            {
                layer = UsefulFunctions.GetLayerByName(m_mapControl, "行政区");
            }
            #endregion

            
            IFeatureLayer pFeatureLayer = layer as IFeatureLayer;
            IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
            string ID = pSelRowCollction[0].Cells["ID"].Value.ToString();
            pQueryFilter.WhereClause = "OBJECTID = " + ID;//设置查询语句
            esriSelectionResultEnum selectMethod = esriSelectionResultEnum.esriSelectionResultNew;//设置查询方法
            pFeatureSelection.SelectFeatures(pQueryFilter, selectMethod, false);
            m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);//刷新地图
        }
    }
}
