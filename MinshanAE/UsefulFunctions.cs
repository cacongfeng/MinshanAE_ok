using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace MinshanAE
{
    class UsefulFunctions
    {
        /// <summary>
        /// 根据图层的名称获取相应的图层
        /// </summary>
        /// <param name="strLyrName">图层名称字符串</param>
        /// <returns>ILayer</returns>
        public static ILayer GetLayerByName(AxMapControl m_mapControl,string strLyrName)
        {
            ILayer pLayer = null;
            bool bFindLayer = false; ;
            for (int i = 0; i < m_mapControl.Map.LayerCount; i++)
            {
                pLayer = m_mapControl.Map.get_Layer(i);
                if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                {
                    ICompositeLayer pComLyr = pLayer as ICompositeLayer;
                    for (int j = 0; j < pComLyr.Count; j++)
                    {
                        pLayer = pComLyr.get_Layer(j);
                        if (pLayer.Name.Equals(strLyrName))
                        {
                            bFindLayer = true;
                            break;
                        }
                        else
                        {
                            pLayer = null;
                        }
                    }
                }
                else
                {
                    if (pLayer.Name == strLyrName)
                    {
                        bFindLayer = true;
                    }
                    else
                    {
                        pLayer = null;
                    }
                }
                if (bFindLayer)
                {
                    break;
                }
            }
            return pLayer;
        }

        /// <summary>
        /// 根据类型高亮显示选择类型
        /// </summary>
        /// <param name="Type">类型</param>
        public static void SelectFeatures(AxMapControl m_mapControl,string Type)
        {
            ILayer layer=GetLayerByName(m_mapControl,"植被覆盖");
            IFeatureLayer pFLayer=layer as IFeatureLayer;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = "NAME1="+"'"+Type+"'";
            IFeatureSelection pFeatureSelection = pFLayer as IFeatureSelection;

            int iSelectedFeatureCount = pFeatureSelection.SelectionSet.Count;
            esriSelectionResultEnum selectMethod = esriSelectionResultEnum.esriSelectionResultNew;
            pFeatureSelection.SelectFeatures(pQueryFilter, selectMethod, false);

            m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
    }
}
