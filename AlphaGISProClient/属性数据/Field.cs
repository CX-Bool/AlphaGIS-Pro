/*************************************************************
*        文件名：Field.cs                                    *
*        作者：刘鲁豫     学号：1300013278                   *
*        功能：字段类                                        *                    
*************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class Field
    {
        #region 字段
        private string _Name;//这个变量将会有一个属性与之对应//
        private DBFFileDataTypeConstant _ValueType;//枚举,以上两个描述一个字段的类型//
        private byte _FieldLength;//字段长度
        private byte _FieldPrecision;//字段精度
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">字段名称</param>
        /// <param name="valueType">字段值类型</param>
        public Field(string name, DBFFileDataTypeConstant valueType, byte fieldLength = 0, byte fieldPrecision = 0)
        {
            _Name = name;
            _ValueType = valueType;
            _FieldLength = fieldLength;
            _FieldPrecision = fieldPrecision;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        #region 属性
        public string Name//只读属性，一旦有一个字段就不能改了//
        {
            get { return _Name; }
        }

        public DBFFileDataTypeConstant Valuetype
        {
            get { return _ValueType; }
        }
        /// <summary>
        /// 字段最大长度
        /// </summary>
        public byte FieldLength
        {
            get { return _FieldLength; }
            //set { _FieldLength = value; }
        }


        /// <summary>
        /// 字段精度
        /// </summary>
        public byte FieldPrecision
        {
            get { return _FieldPrecision; }
            //set { _FieldPrecision = value; }
        }
        #endregion
    }
}
