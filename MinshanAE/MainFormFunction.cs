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
            //添加行政区
            IFeatureLayer featureLayer3 = new FeatureLayer();
            featureLayer3.Name = "行政区";
            featureLayer3.Visible = true;
            featureLayer3.FeatureClass = featureWorkspace.OpenFeatureClass("行政区");
            m_mapControl.Map.AddLayer((ILayer)featureLayer3);
            
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
            //添加居民地
            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.Name = "居民地";
            featureLayer.Visible = true;
            featureLayer.FeatureClass = featureWorkspace.OpenFeatureClass("居民地");

            m_mapControl.Map.AddLayer((ILayer)featureLayer);
            //生成专题图
            //渲染植被覆盖a
            ITable pTable;
            int fieldNumber;
            string strFieldName = "NAME1";

            pTable = (ITable)m_mapControl.get_Layer(4);
            fieldNumber = pTable.FindField(strFieldName);
            if (fieldNumber == -1)
            {
                MessageBox.Show("Can't find field called 植被覆盖a");
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
            IGeoFeatureLayer m_pGeoFeatureLayer = (IGeoFeatureLayer)m_mapControl.get_Layer(4);
            m_pGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;
            //渲染行政区
            IGeoFeatureLayer geoLayer = m_mapControl.get_Layer(3) as IGeoFeatureLayer;
            ISimpleRenderer renderer = new SimpleRendererClass();
            ISimpleFillSymbol pMarkerSymbol = new SimpleFillSymbol();
            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbol();　　//新建线状样式
            IRgbColor pColor = new RgbColor();
            pColor.Red = 255;
            pSimpleLineSymbol.Width =3;
            pSimpleLineSymbol.Color = pColor;
            pMarkerSymbol.Style = esriSimpleFillStyle.esriSFSHollow;
            pMarkerSymbol.Outline= pSimpleLineSymbol;
            renderer.Symbol = (ISymbol)pMarkerSymbol;
            geoLayer.Renderer = (IFeatureRenderer)renderer;
            //渲染居民地
            IGeoFeatureLayer ResidentLayer = m_mapControl.get_Layer(0) as IGeoFeatureLayer;
            ISimpleRenderer ResidentRenderer = new SimpleRendererClass();
            ISimpleMarkerSymbol ResidentMarkerSymbol = new SimpleMarkerSymbol();
            ResidentMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            ResidentMarkerSymbol.Size = 3;
            
            IRgbColor ResidentColor = new RgbColor();
            ResidentColor.Blue = 0;
            ResidentColor.Green = 0;
            ResidentColor.Red = 0;
            ResidentMarkerSymbol.Color = ResidentColor;
            ResidentRenderer.Symbol = (ISymbol)ResidentMarkerSymbol;
            ResidentLayer.Renderer = (IFeatureRenderer)ResidentRenderer;
            //渲染水系
            IGeoFeatureLayer RiverLayer = m_mapControl.get_Layer(2) as IGeoFeatureLayer;
            ISimpleRenderer RiverRenderer = new SimpleRendererClass();
            ISimpleLineSymbol RiverLineSymbol = new SimpleLineSymbol();　　//新建线状样式
            IRgbColor RiverColor = new RgbColor();
            RiverColor.Blue = 255;
            RiverColor.Green = 0;
            RiverColor.Red = 0;
            RiverLineSymbol.Width = 1;
            RiverLineSymbol.Color = RiverColor;
            RiverRenderer.Symbol = (ISymbol)RiverLineSymbol;
            RiverLayer.Renderer = (IFeatureRenderer)RiverRenderer;
            //渲染道路
            IGeoFeatureLayer RoadLayer = m_mapControl.get_Layer(1) as IGeoFeatureLayer;
            ISimpleRenderer RoadRenderer = new SimpleRendererClass();
            ISimpleLineSymbol RoadLineSymbol = new SimpleLineSymbol();　　//新建线状样式
            IRgbColor RoadColor = new RgbColor();
            RoadLineSymbol.Style = esriSimpleLineStyle.esriSLSDash;
            RoadColor.Green = 0;
            RoadColor.Red = 0;
            RoadColor.Blue = 0;
            RoadLineSymbol.Width = 1;
            RoadLineSymbol.Color = RoadColor;
            RoadRenderer.Symbol = (ISymbol)RoadLineSymbol;
            RoadLayer.Renderer = (IFeatureRenderer)RoadRenderer;
            //刷新地图
            m_mapControl.ActiveView.Refresh();
            m_tocControl.SetBuddyControl(m_mapControl.Object);
            m_tocControl.Refresh();
        }



       //使用TextElment绘制标注, fieldName为要绘制的属性
        public static void AddLable(AxMapControl axMapControl, ILayer layer, string fieldName)
        {
            IRgbColor LabelColor = null;
            IRgbColor WaterLabelColor = new RgbColorClass()
            {
                Red = 0,
                Blue = 255,
                Green = 0
            };
            IRgbColor RoadLabelColor = new RgbColorClass()
            {
                Red = 255,
                Blue = 255,
                Green = 255
            };
            IRgbColor InhabitLabelColor = new RgbColorClass()
            {
                Red = 0,
                Blue = 255,
                Green = 255
            };
            IRgbColor GreenLabelColor = new RgbColorClass()
            {
                Red = 0,
                Blue = 0,
                Green = 255
            };
            IRgbColor DistrictLabelColor = new RgbColorClass()
            {
                Red = 255,
                Blue = 0,
                Green = 255
            };

            IFontDisp pFont = new StdFont()
            {
                Name = "宋体",
                Bold=true,
                Size = 5
            } as IFontDisp;
            
            if (layer.Name == "水系")
                LabelColor = WaterLabelColor;
            if (layer.Name == "交通")
                LabelColor = RoadLabelColor;
            if (layer.Name == "居民地")
                LabelColor = InhabitLabelColor;
            if (layer.Name == "植被覆盖a")
                LabelColor = GreenLabelColor;
            if (layer.Name == "行政区")
                LabelColor = DistrictLabelColor;
            ITextSymbol pTextSymbol = new TextSymbolClass()
            {

                Color = LabelColor,
                Font = pFont,
                Size = 11
            };
            IGraphicsContainer pGraContainer = axMapControl.Map as IGraphicsContainer;
            //遍历要标注的要素
            IFeatureLayer pFeaLayer = layer as IFeatureLayer;
            IFeatureClass pFeaClass = pFeaLayer.FeatureClass;
            IFeatureCursor pFeatCur = pFeaClass.Search(null, false);
            IFeature pFeature = pFeatCur.NextFeature();
            int index = pFeature.Fields.FindField(fieldName);//要标注的字段的索引
            IEnvelope pEnv = null;
            ITextElement pTextElment = null;
            IElement pEle = null;
            while (pFeature != null)
            {
                //使用地理对象的中心作为标注的位置
                pEnv = pFeature.Extent;
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(pEnv.XMin + pEnv.Width * 0.5, pEnv.YMin + pEnv.Height * 0.5);

                pTextElment = new TextElementClass()
                {
                    Symbol = pTextSymbol,
                    ScaleText = true,
                    Text = pFeature.get_Value(index).ToString()
                };
                pEle = pTextElment as IElement;
                pEle.Geometry = pPoint;
                //添加标注
                pGraContainer.AddElement(pEle, 0);
                pFeature = pFeatCur.NextFeature();
                
            }
            (axMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, axMapControl.Extent);
            
        }

        public static void DeleteLabel(AxMapControl axMapControl, ILayer layer)
        {
            IGraphicsContainer pGraContainer = axMapControl.Map as IGraphicsContainer;
            pGraContainer.DeleteAllElements();
            ////遍历要标注的要素
            //IFeatureLayer pFeaLayer = layer as IFeatureLayer;
            //IFeatureClass pFeaClass = pFeaLayer.FeatureClass;
            //IFeatureCursor pFeatCur = pFeaClass.Search(null, false);
            //IFeature pFeature = pFeatCur.NextFeature();
            //IEnvelope pEnv = null;
            
            //IElement pEle = null;
            //while (pFeature != null)
            //{
            //    //使用地理对象的中心作为标注的位置
            //    pEnv = pFeature.Extent;
            //    IPoint pPoint = new PointClass();
            //    pPoint.PutCoords(pEnv.XMin + pEnv.Width * 0.5, pEnv.YMin + pEnv.Height * 0.5);

            //    pEle = pGraContainer.LocateElements(pPoint,10) as IElement;
            //    //pEle.Geometry = pPoint;
            //    //添加标注
            //    if (pEle != null)
            //    {
            //        pGraContainer.DeleteElement(pEle);
            //        pGraContainer.UpdateElement(pEle);
            //    }
                
            //    pFeature = pFeatCur.NextFeature();
            //}
            (axMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, axMapControl.Extent);
            axMapControl.Refresh();
        }
    }
}
