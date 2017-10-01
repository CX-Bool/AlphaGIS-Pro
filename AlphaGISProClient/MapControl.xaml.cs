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
            //InitializeComponent();
            //this.MouseWheel += new MouseWheelEventHandler(MapControl_MouseWheel);
            //this.MouseDown += new MouseButtonEventHandler(pictureBox1_MouseDown);
            //this.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            //this.MouseUp += new MouseButtonEventHandler(pictureBox1_MouseUp);

            //mCur_PanUp = ((TextBlock)Resources["Pan"]).Cursor;
            //mCur_ZoomIn = ((TextBlock)Resources["ZoomIn"]).Cursor;
            //mCur_ZoomOut = ((TextBlock)Resources["ZoomOut"]).Cursor;
            ////Fixed size
            //bitmap_X = 800;
            //bitmap_Y = 500;
            //InitializeBackground();
        }
        private void InitializeBackground()
        {
            //gridbmp = BitmapFactory.New(bitmap_X, bitmap_Y);
            //using (gridbmp.GetBitmapContext())
            //{

            //    gridbmp.Clear(Colors.White);

            //    for (int i = 4; i < 801; i += 8)
            //    {
            //        gridbmp.DrawLineAa(i, 0, 0, i, Colors.Black);
            //        gridbmp.DrawLineAa(i, 802, 802, i, Colors.Black);
            //    }
            //    linebmp = gridbmp.Flip(WriteableBitmapExtensions.FlipMode.Vertical);
            //    gridbmp.Blit(new Rect(0, 0, 802, 802), linebmp, new Rect(0, 0, 802, 802), WriteableBitmapExtensions.BlendMode.ColorKeying);
            //}
            //gridbmp = gridbmp.Crop(0, 0, bitmap_X, bitmap_Y);
            //linebmp = linebmp.Crop(0, 0, bitmap_X, bitmap_Y);
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
    public enum MapOperationType
    {
        None = 0,
        ZoomIn = 1,
        ZoomOut = 2,
        Pan = 3,
        SelectFeature = 4,
        EditAdd = 5,
        EditMoveSelectedFeature = 6,
        EditSelectPoints = 7,
        EditMoveSelectedPoints = 8
    }
}
