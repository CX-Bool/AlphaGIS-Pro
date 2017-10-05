/*************************************************************
*         文件名：Layer.cs                                   *
*         作者：陈旭     学号：1300012421                    *
*         功能：图层类，一个图层主要包含一个源数据集、       *
*         一个被选中数据集、一个被选中的节点集、             *
*         一个渲染类、一个注记类，以及名称等属性             *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlphaGISProClient
{
    /// <summary>
    /// 图层类
    /// </summary>
    public class Layer
    {
        #region 字段
        private string layername;    //图层名
        private string shpfilePath;//shp 存储的位置
        private GeometryType geoType;//图层的类型（PointD,MultiPolyline,MultiPolygon）
        //要素的数据，包括空间、属性以及描述(尚未实现) 
        private FeatureCollection _sourceFeatures;  //图层全部要素的空间、属性数据
        private FeatureCollection _selectedFeatures; //图层被选中要素的空间、属性数据
        private List<PointD> _selectedVertexs;
        private Renderer _Renderer;//图层要素渲染方式
        private string _LabelField;//图层注记
        private Label _Label;
        

        //坐标系转换(尚未实现)

            
        private bool visible = true;    //是否可见
        #endregion

        #region 属性
        public string Name
        {
            get { return layername; }
            set { layername = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public GeometryType GeoType
        {
            get { return geoType; }
            set { geoType = value; }
        }
        public FeatureCollection SourceFeatures
        {
            get { return _sourceFeatures; }
        }
        public FeatureCollection SelectedFeatures
        {
            get { return _selectedFeatures; }
        }
        public Renderer Renderer
        {
            get { return _Renderer; }
            set { _Renderer = value; }
        }
        public string LabelField
        {
            get { return _LabelField; }
            set { _LabelField = value; }
        }
        public Label Label
        {
            get { return _Label; }
            set { _Label = value; }
        }
        #endregion

        #region 方法
        public void DeleteSelectedVertexs()
        {
            if (_selectedVertexs == null || _selectedVertexs.Count == 0)
                return ;
            else
            {
                foreach (PointD sPoint in _selectedVertexs)
                {
                    for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                    {
                        //todo
                    }
                }
                return ;
            }
        }
        public void SaveToString(StreamWriter sw)
        {


            sw.WriteLine(this.Name);
            sw.WriteLine(this.shpfilePath);
            sw.WriteLine(this.geoType);
            sw.WriteLine(this.LabelField);
            //SourceFeatures.SaveToString(sw);
            //Renderer.SaveToString(sw);
            Label.SaveToString(sw);
        }
        public Layer(string name,GeometryType geotype)
        {
            this.layername = name;
            this.shpfilePath = "nopath";
            _sourceFeatures = new FeatureCollection(geotype);
            Field sField1 = new Field("数值属性", DBFFileDataTypeConstant.Numeric);
            Field sField2 = new Field("字符属性", DBFFileDataTypeConstant.Char);
            _sourceFeatures.GeoRecordset.Fields.Append(sField1);
            _sourceFeatures.GeoRecordset.Fields.Append(sField2);
            _Label = new Label();
            this.geoType = _sourceFeatures.GeoType;
            this.Renderer = new Renderer(this.geoType);
        }
        public Layer(string layername, string filepath)
        {
            this.layername = layername;
            this.shpfilePath = filepath;
            _sourceFeatures = new FeatureCollection(GeometryType.Null);
            _sourceFeatures.OpenFile(filepath);
            _Label = new Label();
            this.geoType = _sourceFeatures.GeoType;
            this.Renderer = new Renderer(this.geoType);
            //todo
        }

        //返回图层的边界范围，用于缩放、显示全图
        public Rectangle EnvelopOfLayer()
        {
            if (SourceFeatures.Geometries.Count == 0)
                return new Rectangle(0, 0, 0, 0);
            double minX = Double.MaxValue;
            double maxX = Double.MinValue;
            double minY = Double.MaxValue;
            double maxY = Double.MinValue;
            foreach (Geometry sGeometry in SourceFeatures.Geometries)
            {
                Rectangle rect = sGeometry.GetMBR();
                //
                minX = Math.Min(rect.MinX, minX);
                maxX = Math.Max(rect.MaxX, maxX);
                minY = Math.Min(rect.MinY, minY);
                maxY = Math.Max(rect.MaxY, maxY);
            }
            return new Rectangle(minX, maxX, minY, maxY);
        }

        
        //该函数负责load已有的shp文件
        public bool LoadLayer(string layername, string filepath)
        {
            //todo
            
            return true;
        }
        public void MoveSelectedVertex(double x, double y)
        {
            foreach(PointD sPoint in _selectedVertexs)
            {
                sPoint.Translation(x, y);
            }
        }
        public List<PointD> SelectedVertex(Rectangle selectRectangle)
        {
            _selectedVertexs = new List<PointD>();
            PointD sSelectPoint = null;
            if (selectRectangle.Width == 0 && selectRectangle.Height == 0)
                sSelectPoint = new PointD(selectRectangle.MinX, selectRectangle.MinY);
            switch (geoType)
            {
                case GeometryType.PointD:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            PointD sPoint = (PointD)_sourceFeatures.Geometries[i];
                            if (sPoint.isCoincide(sSelectPoint))
                            {
                                _selectedVertexs.Add(sPoint);
                            }
                        }
                    }
                    else//框选
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            PointD sPoint = (PointD)_sourceFeatures.Geometries[i];
                            if (selectRectangle.IsContainPoint(sPoint))
                            {
                                _selectedVertexs.Add(sPoint);
                            }
                        }
                    }
                    break;
                case GeometryType.MultiPolyline:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            MultiPolyline sMultiPolyline = (MultiPolyline)_selectedFeatures.Geometries[i];
                            foreach(Polyline sPolyline in sMultiPolyline.Polylines)
                            {
                                foreach(PointD sPoint in sPolyline.Points)
                                {
                                    if(sPoint.isCoincide(sSelectPoint))
                                        _selectedVertexs.Add(sPoint);
                                }
                            }
                        }
                    }
                    else//框选
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            MultiPolyline sMultiPolyline = (MultiPolyline)_selectedFeatures.Geometries[i];
                            
                            foreach (Polyline sPolyline in sMultiPolyline.Polylines)
                            {
                                foreach (PointD sPoint in sPolyline.Points)
                                {
                                    if (selectRectangle.IsContainPoint(sPoint))
                                    {
                                        _selectedVertexs.Add(sPoint);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case GeometryType.MultiPolygon:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            MultiPolygon sMultiPolygon = (MultiPolygon)_selectedFeatures.Geometries[i];
                            foreach (Polygon sPolygon in sMultiPolygon.Polygons)
                            {
                                foreach (PointD sPoint in sPolygon.Points)
                                {
                                    if (sPoint.isCoincide(sSelectPoint))
                                        _selectedVertexs.Add(sPoint);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _selectedFeatures.Geometries.Count; i++)
                        {
                            MultiPolygon sMultiPolygon = (MultiPolygon)_selectedFeatures.Geometries[i];
                            foreach (Polygon sPolygon in sMultiPolygon.Polygons)
                            {
                                foreach (PointD sPoint in sPolygon.Points)
                                {
                                    if (selectRectangle.IsContainPoint(sPoint))
                                    {
                                        _selectedVertexs.Add(sPoint);
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            return _selectedVertexs;
        }
        //平移
        public void MoveVertex(PointD selectPoint,PointD endPoint)
        {
            foreach(Geometry sGeometry in _selectedFeatures.Geometries)
            {
                sGeometry.MoveVertex(selectPoint, endPoint);
            }
        }
        //根据拉框选择要素
        public bool SelectByRectangle(Rectangle selectRectangle)
        {
            FeatureCollection sSelectedFeatures = new FeatureCollection(this.geoType);
            sSelectedFeatures.GeoRecordset.Fields = this._sourceFeatures.GeoRecordset.Fields;
            sSelectedFeatures.GeoRecordset.Records.Clear();
            Record sRec = new Record();
            bool select;
            PointD sSelectPoint = null;
            if (selectRectangle.Width == 0 && selectRectangle.Height == 0)
                sSelectPoint = new PointD(selectRectangle.MinX, selectRectangle.MinY);
            switch (geoType)
            {
                case GeometryType.PointD:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            PointD sPoint = (PointD)_sourceFeatures.Geometries[i];
                            if (sPoint.isCoincide(sSelectPoint))
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sPoint);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    else//框选
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            PointD sPoint = (PointD)_sourceFeatures.Geometries[i];
                            if (selectRectangle.IsContainPoint(sPoint))
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sPoint);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    break;
                case GeometryType.MultiPolyline:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            MultiPolyline sMultiPolyline = (MultiPolyline)_sourceFeatures.Geometries[i];
                            if (sMultiPolyline.IsContain(sSelectPoint))
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sMultiPolyline);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    else//框选
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            MultiPolyline sMultiPolyline = (MultiPolyline)_sourceFeatures.Geometries[i];
                            select = false;
                            foreach (Polyline sPolyline in sMultiPolyline.Polylines)
                            {
                                foreach (PointD sPoint in sPolyline.Points)
                                {
                                    if (selectRectangle.IsContainPoint(sPoint))
                                    {
                                        select = true;
                                        break;
                                    }
                                }
                            }
                            if (select)
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sMultiPolyline);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    break;
                case GeometryType.MultiPolygon:
                    if (selectRectangle.Width == 0 && selectRectangle.Height == 0)//作为一个点
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            MultiPolygon sMultiPolygon = (MultiPolygon)_sourceFeatures.Geometries[i];
                            if (sMultiPolygon.IsContain(sSelectPoint))
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sMultiPolygon);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                        {
                            MultiPolygon sMultiPolygon = (MultiPolygon)_sourceFeatures.Geometries[i];
                            select = false;
                            foreach (Polygon sPolygon in sMultiPolygon.Polygons)
                            {
                                foreach (PointD sPoint in sPolygon.Points)
                                {
                                    if (selectRectangle.IsContainPoint(sPoint))
                                    {
                                        select = true;
                                        break;
                                    }
                                }
                            }
                            if (select)
                            {
                                sRec = _sourceFeatures.GeoRecordset.Records.GetItem(i);
                                sSelectedFeatures.Geometries.Add(sMultiPolygon);
                                sSelectedFeatures.GeoRecordset.Records.Add(sRec);
                            }
                        }
                    }
                    break;
            }
            _selectedFeatures = sSelectedFeatures;
            if (sSelectedFeatures.Geometries.Count != 0)
                return true;
            else
                return false;
        }
        //新加编辑的要素并且新建一个记录
        public bool AddFeatrue(Geometry geometry)
        {
            if (geometry.GeoType != this.geoType)
                return false;
            this._sourceFeatures.Geometries.Add(geometry);
            this._sourceFeatures.GeoRecordset.Records.NewRecord();
            return true;
        }
        //删除要素
        public bool DeleteSelectedFeature()
        {
            if (_selectedFeatures == null || _selectedFeatures.Geometries.Count == 0)
                return false;
            else
            {
                foreach(Geometry sGeometry in _selectedFeatures.Geometries)
                {
                    for(int i = 0; i < _sourceFeatures.Geometries.Count; i++)
                    {
                        if (sGeometry.Equals(_sourceFeatures.Geometries[i]))
                        {
                            _sourceFeatures.Geometries.RemoveAt(i);
                            _sourceFeatures.GeoRecordset.Records.Delete(i);
                            break;
                        }
                    }
                }
                return true;
            }
        }
        //新增有属性的要素
        public bool AddFeatrue(Geometry geometry,Record record)
        {
            if (geometry.GeoType != this.geoType||record.FieldsCount!=this._selectedFeatures.GeoRecordset.Records.Count)
                return false;
            this._sourceFeatures.Geometries.Add(geometry);
            this._sourceFeatures.GeoRecordset.Records.Add(record);
            return true;
        }
        public void ClearSelect()
        {
            _selectedFeatures = null;
            _selectedVertexs = null;
        }
        public void SelectByQuery(Query query)
        {
            _selectedFeatures = _sourceFeatures.SelectByQuery(query);
        }
        public List<Symbol> GetSymbolList()
        {
            List<Symbol> sSymbolList = new List<Symbol>();
            int fieldIndex = this.SourceFeatures.GeoRecordset.Fields.GetFieldIndex(_Renderer.QueryFieldName);
            switch (_Renderer.RenderType)
            {
                case RenderType.Simple:
                    for (int i = 0; i < this.SourceFeatures.Geometries.Count; i++)
                    {
                        sSymbolList.Add(_Renderer.DefaultSymbol);
                    }
                    break;
                case RenderType.Unique:
                case RenderType.Class:
                    for (int i = 0; i < this.SourceFeatures.Geometries.Count; i++)
                    {
                        string value = this.SourceFeatures.GeoRecordset.Records.GetItem(i).GetValue(fieldIndex).ToString();
                        Symbol sSymbol = GetSymbolByValue(value);
                        sSymbolList.Add(sSymbol);
                    }
                    break;
            }
            return sSymbolList;
        }
        public List<Label> GetLabelList()
        {
            List<Label> sLabelList = new List<Label>();
            int fieldIndex = this.SourceFeatures.GeoRecordset.Fields.GetFieldIndex(_LabelField);
            for(int i = 0; i < this.SourceFeatures.Geometries.Count; i++)
            {
                string value = this.SourceFeatures.GeoRecordset.Records.GetItem(i).GetValue(fieldIndex).ToString();
                Label sLabel = _Label.Clone();
                sLabel.Value = value;
                sLabelList.Add(sLabel);

            }

            return sLabelList;
        }
        private Symbol GetSymbolByValue(string value)
        {
            Symbol sSymbol = this.Renderer.DefaultSymbol;
            switch (this.Renderer.RenderType)
            {
                case RenderType.Unique:
                    for(int i = 0; i < this.Renderer.Querys.Count; i++)
                    {
                        if (this.Renderer.Querys[i].isTrue(value))
                            sSymbol= this.Renderer.Symbols[i];
                    }
                    break;
                case RenderType.Class:
                    for (int i = 0; i < this.Renderer.Querys.Count; i++)
                    {
                        if(i+1== this.Renderer.Querys.Count)
                        {
                            if (this.Renderer.Querys[i].isTrue(value))
                                sSymbol = this.Renderer.Symbols[i];
                            
                        }
                        else
                        {
                            if (this.Renderer.Querys[i].isTrue(value) &&
                                !this.Renderer.Querys[i+1].isTrue(value))
                                sSymbol = this.Renderer.Symbols[i];
                        }
                    }
                    break;
                default:
                    sSymbol= this.Renderer.DefaultSymbol;
                    break;
            }
            return sSymbol;
        }
        public void TranslationSelected(double deltaX,double deltaY)
        {
            foreach(Geometry sGeometry in _selectedFeatures.Geometries)
            {
                sGeometry.Translation(deltaX, deltaY);
            }
        }
        #endregion
    }
}
