/*************************************************************
*        文件名：MultiPolygon.cs                             *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义多多边形类，也是多边形图层中储存的要素    *
*        支持判断点是否在多多边形内（点选），平移，编辑节点等*      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    [Serializable]
    public class MultiPolygon : Geometry
    {
        #region 字段

        private List<Polygon> _Polygons = new List<Polygon>();


        #endregion

        #region 构造函数
        /// <summary>
        /// 复杂的多边形（由多个简单多边形组成）
        /// </summary>
        public MultiPolygon()
        {
            GeoType = GeometryType.MultiPolygon;
        }
        public MultiPolygon(Polygon[] polygons)
        {
            _Polygons.AddRange(polygons);
            GeoType = GeometryType.MultiPolygon;
        }
        #endregion

        #region 属性

        public Polygon[] Polygons
        {
            get { return _Polygons.ToArray(); }
            set
            {
                _Polygons.Clear();
                _Polygons.AddRange(value);
            }
        }
        /// <summary>
        /// 返回顺时针的多边形数
        /// </summary>
        public int ClockwisePolygonCount
        {
            get { return GetClockwisePolygonCount(); }
        }

        /// <summary>
        /// 返回所有的多边形数
        /// </summary>
        public int PolygonCount
        {
            get { return _Polygons.Count; }
        }

        #endregion

        #region  方法
        /// <summary>
        /// 获取指定多边形
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Polygon GetPolygon(int index)
        {
            return _Polygons[index];
        }
        /// <summary>
        /// 设置指定多边形
        /// </summary>
        /// <param name="index"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public bool SetPolygon(int index, Polygon polygon)
        {
            if (index < 0 || index > _Polygons.Count - 1)
                return false;
            else
            {
                _Polygons[index] = polygon;
                return true;
            }
        }
        /// <summary>
        /// 添加多边形
        /// </summary>
        /// <param name="polygon"></param>
        public void Add(Polygon polygon)
        {
            _Polygons.Add(polygon);
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _Polygons.Clear();
        }
        /// <summary>
        /// 复制多边形
        /// </summary>
        /// <returns></returns>
        public MultiPolygon Clone()
        {
            int sPolygonCount = _Polygons.Count;
            MultiPolygon sMultiPolygon = new MultiPolygon();
            for (int i = 0; i < sPolygonCount; i++)
            {
                Polygon sPolygon = _Polygons[i].Clone();
                sMultiPolygon._Polygons.Add(sPolygon);
            }
            return sMultiPolygon;
        }


        public override Rectangle GetMBR()
        {
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            for (int i = 0; i < _Polygons.Count; i++)
            {
                if (_Polygons[i].Ring == RingValue.Clockwise) //逆时针的包含在顺时针的多边形内，因此只要计算顺时针的
                {
                    minX = Math.Min(_Polygons[i].GetMBR().MinX, minX);
                    maxX = Math.Max(_Polygons[i].GetMBR().MaxX, maxX);
                    minY = Math.Min(_Polygons[i].GetMBR().MinY, minY);
                    maxY = Math.Max(_Polygons[i].GetMBR().MaxY, maxY);
                }

            }
            return new Rectangle(minX, maxX, minY, maxY);
        }
        //判断点是否在多边形内
        public bool IsContain(PointD p)
        {
            foreach(Polygon sPolygon in _Polygons)
            {
                if (sPolygon.IsContain(p))
                    return true;
            }
            return false;
        }
        //整体平移
        public override void Translation(double deltaX, double deltaY)
        {
            foreach (Polygon sPolygon in _Polygons)
            {
                sPolygon.Translation(deltaX, deltaY);
            }
        }
        //平移节点
        public override void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            foreach (Polygon sPolygon in _Polygons)
            {
                sPolygon.MoveVertex(selectPoint, endPoint);
            }
        }
        #endregion
        #region 私有函数
        private int GetClockwisePolygonCount()
        {
            int count = 0;
            for (int i = 0; i < _Polygons.Count; i++)
            {
                if (_Polygons[i].Ring == RingValue.Clockwise)
                    count++;
            }
            return count;
        }
        #endregion
    }
}
