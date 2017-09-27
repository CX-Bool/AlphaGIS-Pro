using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace AlphaGISProClient
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class MapControl : System.Windows.Controls.Image
    {
        public MapControl()
        { 

        }
        #region private fields
        private double _DisplayScale = 100000;//比例尺的倒数，初始值设为100000
        private double mOffsetX = 608 * 3 / 2, mOffsetY = 482 * 3 / 2;//bitmap中心点的坐标
        #endregion

        #region 属性
        public double DisplayScale
        {
            get { return _DisplayScale; }
        }
        public double smOffsetX
        {
            get { return mOffsetX; }
            set { mOffsetX = value; }
        }
        public double smOffsetY
        {
            get { return mOffsetY; }
            set { mOffsetY = value; }
        }
        #endregion

        #region 交互函数

        #endregion

        #region 渲染函数
        void DrawPoint(PointF point, String spSymbol) { }
        void DrawMultiPolyline(String multipolyline, String slSymbol) { }
        void DrawMultiPolygon(String multipolygon, String sfSymbol) { }
        void DrawLabel(String geometry, String s, Label l) { }
        #endregion

        #region 公共函数

        public void MapcontrolRefresh()
        {

        }
        public void Pan() { }
        public void ZoomIn() { }
        public void ZoomOut() { }
        public void Identify() { }
        public Bitmap GetBitmap() { return null; }
        public void MapZoomToDisplay() { }
        public void LayerZoomToDisplay() { }
        public void Select() { }
        public void Track() { }
        public string MouseDownLocation() { return null; }
        public PointF FromMapPoint(PointF point) { return PointF.Empty; }
        public PointF ToMapPoint(PointF point) { return PointF.Empty; }



        #endregion
    }
}
