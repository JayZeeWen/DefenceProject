using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using EShop.Model;
namespace EShop.BLL
{
    //T_DeliveryAddress
    public partial class T_DeliveryAddress
    {

        private readonly EShop.DAL.T_DeliveryAddress dal = new EShop.DAL.T_DeliveryAddress();
        public T_DeliveryAddress()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(EShop.Model.T_DeliveryAddress model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EShop.Model.T_DeliveryAddress model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EShop.Model.T_DeliveryAddress GetModel(long id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EShop.Model.T_DeliveryAddress GetModelByCache(long id)
        {

            string CacheKey = "T_DeliveryAddressModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EShop.Model.T_DeliveryAddress)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EShop.Model.T_DeliveryAddress> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EShop.Model.T_DeliveryAddress> DataTableToList(DataTable dt)
        {
            List<EShop.Model.T_DeliveryAddress> modelList = new List<EShop.Model.T_DeliveryAddress>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EShop.Model.T_DeliveryAddress model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EShop.Model.T_DeliveryAddress();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = long.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    if (dt.Rows[n]["PostCode"].ToString() != "")
                    {
                        model.PostCode = int.Parse(dt.Rows[n]["PostCode"].ToString());
                    }
                    model.Address = dt.Rows[n]["Address"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        public DataTable GetRowByID(int id)
        {
            return dal.GetRowByID(id);
        }

        #endregion

    }
}