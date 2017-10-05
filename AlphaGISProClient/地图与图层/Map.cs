/*************************************************************
*         文件名：Map.cs                                     *
*         作者：陈旭     学号：1300012421                    *
*         功能：地图类，管理图层列表，支持自由移动顺序       *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlphaGISProClient
{
    //地图
    
    public class Map
    {
        #region 字段
        private string name;    //地图名称
        private List<Layer> layerlist; //图层列表，0号元素在最上
        #endregion

        #region 属性
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Layer> Layerlist
        {
            get { return layerlist; }
        }
        #endregion

        #region 方法

        public void SaveToString(StreamWriter sw)
        {
            sw.WriteLine(this.name);
            sw.WriteLine(this.Layerlist.Count);
            foreach (Layer sLayer in layerlist)
            {
                sLayer.SaveToString(sw);
            }
            
        }
        //构造函数
        public Map(string mapname, List<Layer> layerlist)
        {
            this.name = mapname;
            this.layerlist = layerlist;
            //todo
        }

        //读取地图工程文件
        public bool Load(string mapfilepath)
        {
            //todo
            return true;
        }
        //保存地图工程文件
        public bool Save(string mapfilepath)
        {
            //todo
            return true;
        }


        // 用户向向该map中添加一个已存在的layer
        public string addLayer(Layer layer)
        {
            layerlist.Add(layer);
            return layer.Name;
        }

        //获取名为layername的图层
        public Layer GetLayerByName(string layername)
        {
            if (layername != null)
            {
                for (int i = 0; i < layerlist.Count; i++)
                {
                    if (layerlist[i].Name.Equals(layername))
                    {
                        return layerlist[i];
                    }
                }
            }
            return null;
        }
        //移除名为layername的图层
        public bool RemoveLayer(string layername)
        {
            Layer layer = GetLayerByName(layername);
            if (layer != null)
            {
                layerlist.Remove(layer);
                return true;
            }
            return false;
        }

        //移动指定名称的图层至指定位置
        public bool MoveLayerTo(string layername, int targetindex)
        {
            if (targetindex < 0 || targetindex > layerlist.Count - 1)
                return false;
            else
            {
                Layer layer = GetLayerByName(layername);
                if (layer != null)
                {
                    layerlist.Remove(layer);
                    layerlist.Insert(targetindex, layer);
                    return true;
                }
                return false;
            }
        }

        //移至底端
        public void MoveLayerToBottom(string layername)
        {
            MoveLayerTo(layername, layerlist.Count - 1);
        }

        //移至顶端
        public void MoveLayerToTop(string layername)
        {
            MoveLayerTo(layername, 0);
        }

        //全部改变顺序
        public void ChangeLayerOrder(List<string> layernamelist)
        {
            List<Layer> newlayerlist = new List<Layer>();
            for (int i = 0; i < layernamelist.Count; i++)
            {
                newlayerlist.Add(this.GetLayerByName(layernamelist[i]));
            }
            this.layerlist = newlayerlist;
        }

        
        
        //返回整个地图的边界，用于显示全图功能
        public Rectangle EnvelopOfMap()
        {
            if (layerlist.Count == 0)
                return new Rectangle(0, 0, 0, 0);
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            foreach (Layer layer in layerlist)
            {
                Rectangle rect = layer.EnvelopOfLayer();
                //
                minX = Math.Min(rect.MinX, minX);
                maxX = Math.Max(rect.MaxX, maxX);
                minY = Math.Min(rect.MinY, minY);
                maxY = Math.Max(rect.MaxY, maxY);
            }
            return new Rectangle(minX, maxX, minY, maxY);
        }
        
        #endregion
    }
}
