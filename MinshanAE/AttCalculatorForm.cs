using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MinshanAE
{
    public partial class AttCalculatorForm : Form
    {
        private MainForm tempMainForm;
        private IMap pMap;
        private IFeatureLayer pFeatureLayer;
        private ILayer pLayer;
        private ILayerFields pLayerFields;
        private IEnumLayer pEnumLayer;

        public AttCalculatorForm(MainForm mainForm)
        {
            InitializeComponent();
            this.tempMainForm = mainForm;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttCalculatorForm_Load(object sender, EventArgs e)
        {
            this.pMap = this.tempMainForm.axMapControl1.Map;
            //判断当前地图窗口有没有图层
            if (this.pMap.LayerCount == 0)
            {
                return;
            }
            this.pEnumLayer = this.pMap.get_Layers(null, true);
            if (pEnumLayer == null)
            {
                return;
            }
            //遍历所有图层，将所有图层名称添加到comboBoxLayers控件中
            pEnumLayer.Reset();
            for (this.pLayer = pEnumLayer.Next(); this.pLayer != null; pLayer = pEnumLayer.Next())
            {
                if (this.pLayer is IFeatureLayer)
                {
                    this.comboBoxLayers.Items.Add(this.pLayer.Name);
                }
            }
            if (this.comboBoxLayers.Items.Count == 0)
            {
                MessageBox.Show("没有可供选择的图层！");
                this.Close();
                return;
            }
            this.comboBoxLayers.SelectedIndex = 0;
            //this.comboBoxMethod.SelectedIndex = 0;

        }


        private void comboBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果没有图层，返回
            if (this.pEnumLayer == null)
            {
                return;
            }

            IField pField;//获取图层的字段
            int currentFieldType;//当前字段的数据类型

            this.pEnumLayer.Reset();
            this.listBoxFields.Items.Clear();

            //遍历所有图层，找到当前comboBoxLayers选择的图层
            for (this.pLayer = this.pEnumLayer.Next(); this.pLayer != null; this.pLayer = this.pEnumLayer.Next())
            {
                if (this.pLayer.Name != this.comboBoxLayers.Text)
                {
                    continue;
                }

                this.pLayerFields = this.pLayer as ILayerFields;
                for (int i = 0; i < this.pLayerFields.FieldCount; i++)
                {
                    pField = this.pLayerFields.get_Field(i);
                    currentFieldType = (int)pField.Type;
                    if (currentFieldType > 5)//若不是可以查询的字段类型，则跳过该字段
                    {
                        continue;
                    }
                    //将当前字段添加到listBoxFields中显示
                    this.listBoxFields.Items.Add(pField.Name);
                }
                break;
            }

            this.pFeatureLayer = this.pLayer as IFeatureLayer;
            this.labelLayer.Text = this.comboBoxLayers.Text;

        }

        /// <summary>
        /// 双击列表中的元素时，将该元素名添加到TextBoxWhereClause中。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = listBoxFields.SelectedItem.ToString() + " ";
        }

        /// <summary>
        /// 获取属性值按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetValue_Click(object sender, EventArgs e)
        {
            try
            {
                //如果listBoxFields里没有选择项，则返回
                if (this.listBoxFields.SelectedIndex == -1)
                {
                    return;
                }

                string currentFieldName = this.listBoxFields.Text;//当前字段名称
                string currentLayerName = this.comboBoxLayers.Text;//当前图层名称

                this.pEnumLayer.Reset();
                //遍历所有图层，找到用户选择的图层
                for (this.pLayer = this.pEnumLayer.Next(); this.pLayer != null; this.pLayer = this.pEnumLayer.Next())
                {
                    if (this.pLayer.Name == currentLayerName)
                    {
                        break;
                    }
                }

                this.pLayerFields = this.pLayer as ILayerFields;
                IField pField = this.pLayerFields.get_Field(this.pLayerFields.FindField(currentFieldName));
                esriFieldType pFieldType = pField.Type;

                //利用一个Table对象对结果进行排序 ，并将排序结果赋给Cursor对象
                ITable pTable = this.pLayer as ITable;
                ITableSort pTableSort = new TableSortClass();
                pTableSort.Table = pTable;
                pTableSort.Fields = currentFieldName;
                pTableSort.set_Ascending(currentFieldName, true);
                pTableSort.set_CaseSensitive(currentFieldName, true);
                pTableSort.Sort(null);
                ICursor pCursor = pTableSort.Rows;

                //字段统计
                IDataStatistics pDataStatistics = new DataStatisticsClass();
                pDataStatistics.Cursor = pCursor;
                pDataStatistics.Field = currentFieldName;
                System.Collections.IEnumerator pEnumeratorUniqueValues = pDataStatistics.UniqueValues;
                int uniqueValueCount = pDataStatistics.UniqueValueCount;

                this.listBoxValues.Items.Clear();
                string currentValue = null;
                pEnumeratorUniqueValues.Reset();
                if (pFieldType == esriFieldType.esriFieldTypeString)
                {
                    while (pEnumeratorUniqueValues.MoveNext())
                    {
                        currentValue = pEnumeratorUniqueValues.Current.ToString();
                        this.listBoxValues.Items.Add("'" + currentValue + "'");
                    }
                }
                else
                {
                    while (pEnumeratorUniqueValues.MoveNext())
                    {
                        currentValue = pEnumeratorUniqueValues.Current.ToString();
                        this.listBoxValues.Items.Add(currentValue);
                    }
                }



            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxValues.Items.Clear();
        }

#region 符号面板的按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " = ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " < > ";
            TextBoxWhereClause.SelectionStart = TextBoxWhereClause.TextLength - 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " Like ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " > ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " >= ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " And ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " < ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " <= ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " Or ";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " % ";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " ( ) ";
            TextBoxWhereClause.SelectionStart = TextBoxWhereClause.TextLength - 2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " _ ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " Not ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = " Is ";
        }
#endregion

        private void buttonOk_Click(object sender, EventArgs e)
        {
            buttonApply_Click_1(sender, e);
            this.Dispose();
        }

        private void buttonApply_Click_1(object sender, EventArgs e)
        {
            if (TextBoxWhereClause.Text == "")
            {
                MessageBox.Show("请生成查询语句！");
                return;
            }
            try
            {
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = TextBoxWhereClause.Text;
                IFeatureSelection pFeatureSelection = this.pFeatureLayer as IFeatureSelection;
                int iSelectedFeaturesCount = pFeatureSelection.SelectionSet.Count;
                esriSelectionResultEnum selectMethod;
                switch (comboBoxMethod.SelectedIndex)
                {
                    case 0: selectMethod = esriSelectionResultEnum.esriSelectionResultNew;
                        break;
                    case 1: selectMethod = esriSelectionResultEnum.esriSelectionResultAdd;
                        break;
                    case 2: selectMethod = esriSelectionResultEnum.esriSelectionResultAnd;
                        break;
                    case 3: selectMethod = esriSelectionResultEnum.esriSelectionResultSubtract;
                        break;
                    default: selectMethod = esriSelectionResultEnum.esriSelectionResultNew;
                        break;
                }
                pFeatureSelection.SelectFeatures(pQueryFilter, selectMethod, false);

                if (pFeatureSelection.SelectionSet.Count == iSelectedFeaturesCount || pFeatureSelection.SelectionSet.Count == 0)
                {
                    MessageBox.Show("没有符合本次查询条件的结果！");
                    return;
                }
                this.tempMainForm.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("您的查询语句可能有误，请检查！|" + ex.Message);
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TextBoxWhereClause.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listBoxValues_DoubleClick(object sender, EventArgs e)
        {
            TextBoxWhereClause.SelectedText = listBoxValues.SelectedItem.ToString() + " ";
        }

    }
}
