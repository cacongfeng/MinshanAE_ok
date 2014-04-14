using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;

namespace MinshanAE
{
    class MainFormFunction
    {
        private AxMapControl m_mapControl;
        private AxTOCControl m_tocControl;

        public MainFormFunction(AxMapControl pMapControl, AxTOCControl pTocControl)
        {
            m_mapControl = pMapControl;
            m_tocControl = pTocControl;
        }

        //初始化地图窗口
        public void InitializeMainForm()
        {
            IWorkspaceFactory worFact = new FileGDBWorkspaceFactory();
            string filePath = @"D:\岷山地区地理数据库.gdb";
            IWorkspace workspace = worFact.OpenFromFile(filePath, 0);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace.WorkspaceFactory.OpenFromFile(filePath, m_mapControl.hWnd);

            //添加植被覆盖a
            IFeatureLayer featureLayer2 = new FeatureLayer();
            featureLayer2.Name = "植被覆盖a";
            featureLayer2.Visible = true;
            featureLayer2.FeatureClass = featureWorkspace.OpenFeatureClass("植被覆盖a");
            m_mapControl.Map.AddLayer((ILayer)featureLayer2);
            //添加居民地
            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.Name = "居民地";
            featureLayer.Visible = true;
            featureLayer.FeatureClass = featureWorkspace.OpenFeatureClass("居民地");

            m_mapControl.Map.AddLayer((ILayer)featureLayer);
            //添加水系
            IFeatureLayer featureLayer0 = new FeatureLayer();
            featureLayer0.Name = "水系";
            featureLayer0.Visible = true;
            featureLayer0.FeatureClass = featureWorkspace.OpenFeatureClass("水系");
            m_mapControl.Map.AddLayer((ILayer)featureLayer0);

            //添加交通
            IFeatureLayer featureLayer1 = new FeatureLayer();
            featureLayer1.Name = "交通";
            featureLayer1.Visible = true;
            featureLayer1.FeatureClass = featureWorkspace.OpenFeatureClass("交通");
            m_mapControl.Map.AddLayer((ILayer)featureLayer1);

            //生成专题图
            ITable pTable;
            int fieldNumber;
            string strFieldName = "NAME1";

            pTable = (ITable)m_mapControl.get_Layer(3);
            fieldNumber = pTable.FindField(strFieldName);
            if (fieldNumber == -1)
            {
                MessageBox.Show("Can't find field called STATE_NAME");
                return;
            }

            IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();
            pUniqueValueRenderer.FieldCount = 1;
            pUniqueValueRenderer.set_Field(0, strFieldName);


            object codeValue;
            bool ok;

            IRandomColorRamp pColorRamp = new RandomColorRampClass();
            pColorRamp.StartHue = 0;
            pColorRamp.MinValue = 99;
            pColorRamp.MinSaturation = 15;
            pColorRamp.EndHue = 360;
            pColorRamp.MaxValue = 100;
            pColorRamp.MaxSaturation = 30;
            pColorRamp.Size = 100;
            pColorRamp.CreateRamp(out ok);
            IEnumColors pEnumRamp = pColorRamp.Colors;

            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(strFieldName);
            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pNextRow = pCursor.NextRow();

            IFillSymbol pSym;
            IColor pNextUniqueColor;

            if (pNextRow != null)
            {
                int fieldIndex = pNextRow.Fields.FindField(strFieldName);
                do
                {
                    codeValue = pNextRow.get_Value(fieldIndex);

                    pNextUniqueColor = pEnumRamp.Next();
                    if (pNextUniqueColor == null)
                    {
                        pEnumRamp.Reset();
                        pNextUniqueColor = pEnumRamp.Next();
                    }

                    pSym = new SimpleFillSymbolClass();
                    pSym.Color = pNextUniqueColor;
                    pUniqueValueRenderer.AddValue(codeValue.ToString(), "NAME1", (ISymbol)pSym);

                    pNextRow = pCursor.NextRow();

                } while (pNextRow != null);
            }

            IGeoFeatureLayer m_pGeoFeatureLayer = (IGeoFeatureLayer)m_mapControl.get_Layer(3);
            m_pGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;

            m_mapControl.ActiveView.Refresh();
            m_tocControl.SetBuddyControl(m_mapControl.Object);
            m_tocControl.Refresh();
        }

    }
}
