/*************************************************************
*        文件名：PointD.cs                                   *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义点类，是所有线、面的基本要素，            *
*        也是线图层中储存的要素                              *
*        支持判断点与点是否重合，平移，编辑节点等            *      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    /// <summary>
    /// 点类
    /// </summary>
    public class PointD: Geometry
    {
        #region 属性

        private double _X;
        private double _Y;
        

        #endregion

        # region 构造函数

        public PointD()
        {
            _MBR = new Rectangle(this.X, this.X, this.Y, this.Y);
            GeoType = GeometryType.PointD;
        }

        public PointD(double x, double y)
        {
            _X = x;
            _Y = y;
            GeoType = GeometryType.PointD;
            _MBR = new Rectangle(this.X, this.X, this.Y, this.Y);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取设置X坐标
        /// </summary>
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }
        /// <summary>
        /// 获取设置y坐标
        /// </summary>
        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        #endregion

        
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public PointD Clone()
        {
            return new PointD(this.X, this.Y);
        }

        public override Rectangle GetMBR()
        {
            return new Rectangle(this.X,this.X,this.Y,this.Y);
        }
        public bool isCoincide(PointD p)//判断是否重合
        {
            return (Math.Sqrt((p.X - this._X) * (p.X - this._X) + (p.Y - this._Y) * (p.Y - this._Y)) < Geometry.ER);
        }
        public double DistanceTo(PointD p)
        {
            return Math.Sqrt((p.X - this._X) * (p.X - this._X) + (p.Y - this._Y) * (p.Y - this._Y)) ;
        }
        public override void Translation(double deltaX,double deltaY)
        {
            this._X += deltaX;
            this._Y += deltaY;
        }
        public override void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            if (this.isCoincide(selectPoint))
            {
                this._X = endPoint.X;
                this._Y = endPoint.Y;
            }
        }
    }
}
