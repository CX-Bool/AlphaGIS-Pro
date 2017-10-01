/*************************************************************
*        文件名：MultiPolyline.cs                            *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义多线类，也是线图层中储存的要素            *
*        支持判断点是否在多线上（点选），平移，编辑节点等    *      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{

    /// <summary>
    /// 与shp格式匹配的折线
    /// </summary>
    /*public class MultiPolyline : Geometry
    {
        #region 字段
        
        private double[] _Box;//边界盒
        private int _NumParts;//部分的数目
        private int _NumPoints;//点的总数目
        private List<int> _Parts = new List<int>();//在部分中第一个点的索引
        private List<PointD> _Points = new List<PointD>();//所有部分的点
        #endregion
        #region 属性
        public double[] Box
        {
            get { return _Box; }
            set { _Box = value; }
        }
        public int NumParts
        {
            get { return _NumParts; }
            set { _NumParts = value; }
        }
        public int NumPoints
        {
            get { return _NumPoints; }
            set { _NumPoints = value; }
        }
        public List<int> Parts
        {
            get { return _Parts; }
            set { _Parts = value; }
        }
        public List<PointD> Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
        #endregion
        #region 方法
        #endregion

        public MultiPolyline()
        {
            this.geoType = GeometryType.MultiPolyline;
        }

        public override List<int> PartsIndex()
        {
            return Parts;
        }

        public override Rectangle RefreshMBR()
        {
            return new Rectangle(Box[0], Box[1], Box[2], Box[3]);
        }
    }*/
    public class MultiPolyline:Geometry
    {
        #region 字段

        private List<Polyline> _Polylines = new List<Polyline>();
        

        #endregion

        #region 构造函数

        public MultiPolyline()
        {
            GeoType = GeometryType.MultiPolyline;
        }
        public MultiPolyline(Polyline[] polylines)
        {
            _Polylines.AddRange(polylines);
            GeoType = GeometryType.MultiPolyline;
        }
        #endregion

        #region 属性

        public Polyline[] Polylines
        {
            get { return _Polylines.ToArray(); }
            set
            {
                _Polylines.Clear();
                _Polylines.AddRange(value);
            }
        }

        public int PolylineCount
        {
            get { return _Polylines.Count; }
        }

        #endregion

        #region  方法
        /// <summary>
        /// 获取指定线
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Polyline GetPolyline(int index)
        {
            return _Polylines[index];
        }
        /// <summary>
        /// 设置指定线
        /// </summary>
        /// <param name="index"></param>
        /// <param name="polyline"></param>
        /// <returns></returns>
        public bool SetPolygon(int index, Polyline polyline)
        {
            if (index < 0 || index > _Polylines.Count - 1)
                return false;
            else
            {
                _Polylines[index] = polyline;
                return true;
            }
        }
        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="polyline"></param>
        public void Add(Polyline polyline)
        {
            _Polylines.Add(polyline);
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _Polylines.Clear();
        }
        /// <summary>
        /// 复制多边形
        /// </summary>
        /// <returns></returns>
        public MultiPolyline Clone()
        {
            int sPolylineCount = _Polylines.Count;
            MultiPolyline sMultiPolyline = new MultiPolyline();
            for (int i = 0; i < sPolylineCount; i++)
            {
                Polyline sPolyline = _Polylines[i].Clone();
                sMultiPolyline._Polylines.Add(sPolyline);
            }
            return sMultiPolyline;
        }


        public override Rectangle GetMBR()
        {
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            for (int i = 0; i < _Polylines.Count; i++)
            {
               
                minX = Math.Min(_Polylines[i].GetMBR().MinX, minX);
                maxX = Math.Max(_Polylines[i].GetMBR().MaxX, maxX);
                minY = Math.Min(_Polylines[i].GetMBR().MinY, minY);
                maxY = Math.Max(_Polylines[i].GetMBR().MaxY, maxY);
                

            }
            return new Rectangle(minX, maxX, minY, maxY);
        }
        public PointD GetMarkPoint()
        {
            int maxIndex = 0;
            double maxLength = _Polylines[maxIndex].GetLength();
            for (int i = 1; i < _Polylines.Count; i++)
            {
                if (_Polylines[i].GetLength() > maxLength)
                {
                    maxIndex = i;
                    maxLength = _Polylines[maxIndex].GetLength();
                }                  
            }
            PointD startPoint = _Polylines[maxIndex].Points[0];
            PointD endPoint = _Polylines[maxIndex].Points[_Polylines[maxIndex].PointCount - 1];
            return new PointD((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
        }
        public bool IsContain(PointD p)
        {
            foreach(Polyline sPolyline in _Polylines)
            {
                if (sPolyline.IsContain(p))
                    return true;
            }
            return false;
        }
        public override void Translation(double deltaX, double deltaY)
        {
            foreach (Polyline sPolyline in _Polylines)
            {
                sPolyline.Translation(deltaX, deltaY);
            }
        }
        public override void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            foreach (Polyline sPolyline in _Polylines)
            {
                sPolyline.MoveVertex(selectPoint, endPoint);
            }
        }
        #endregion
    }
}
