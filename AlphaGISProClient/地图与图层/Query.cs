/*************************************************************
*         文件名：Query.cs                                   *
*         作者：陈旭     学号：1300012421                    *
*         功能：管理查询条件，在根据要素查询属性、           *
*         唯一值渲染和分级渲染条件中应用                     *
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    /// <summary>
    /// 查询语句的比较符
    /// </summary>
    public enum Operator
    {
        Equals='=',
        Greater='>',
        Less='<',
        GreaterEquals='≥',
        LessEquals='≤'
    }
    /// <summary>
    /// 用于属性查询条件的类
    /// </summary>
    public class Query
    {
        #region 字段
        private string _FieldName;
        private Operator _Operator;
        private string _Value;
        private DBFFileDataTypeConstant _FieldType;
        #endregion
        #region 属性
        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        public Operator Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public DBFFileDataTypeConstant FieldType
        {
            get { return _FieldType; }
            set { _FieldType = value; }
        }
        #endregion
        #region 方法
        public Query(string fileName,Operator _operator,string value, DBFFileDataTypeConstant fieldType)
        {
            _FieldName = fileName;
            _Operator = _operator;
            _Value = value;
            _FieldType = fieldType;
        }
        public Query(string queryString)
        {

            string[] data = queryString.Split(new string[] {"@"}, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length > 4)
                throw new ArgumentException();
            else
            {
                _FieldName = data[0];
                _Operator = (Operator)data[1][0];
                _Value = data[2];
                _FieldType = (DBFFileDataTypeConstant)data[3][0];
            }
        }
        /// <summary>
        /// 转换为string语句："@字段名@比较符@值@值类型"
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            char[] param = new char[1] { '\0' };
            string sQueryString = "";
            sQueryString += _FieldName;//.TrimEnd(param);
            sQueryString += "@" + (Char)_Operator;
            sQueryString += "@" + _Value;
            sQueryString += "@" + (Char)_FieldType;
            return sQueryString;
        }
        public bool isTrue(string value)
        {
            bool match = false;
            switch (this.FieldType)
            {
                //数值型
                case DBFFileDataTypeConstant.Numeric:
                    double sQueryValue = Convert.ToDouble(this.Value);
                    double sRecordValue = Convert.ToDouble(value);

                    switch (this.Operator)
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
                    if (value.Equals(this.Value))
                    {
                        match = true;
                    }
                    break;
            }
            return match;
        }
        #endregion
    }
}
