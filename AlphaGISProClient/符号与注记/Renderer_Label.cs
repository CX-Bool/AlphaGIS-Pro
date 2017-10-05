/*************************************************************
*         文件名：Renderer_Label.cs                          *
*         作者：陈旭     学号：1300012421                    *
*         功能：作为图层layer中的类，                        *
*         renderer记录符号渲染样式（简单，唯一值，分级）     *
*         label类记录图层的注记样式                          *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlphaGISProClient
{
    [Serializable]
    public enum RenderType
    {
        Simple = 1,//简单渲染
        Unique = 2,//唯一值渲染
        Class = 3,//分级渲染
    }
    /// <summary>
    /// 记录图层的渲染方式（简单、唯一值、分级），渲染规则，渲染符号
    /// </summary>
    [Serializable]
    public class Renderer
    {
        #region 字段
        private RenderType _RenderType;//记录渲染的方式
        private GeometryType _SymbolType;//记录符号的地理类型
        private List<Symbol> _Symbols = new List<Symbol>();//记录具体的每一种符号
        private List<Query> _Querys = new List<Query>();//符合Querys[i]的要素全部用Symbols[i]来渲染
        private string _QueryFieldName;//用于分级或者唯一值的字段
        private PointSymbolType _PointSymbolType;//全部_Symbols默认的点样式(如果是点图层)
        private LineSymbolType _LineSymbolType;//全部_Symbols默认的线样式(如果是线图层)
        private Symbol _DefaultSymbol;
        #endregion

        #region 属性
        public RenderType RenderType
        {
            get { return _RenderType; }
            set { _RenderType = value; }
        }
        public GeometryType SymbolType
        {
            get { return _SymbolType; }
        }
        public List<Symbol> Symbols
        {
            get { return _Symbols; }
            set { _Symbols = value; }
        }
        public List<Query> Querys
        {
            get { return _Querys; }
            set { _Querys = value; }
        }
        public string QueryFieldName
        {
            get { return _QueryFieldName; }
            set { _QueryFieldName = value; }
        }
        public PointSymbolType PointSymbolType
        {
            get { return _PointSymbolType; }
            set { _PointSymbolType = value; }
        }
        public LineSymbolType LineSymbolType
        {
            get { return _LineSymbolType; }
            set { _LineSymbolType = value; }
        }
        public Symbol DefaultSymbol
        {
            get { return _DefaultSymbol; }
        }
        #endregion
        #region 方法
        //简单的构造函数
        public Renderer(GeometryType symbolType)
        {
            _SymbolType = symbolType;
            _RenderType = RenderType.Simple;//默认为简单符号法
            _PointSymbolType = PointSymbolType.Circle;//默认为空心圆
            _LineSymbolType = LineSymbolType.Solid;//默认为实线
            switch (_SymbolType)
            {
                case GeometryType.PointD://如果是点
                    SimplePointSymbol sSimplePointSymbol = new SimplePointSymbol(_PointSymbolType, 4, Color.Red);
                    _DefaultSymbol = sSimplePointSymbol;
                    break;
                case GeometryType.MultiPolyline:
                    SimpleLineSymbol sSimpleLineSymbol = new SimpleLineSymbol(_LineSymbolType,2,Color.Blue);
                    _DefaultSymbol = sSimpleLineSymbol;
                    break;
                case GeometryType.MultiPolygon:
                    SimpleFillSymbol sSimpleFillSymbol = new SimpleFillSymbol(Color.Yellow, 1, Color.Black);
                    _DefaultSymbol = sSimpleFillSymbol;
                    break;
            }
        }
        public void SetSimpleRenderer(Symbol simpleSymbol)
        {
            _RenderType = RenderType.Simple;
            _DefaultSymbol = simpleSymbol;
        }
        public void SetUniqueRenderer(string queryFieldName, List<Query> querys, List<Symbol> symbols)
        {
            _RenderType = RenderType.Unique;
            _QueryFieldName = queryFieldName;
            _Querys = querys;
            _Symbols = symbols;
        }
        public void SetClassRenderer(string queryFieldName, List<Query> querys, List<Symbol> symbols)
        {
            _RenderType = RenderType.Class;
            _QueryFieldName = queryFieldName;
            _Querys = querys;
            _Symbols = symbols;
        }
        #endregion
    }
    /// <summary>
    /// 记录图层注记的显示
    /// </summary>
    [Serializable]
    public class Label
    {
        #region 字段
        
        private bool _Visible;//注记是否可见
        private Font _Font;
        private Color _Color;
        private float _OffsetX;//不知道干吗用 = 0;
        private float _OffsetY;//不知道干吗用
        private string _Value;

        #endregion
        #region 属性
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        public Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        #endregion
        #region 方法
        public void SaveToString(StreamWriter sw)
        {
            sw.WriteLine(this.Visible);
            sw.WriteLine(this.Font.ToString());
            sw.WriteLine(this.Color.ToString());
        }
        public Label()
        {
            _Visible = false;
            _Font = SystemFonts.DefaultFont;
            _Color = Color.Black;
            _OffsetX = 0;
            _OffsetY = 0;
            _Value = "Default";
        }
        public Label(string value,bool visible,Font font,Color color,float offsetX,float offsetY)
        {
            _Visible = true;
            _Font = font;
            _Color = color;
            _OffsetX = offsetX;
            _OffsetY = offsetY;
            _Value = value;
        }
        public Label Clone()
        {
            Label sLabel = new Label("Clone", _Visible, _Font, _Color, _OffsetX, _OffsetY);
            return sLabel;
        }
        #endregion
    }

    
}
