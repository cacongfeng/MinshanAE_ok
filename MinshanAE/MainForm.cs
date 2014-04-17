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
using ESRI.ArcGIS.Output;

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

        //根据comboBox选择的植被类型显示选择的要素
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ItemSel = comboBox1.Text;
            UsefulFunctions.SelectFeatures(axMapControl1,ItemSel);
        }

        //属性计算器功能
        private void AttCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttCalculatorForm attCalForm = new AttCalculatorForm(this);
            attCalForm.Show(this);
        }

        //删除label
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

       

        /// <summary>
        /// pageLayout与地图联动
        /// </summary>
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

        //输出地图到图像
        public bool ExportMapToImage(IActiveView pActiveView, string fileName, int filterIndex)
        {
            try
            {
                IExport pExporter = null;
                switch (filterIndex)
                {
                    case 1:
                        pExporter = new ExportJPEGClass();
                        break;
                    case 2:
                        pExporter = new ExportBMPClass();
                        break;
                    case 3:
                        pExporter = new ExportEMFClass();
                        break;
                    case 4:
                        pExporter = new ExportGIFClass();
                        break;
                    case 5:
                        pExporter = new ExportAIClass();
                        break;
                    case 6:
                        pExporter = new ExportPDFClass();
                        break;
                    case 7:
                        pExporter = new ExportPNGClass();
                        break;
                    case 8:
                        pExporter = new ExportPSClass();
                        break;
                    case 9:
                        pExporter = new ExportSVGClass();
                        break;
                    case 10:
                        pExporter = new ExportTIFFClass();
                        break;
                    default:
                        MessageBox.Show("输出格式错误");
                        return false;
                }



                IEnvelope pEnvelope = new EnvelopeClass();
                ITrackCancel pTrackCancel = new CancelTrackerClass();
                tagRECT ptagRECT;
                ptagRECT.left = 0;
                ptagRECT.top = 0;
                ptagRECT.right = (int)pActiveView.Extent.Width;
                ptagRECT.bottom = (int)pActiveView.Extent.Height;



                int pResolution = (int)(pActiveView.ScreenDisplay.DisplayTransformation.Resolution);
                pEnvelope.PutCoords(ptagRECT.left, ptagRECT.bottom, ptagRECT.right, ptagRECT.top);



                pExporter.Resolution = pResolution;
                pExporter.ExportFileName = fileName;
                pExporter.PixelBounds = pEnvelope;



                pActiveView.Output(pExporter.StartExporting(), pResolution, ref ptagRECT, pActiveView.Extent, pTrackCancel);
                pExporter.FinishExporting();



                //释放资源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pExporter);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "输出图片", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //输出地图到图像功能函数
        private void SaveToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG(*.jpg)|*.jpg|BMP(*.BMP)|*.bmp|EMF(*.emf)|*.emf|GIF(*.gif)|*.gif|AI(*.ai)|*.ai|PDF(*.pdf)|*.pdf|PNG(*.png)|*.png|EPS(*.eps)|*.eps|SVG(*.svg)|*.svg|TIFF(*.tif)|*.tif";
            saveFileDialog1.Title = "输出地图";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FilterIndex = 1;
            
            
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName.ToString();
                int filterIndex = saveFileDialog1.FilterIndex;
                IActiveView pActiveView = axPageLayoutControl1.ActiveView;
                //ExportPic exportPic = new ExportPic();
                //bool flag = exportPic.ExportMapToImage(pActiveView,fileName,filterIndex);

                bool flag = ExportMapToImage(pActiveView, fileName, filterIndex);
                saveFileDialog1.Dispose();
                if (flag)
                {
                    MessageBox.Show("图片输出成功！", "成功");
                }
                else
                {
                    MessageBox.Show("图片输出失败，请重新生成！", "失败");
                }
            }
            
            
        }
    }
}
