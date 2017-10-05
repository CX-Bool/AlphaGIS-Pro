/*************************************************************
*         文件名：SimpleLineSymbol.cs                        *
*         作者：赵聪     学号：1300012453                    *
*         功能：用于设定线符号的符号类                       *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public enum LineSymbolType
    {
        Solid = 0,
        Dash = 1,
    }
    [Serializable]
    public class SimpleLineSymbol:Symbol
    {
        #region 字段
        private LineSymbolType _LineSymbolType;//线符号类型：Solid表示实线，Dash表示虚线
        private double _Width;//线宽
        private System.Drawing.Color _Color;//颜色
        #endregion

        #region 构造函数
        
        public SimpleLineSymbol(LineSymbolType lineSymbolType, double width, System.Drawing.Color color)
        {
            _SymbolColor = color;
            _SymbolType = GeometryType.MultiPolyline;
            _LineSymbolType = lineSymbolType;
            _Width = width;
            _Color = color;
        }

        #endregion

        #region 属性
        
        /// <summary>
        /// 获取和设置线符号类型
        /// </summary>
        public LineSymbolType LineSymbolType
        {
            get { return _LineSymbolType; }
            set { _LineSymbolType = value; }
        }
        /// <summary>
        /// 获取和设置线宽
        /// </summary>
        public double Width
        {
            get { return _Width; }
            set { _Width = value; } 
        }
        /// <summary>
        /// 获取和设置颜色
        /// </summary>
        public System.Drawing.Color Color
        {
            get { return _Color; }
            set { _Color = value;
                _SymbolColor = value;
            }
        }
        #endregion
        //简便设置一下整个symbol
        public void Set(SimpleLineSymbol sSimpleLineSymbol)
        {
            this._LineSymbolType = sSimpleLineSymbol.LineSymbolType;
            this._Width = sSimpleLineSymbol.Width;

            
            this._Color = sSimpleLineSymbol.Color;
        }

    }
}
