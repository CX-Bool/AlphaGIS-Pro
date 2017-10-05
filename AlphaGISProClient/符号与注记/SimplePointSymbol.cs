/*************************************************************
*         文件名：SimplePointSymbol.cs                       *
*         作者：赵聪     学号：1300012453                    *
*         功能：用于设定点符号的符号类                       *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AlphaGISProClient
{
    /// <summary>
    /// 点符号的8种类型
    /// </summary>
    [Serializable]
    public enum PointSymbolType
    {
        Circle=0,
        SolidCircle=1,
        Rectangle=2,
        SolidRectangle=3,
        Triangle=4,
        SolidTriangle=5,
        CircleDot=6,
        DoubleCircle=7,
    }
    /// <summary>
    /// 点的样式
    /// </summary>
    public class SimplePointSymbol:Symbol
    {
        #region 字段
        private PointSymbolType _PointSymbolType;//判断点符号的类型
        private double _Size;
        private double _OffsetX, _OffsetY;//不知道干吗用
        private double _Angle;//不知道干嘛用
        private System.Drawing.Color _Color;
        #endregion

        #region 构造函数
        public SimplePointSymbol(PointSymbolType pointSymbolType, double size, Color color)
        {
            _SymbolColor = color;
            _SymbolType = GeometryType.PointD;
            _PointSymbolType = pointSymbolType;
            _Color = color;
            _OffsetX = 0;
            _OffsetY = 0;
            _Angle = 0;
            _Size = size;
        }
        public SimplePointSymbol(PointSymbolType pointSymbolType, double size,double offsetx,double offsety,double angle,System.Drawing.Color color)
        {
            _SymbolColor = color;
            _SymbolType = GeometryType.PointD;
            _PointSymbolType = pointSymbolType;
            _Size = size;
            _OffsetX = offsetx;
            _OffsetY = offsety;
            _Angle = angle;
            _Color = color;
        }

        #endregion

        #region 属性
        
        /// <summary>
        /// 设置点要素类型
        /// </summary>
        public PointSymbolType PointSymbolType
        {
            get { return _PointSymbolType; }
            set { _PointSymbolType = value; }
        }

        /// <summary>
        /// 设置点要素大小
        /// </summary>
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        /// <summary>
        /// 设置X方向上的偏移量
        /// </summary>
        public double OffsetX
        {
            get { return _OffsetX; }
            set { _OffsetX = value; }
        }
        /// <summary>
        /// 设置Y方向上的偏移量
        /// </summary>
        public double OffsetY
        {
            get { return _OffsetY; }
            set { _OffsetY = value; }
        }
        /// <summary>
        /// 设置偏转角度
        /// </summary>
        public double Angle
        {
            get { return _Angle; }
            set { _Angle = value; }
        }
        /// <summary>
        /// 设置颜色
        /// </summary>
        public System.Drawing.Color Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                _SymbolColor = value;
            }
        }
        #endregion

        #region 方法
        //在g上根据不同样式来画点
        public void DrawIn(Graphics g,Pen pen, SolidBrush solidBrush,PointF centerPoint)
        {
            
            pen.Color = this.Color;
            solidBrush.Color = this.Color;

            switch (this.PointSymbolType)
            {

                case PointSymbolType.Circle:
                    
                    g.DrawEllipse(pen, centerPoint.X, centerPoint.Y, (float)this.Size, (float)this.Size);
                    break;
                case PointSymbolType.SolidCircle:
                    g.FillEllipse(solidBrush, centerPoint.X, centerPoint.Y, (float)this.Size, (float)this.Size);
                    break;
                case PointSymbolType.Rectangle:
                    g.DrawRectangle(pen, centerPoint.X - (float)this.Size / 2, centerPoint.Y - (float)this.Size / 2, (float)this.Size, (float)this.Size);
                    break;
                case PointSymbolType.SolidRectangle:
                    g.FillRectangle(solidBrush, centerPoint.X - (float)this.Size / 2, centerPoint.Y - (float)this.Size / 2, (float)this.Size, (float)this.Size);
                    break;
                case PointSymbolType.Triangle:
                    PointF[] points = new PointF[3];
                    points[0] = new PointF((float)centerPoint.X, (float)(centerPoint.Y - 1.154 * (float)this.Size));
                    points[1] = new PointF((float)(centerPoint.X - (float)this.Size), (float)(centerPoint.Y + 0.577 * (float)this.Size));
                    points[2] = new PointF((float)(centerPoint.X + (float)this.Size), (float)(centerPoint.Y + 0.577 * (float)this.Size));
                    g.DrawPolygon(pen, points);
                    break;
                case PointSymbolType.SolidTriangle:
                    PointF[] points2 = new PointF[3];
                    points2[0] = new PointF((float)centerPoint.X, (float)(centerPoint.Y - 1.154 * (float)this.Size));
                    points2[1] = new PointF((float)(centerPoint.X - (float)this.Size), (float)(centerPoint.Y + 0.577 * (float)this.Size));
                    points2[2] = new PointF((float)(centerPoint.X + (float)this.Size), (float)(centerPoint.Y + 0.577 * (float)this.Size));
                    g.FillPolygon(solidBrush, points2);
                    break;
                case PointSymbolType.CircleDot:
                    g.DrawEllipse(pen, centerPoint.X, centerPoint.Y, (float)this.Size, (float)this.Size);
                    g.FillEllipse(solidBrush, centerPoint.X + (float)this.Size / 8 * 3, centerPoint.Y + (float)this.Size / 8 * 3, (float)this.Size / 4, (float)this.Size / 4);
                    break;
                case PointSymbolType.DoubleCircle:
                    g.DrawEllipse(pen, centerPoint.X, centerPoint.Y, (float)this.Size, (float)this.Size);
                    g.DrawEllipse(pen, centerPoint.X, centerPoint.Y, (float)this.Size / 2, (float)this.Size / 2);
                    break;
            }
        }
        //简便设置一下整个symbol
        public void Set(SimplePointSymbol sSimplePointSymbol)
        {
            this._PointSymbolType = sSimplePointSymbol.PointSymbolType;
            this._Size = sSimplePointSymbol.Size;
            
            this._OffsetX = sSimplePointSymbol.OffsetX;
            this._OffsetY = sSimplePointSymbol.OffsetY;
            this._Angle = sSimplePointSymbol.Angle;
            this._Color = sSimplePointSymbol.Color;
        }
        #endregion
    }
}
