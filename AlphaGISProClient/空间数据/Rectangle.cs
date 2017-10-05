/*************************************************************
*        文件名：Rectangle.cs                                *
*        作者：陈旭     学号：1300012421                     *
*        功能：定义矩形类，左下角为原点                      *
*        矩形类（用于最小外包矩形、显示范围、拉框查询等等）  *      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    /// <summary>
    /// 矩形类（用于最小外包矩形、显示范围、拉框查询等等）左下角为原点
    /// </summary>
    [Serializable]
    public class Rectangle
    {
        #region 属性

        private double _MinX, _MaxX, _MinY, _MaxY;

        #endregion

        # region 构造函数
        /// <summary>
        /// 以最小、最大x、y值为参数创建矩形
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        public Rectangle(double minX, double maxX, double minY, double maxY)
        {
            if (minX > maxX || minY > maxY)
                throw new Exception("Invalid rectangle.");
            _MinX = minX;
            _MaxX = maxX;
            _MinY = minY;
            _MaxY = maxY;
        }
        /// <summary>
        /// 以左上角点、宽度、高度为参数创建矩形
        /// </summary>
        /// <param name="leftTop"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(PointD leftTop,double width,double height)
        {
            if (width < 0 || height < 0)
                throw new Exception("Invalid rectangle.");
            _MinX = leftTop.X;
            _MaxX = leftTop.X + width;
            _MinY = leftTop.Y - height;
            _MaxY = leftTop.Y;
        }
        #endregion

        #region 属性

        public double MinX
        {
            get { return _MinX; }
        }
        public double MaxX
        {
            get { return _MaxX; }
        }
        public double MinY
        {
            get { return _MinY; }
        }
        public double MaxY
        {
            get { return _MaxY; }
        }
        public double Width
        {
            get { return _MaxX - _MinX; }
        }
        public double Height
        {
            get { return _MaxY - _MinY; }
        }

        #endregion
        /// <summary>
        /// 返回外包矩形的中心（写注记时用）
        /// </summary>
        /// <returns></returns>
        public PointD GetCenter()
        {
            return new PointD((MaxX + MinX) / 2, (MaxY + MinY) / 2);
        }
        /// <summary>
        /// 判断矩形是否包含点（框选时用）
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsContainPoint(PointD point)
        {
            if (point.X < _MinX) return false;
            if (point.Y < _MinY) return false;
            if (point.X > _MaxX) return false;
            if (point.Y > _MaxY) return false;
            return true;
        }
    }
}
