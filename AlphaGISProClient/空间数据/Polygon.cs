/*************************************************************
*        文件名：Polygon.cs                                  *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义简单的多边形类，只有一个环                *
*        支持判断点是否在多边形内上（点选），平移，编辑节点等*      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    public enum RingValue
    {
        Clockwise=0,    //顺时针
        AntiClockwise=1 //逆时针
    };
    /// <summary>
    /// 简单的多边形（只有一个环）
    /// </summary>
    [Serializable]
    public class Polygon:Geometry
    {
        #region 字段

        private List<PointD> _Points = new List<PointD>();
        
        private RingValue ring = RingValue.Clockwise;   //判断是顺时针还是逆时针（用于复杂的多边形）

        #endregion

        #region 构造函数
        //这个还没想好，应该没什么用
        public Polygon()
        {
            GeoType = GeometryType.Polygon;
        }
        //用pointD数组来新建简单多边形
        public Polygon(PointD[] points)
        {
            _Points.AddRange(points);
            GeoType = GeometryType.Polygon;
        }
        #endregion

        #region 属性

        public PointD[] Points
        {
            get { return _Points.ToArray(); }
            set
            {
                _Points.Clear();
                _Points.AddRange(value);
            }
        }

        public int PointCount
        {
            get { return _Points.Count; }
        }

        public RingValue Ring
        {
            get { return ring; }
            set { ring = value; }
        }

        #endregion

        #region  方法
        /// <summary>
        /// 获取指定顶点坐标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PointD GetPoint(int index)
        {
            return _Points[index];
        }
        /// <summary>
        /// 设置指定顶点坐标
        /// </summary>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetPoint(int index,PointD point)
        {
            if (index < 0 || index > _Points.Count - 1)
                return false;
            else
            {
                _Points[index] = point;
                return true;
            }
        }
        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="point"></param>
        public void Add(PointD point)
        {
            _Points.Add(point);
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _Points.Clear();
        }
        /// <summary>
        /// 复制多边形
        /// </summary>
        /// <returns></returns>
        public Polygon Clone()
        {
            int sPointCount = _Points.Count;
            Polygon sPolygon = new Polygon();
            for (int i = 0; i < sPointCount; i++)
            {
                PointD sPoint = new PointD(_Points[i].X, _Points[i].Y);
                sPolygon._Points.Add(sPoint);
            }
            return sPolygon;
        }

        /// <summary>
        /// 最小外包矩形
        /// </summary>
        /// <returns></returns>
        public override Rectangle GetMBR()
        {
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            for(int i = 0; i < _Points.Count; i++)
            {
                minX = Math.Min(_Points[i].X, minX);
                maxX = Math.Max(_Points[i].X, maxX);
                minY = Math.Min(_Points[i].Y, minY);
                maxY = Math.Max(_Points[i].Y, maxY);
            }
            return new Rectangle(minX, maxX, minY, maxY);
        }

        //判断点p向右的射线是否与线段start end 相交
        public bool IsRayIntersectsSegmeng(PointD p,PointD start,PointD end)
        {
            if (start.Y == end.Y)
                return false;
            if (start.Y > p.Y && end.Y > p.Y)
                return false;
            if (start.Y == p.Y && end.Y > p.Y)
                return false;
            if (start.Y > p.Y && end.Y == p.Y)
                return false;
            if (start.Y < p.Y && end.Y < p.Y)
                return false;
            if (start.X < p.X && end.X < p.X)
                return false;
            double x = end.X - (end.X - start.X) * (end.Y - start.Y) / (end.Y - p.Y);
            if (x < p.X)
                return false;
            else
                return true;

        }
        //判断点是否在多边形内
        public bool IsContain(PointD p)
        {
            int sNum = _Points.Count;
            int intersectNum = 0;
            for(int i = 0; i < sNum; i++)
            {
                if (this.IsRayIntersectsSegmeng(p, _Points[i % sNum], _Points[(i + 1) % sNum]))
                    intersectNum++;
            }
            if (intersectNum % 2 == 1)
                return true;
            else
                return false;
        }
        public override void Translation(double deltaX, double deltaY)
        {
            foreach (PointD sPointD in _Points)
            {
                sPointD.Translation(deltaX, deltaY);
            }
        }
        
        public override void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            foreach(PointD sPoint in _Points)
            {
                sPoint.MoveVertex(selectPoint, endPoint);
            }
        }
        #endregion
    }
}
