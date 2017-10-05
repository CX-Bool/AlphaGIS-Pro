/*************************************************************
*         文件名：Symbol.cs                                  *
*         作者：赵聪     学号：1300012453                    *
*         功能：用于设定地图符号的符号类                     *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    /// <summary>
    /// 判断符号类型的枚举
    /// </summary>
    [Serializable]
    public class Symbol
    {
        #region 字段
        protected string _Label;
        protected GeometryType _SymbolType;
        protected System.Drawing.Color _SymbolColor;
        protected bool _Visible;
        protected int _LinearUnit;
        #endregion

        #region 属性
        public System.Drawing.Color SymbolColor
        {
            get { return _SymbolColor; }
        }
        /// <summary>
        /// 设置符号标签，用于对符号的说明
        /// </summary>
        public string Label
        {
            get{ return _Label; }
            set{ _Label = value; }
        }
        /// <summary>
        /// 设置是否可见
        /// </summary>
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        /// <summary>
        /// 获取该符号的类型
        /// </summary>
        public GeometryType SymbolType
        {
            get { return _SymbolType; }
        }
        #endregion

        #region 构造函数
        public Symbol()
        {
            _Visible = true;
        }
        public Symbol(string label)
        {
            _Label = label;
            _Visible = true;
        }
        public Symbol(string label, bool visible)
        {
            _Label = label;
            _Visible = visible;
        }

        #endregion
    }
}
