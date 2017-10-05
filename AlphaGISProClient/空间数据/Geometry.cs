/*************************************************************
*         文件名：Geometry.cs                                *
*         作者：陈旭     学号：1300012421                    *
*         功能：定义地理要素基类                             *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    public enum GeometryType
    {
        Null=0,
        PointD=1,
        Polyline=2,
        MultiPolyline=3,
        Polygon=4,
        MultiPolygon=5
    };
    /// <summary>
    /// 抽象地理要素类
    /// </summary>
    [Serializable]
    public abstract class Geometry
    {
        public static double ER = 1e-10; //判断误差
        #region 字段
        protected GeometryType geoType;
        protected Rectangle _MBR;
        #endregion

        #region 属性
        public Rectangle MBR
        {
            get { return _MBR; }
            set { _MBR = value; }
        }
        public GeometryType GeoType
        {
            get { return geoType; }
            set { geoType = value; }
        }
        #endregion

        public virtual Rectangle GetMBR()
        {
            return new Rectangle(0, 0, 0, 0);
        }
        public virtual void  Translation(double deltaX, double deltaY)
        {
            
        }
        //移动节点
        public virtual void MoveVertex(PointD selectPoint, PointD endPoint)
        {
            
        }
        public virtual List<int> PartsIndex()
        {
            return new List<int>();
        }
        
    }
}
