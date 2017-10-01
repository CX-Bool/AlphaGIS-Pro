/*************************************************************
*        文件名：Polyline.cs                                 *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义简单折线类，要能够一笔画出                *
*        支持判断点是否在线上（点选），平移，编辑节点等      *      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{

    
    public class Polyline:Geometry
    {
        
        #region 字段

        private List<PointD> _Points = new List<PointD>();
        

        #endregion

        #region 构造函数
        //简单线（一笔能画出）
        public Polyline()
        {
            GeoType = GeometryType.Polyline;
        }
        public Polyline(PointD[] points)
        {
            _Points.AddRange(points);
            GeoType = GeometryType.Polyline;
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
        public bool SetPoint(int index, PointD point)
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
        public Polyline Clone()
        {
            int sPointCount = _Points.Count;
            Polyline sPolyline = new Polyline();
            for (int i = 0; i < sPointCount; i++)
            {
                PointD sPoint = new PointD(_Points[i].X, _Points[i].Y);
                sPolyline._Points.Add(sPoint);
            }
            return sPolyline;
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
            for (int i = 0; i < _Points.Count; i++)
            {
                minX = Math.Min(_Points[i].X, minX);
                maxX = Math.Max(_Points[i].X, maxX);
                minY = Math.Min(_Points[i].Y, minY);
                maxY = Math.Max(_Points[i].Y, maxY);
            }
            return new Rectangle(minX, maxX, minY, maxY);
        }
        public double GetLength()
        {
            double length = 0;
            for(int i = 0; i < _Points.Count-1; i++)
            {
                length += Math.Sqrt(
                    (_Points[i].X - _Points[i + 1].X) * (_Points[i].X - _Points[i + 1].X) +
                    (_Points[i].Y - _Points[i + 1].Y) * (_Points[i].Y - _Points[i + 1].Y)
                    );
            }
            return length;
        }
        #endregion
        public bool IsContain(PointD p)
        {
            for(int i = 0; i < _Points.Count - 1; i++)
            {
                if (MinDistance(p, _Points[i], _Points[i + 1]) < Geometry.ER)
                {
                    return true;
                }
            }
            return false;
        }
        private double MinDistance(PointD p ,PointD start,PointD end)
        {
            double neiji = (p.X - start.X) * (end.X - start.X) + (p.Y - start.Y) * (end.Y - start.Y);
            double ab2 = (end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y);
            double d = neiji / ab2;
            PointD near = null;
            if (d < 0)
                near = start;
            else if (d > 1)
                near = end;
            else
            {
                double x = start.X + d * (end.X - start.X);
                double y = start.Y + d * (end.Y - start.Y);
                near = new PointD(x, y);
            }
            return p.DistanceTo(near);
        }

        public override void Translation(double deltaX, double deltaY)
        {
            foreach(PointD sPointD in _Points)
            {
                sPointD.Translation(deltaX, deltaY);
            }
        }
        public override void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            foreach (PointD sPoint in _Points)
            {
                sPoint.MoveVertex(selectPoint, endPoint);
            }
        }
    }
}
