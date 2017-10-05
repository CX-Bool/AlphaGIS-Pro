/*************************************************************
*         文件名：SimpleFillSymbol.cs                        *
*         作者：赵聪     学号：1300012453                    *
*         功能：用于设定面符号的符号类                       *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class SimpleFillSymbol:Symbol
    {
        #region 字段
        private int _FillStyle;//填充类型（透明还是填充）
        private System.Drawing.Color _FillColor;//填充颜色
        private int _OutLineStyle;//边界线形,0表示实线，1表示虚线
        private double _OutLineWidth;//边界线宽
        private System.Drawing.Color _OutLineColor;//边界颜色
        #endregion
        #region 构造函数
        public SimpleFillSymbol(System.Drawing.Color fillcolor, double outlinewidth, System.Drawing.Color outlinecolor)
        {
            _SymbolType = GeometryType.MultiPolygon;
            _SymbolColor = fillcolor;
            _FillStyle = 1;
            _FillColor = fillcolor;
            _OutLineStyle = 0;
            _OutLineWidth = outlinewidth;
            _OutLineColor = outlinecolor;

        }
        public SimpleFillSymbol(int fillstyle,System.Drawing.Color fillcolor,
            int outlinestyle,double outlinewidth,System.Drawing.Color outlinecolor)
        {
            _SymbolColor = fillcolor;
            _SymbolType = GeometryType.MultiPolygon;
            _FillStyle = fillstyle;
            _FillColor = fillcolor;
            _OutLineStyle = outlinestyle;
            _OutLineWidth = outlinewidth;
            _OutLineColor = outlinecolor;
        }
        #endregion
        #region 属性
        
        /// <summary>
        /// 获取和设置填充类型
        /// </summary>
        public int FillStyle
        {
            get { return _FillStyle; }
            set { _FillStyle = value; }
        }
        /// <summary>
        /// 获取和设置填充颜色
        /// </summary>
        public System.Drawing.Color FillColor
        {
            get { return _FillColor; }
            set { _FillColor = value;
                _SymbolColor = value;
            }
        }
        /// <summary>
        /// 获取和设置边界线型，0表示实线，1表示虚线
        /// </summary>
        public int OutLineStyle
        {
            get { return _OutLineStyle; }
            set { _OutLineStyle = value; }
        }
        /// <summary>
        /// 获取和设置边界线宽
        /// </summary>
        public double OutLineWidth
        {
            get { return _OutLineWidth; }
            set { _OutLineWidth = value; }
        }
        /// <summary>
        /// 获取和设置边界色
        /// </summary>
        public System.Drawing.Color OutLineColor
        {
            get { return _OutLineColor; }
            set { _OutLineColor = value; }
        }
        #endregion
        public void Set(SimpleFillSymbol sSimpleFillSymbol)
        {
            this.FillColor = sSimpleFillSymbol.FillColor;
            this.OutLineWidth = sSimpleFillSymbol.OutLineWidth;
            this.OutLineColor = sSimpleFillSymbol.OutLineColor;
            this.FillStyle = sSimpleFillSymbol.FillStyle;
            this.OutLineStyle = sSimpleFillSymbol.OutLineStyle;
        }
    }
}
