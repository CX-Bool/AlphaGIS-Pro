/*************************************************************
*        文件名：FeatureCollection.cs                        *
*        作者：伍昕钰     学号：1100012443                   *
*        功能：要素的数据集，包括空间数据与属性数据          *     
*        支持文件的读写，按条件获取选择的数据集              *
*************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// v1.0
/// </summary>

namespace AlphaGISProClient
{
    /// <summary>
    /// 要素的数据集，包括空间数据与属性数据
    /// </summary>
    public class FeatureCollection
    {
        #region 字段
        private GeometryType _geoType;  //要素的类型
        private List<Geometry> _Geometries; //空间数据
        private GeoRecordset _GeoRecordset; //属性数据
        private Rectangle _MBR; //整个图层要素的最小外包矩形
        #endregion

        #region 属性
        public GeometryType GeoType
        {
            get { return _geoType; }
            set { _geoType = value; }
        }

        public List<Geometry> Geometries
        {
            get { return _Geometries; }
        }

        public GeoRecordset GeoRecordset
        {
            get { return _GeoRecordset; }
        }

        /*public Rectangle MBR
        {
            get { return _MBR; }
            set { _MBR = value; }
        }*/
        ///待定
        #endregion

        #region 方法
        /// <summary>
        /// 初始化。。
        /// </summary>
        /// <param name="geoType"></param>
        public FeatureCollection(GeometryType geoType)
        {
            _geoType = geoType;
            _Geometries = new List<Geometry>();
            _GeoRecordset = new GeoRecordset();
            
        }

        /// <summary>
        /// 从文件中读取，文件路径为shp路径，dbf路径强制要求与shp文件同文件夹下同名
        /// 返回读取图层的类型
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public GeometryType OpenFile(string filepath)
        {

            return this.GeoType;
            
        }
        /// <summary>
        /// 保存成文件。。。
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool SaveFile(string filepath)
        {
            return true;
        }

        /// <summary>
        /// 根据定义的字符串来获取选中的数据集
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public FeatureCollection SelectByQuery(Query query)
        {
            FeatureCollection sFeatureCollection = new FeatureCollection(this.GeoType);
            sFeatureCollection.GeoRecordset.Fields = this.GeoRecordset.Fields;
            sFeatureCollection.GeoRecordset.Records.Clear();
            int fieldIndex = this.GeoRecordset.Fields.GetFieldIndex(query.FieldName);
            if (fieldIndex == -1)
                throw new ArgumentException();
            bool match = false;
            for(int i=0;i< this.GeoRecordset.Records.Count; i++)
            {
                match = false;
                switch (query.FieldType)
                {
                    //数值型
                    case DBFFileDataTypeConstant.Numeric:
                        double sQueryValue = Convert.ToDouble(query.Value);
                        double sRecordValue = Convert.ToDouble(this.GeoRecordset.Records.GetItem(i).GetValue(fieldIndex));

                        switch (query.Operator)
                        {
                            case Operator.Equals:
                                if (sRecordValue == sQueryValue)
                                    match = true;
                                break;
                            case Operator.Greater:
                                if (sRecordValue > sQueryValue)
                                    match = true;
                                break;
                            case Operator.GreaterEquals:
                                if (sRecordValue >= sQueryValue)
                                    match = true;
                                break;
                            case Operator.Less:
                                if (sRecordValue < sQueryValue)
                                    match = true;
                                break;
                            case Operator.LessEquals:
                                if (sRecordValue <= sQueryValue)
                                    match = true;
                                break;
                        }
                        break;
                    //非数值型（字符串）
                    default:
                        string sValue = this.GeoRecordset.Records.GetItem(i).GetValue(fieldIndex).ToString();
                        if (sValue.Equals(query.Value))
                        {
                            match = true;
                        }
                        break;
                }
                if (match)
                {
                    sFeatureCollection.AddFeatrue(this.Geometries[i], this.GeoRecordset.Records.GetItem(i));
                }
            }
            return sFeatureCollection;
        }

        public bool AddFeatrue(Geometry geometry, Record record)
        {
            if (geometry.GeoType != this._geoType || record.FieldsCount != this.GeoRecordset.Fields.Count)
                return false;
            this.Geometries.Add(geometry);
            this.GeoRecordset.Records.Add(record);
            return true;
        }

        #endregion

        #region 私有函数
        // 翻转字节顺序 (32-bit)
        private UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }
        #endregion
        

    }
}
