/*************************************************************
*        文件名：Fields.cs                                   *
*        作者：刘鲁豫     学号：1300013278                   *
*        功能：字段相关的方法和事件                          *    
*                                                            *
*************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class Fields
    {
        #region 字段

        private List<Field> _Fields = new List<Field>();//保存字段的集合//

        #endregion
        #region 构造函数

        internal Fields()
        { }
        //是和geo类绑在一起的，所以外部程序没有办法new了，但是程序集之内可以。因为本身是方法集合，不需要每次 都建立新的//
        #endregion
        #region 属性
        /// <summary>
        /// 获取字段数据
        /// </summary>
        public int Count
        {
            get { return _Fields.Count; }//C沙浦不支持带参数的属性？？只能用方法
        }

        #endregion

        #region 方法
        /// <summary>
        /// 获取制定索引号的字段
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Field GetItem(int index)
        {
            return _Fields[index];
        }
        /// <summary>
        /// 在末尾增加制定字段
        /// </summary>
        /// <param name="field"></param>
        public void Append(Field field)
        {
            if (field != null)
            {
                _Fields.Add(field);
                FieldAppended(this, field);//this表示是我广播的
            }
            else
            {
                throw new Exception("Invalid Field.");
            }
        }


        public void Delete(int index)
        {
            Field sField = _Fields[index];
            _Fields.RemoveAt(index);
            FieldDeleted(this, index, sField);//TODO,也要删掉指定记录中的
        }

        public int GetFieldIndex(string fieldName)
        {
            int index = -1;
            for(int i = 0; i < _Fields.Count; i++)
            {
                if (_Fields[i].Name.Equals(fieldName))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 广播，发生事件通知Geo类从而做出反应，使得知道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="field"></param>
        internal delegate void FieldAppendHandle(object sender, Field field);//sender 是发送者//
        /// <summary>
        /// 有字段被加入
        /// </summary>
        internal event FieldAppendHandle FieldAppended;

        internal delegate void FieldDeleteHandle(object sender, int index, Field field);//还要说明是第几个字段被删掉了//
        /// <summary>
        /// 有字段被删除
        /// </summary>
        internal event FieldDeleteHandle FieldDeleted;

        #endregion
    }
}
