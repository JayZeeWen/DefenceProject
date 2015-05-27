using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EShop.Model;
using EShop.DAL;
namespace EShop.BLL
{
	/// <summary>
	/// T_Orders
	/// </summary>
	public partial class T_Orders
	{
		private readonly EShop.DAL.T_Orders dal=new EShop.DAL.T_Orders();
		public T_Orders()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long OrderID)
		{
			return dal.Exists(OrderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(EShop.Model.T_Orders model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EShop.Model.T_Orders model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long OrderID)
		{
			
			return dal.Delete(OrderID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OrderIDlist )
		{
			return dal.DeleteList(OrderIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EShop.Model.T_Orders GetModel(long OrderID)
		{
			
			return dal.GetModel(OrderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EShop.Model.T_Orders GetModelByCache(long OrderID)
		{
			
			string CacheKey = "T_OrdersModel-" + OrderID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EShop.Model.T_Orders)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<EShop.Model.T_Orders> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<EShop.Model.T_Orders> DataTableToList(DataTable dt)
        //{
        //    List<EShop.Model.T_Orders> modelList = new List<EShop.Model.T_Orders>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        EShop.Model.T_Orders model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetOrderDataSet(string strWhere, string orderby, int pageIndex, int pageSize)
        {
            DataSet ds = dal.GetOrderDataSet(strWhere, orderby, pageIndex, pageSize);
            ds.Tables[0].Columns.Add("c_state");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["state"].ToString() == "0" )
                {
                    dr["c_state"] = "未付款";
                }
                else if (dr["state"].ToString() == "1")
                {
                    dr["c_state"] = "未发货";
                }
                else if (dr["state"].ToString() == "2")
                {
                    dr["c_state"] = "已发货";
                }
            }


            return ds;
 
        }

        public DataSet GetOrderDetailsDataSet(string strWhere, string orderby, int pageIndex, int pageSize)
        {
            return dal.GetOrderDetailsDataSet(strWhere, orderby, pageIndex, pageSize);
        }

        public int GetDetailsCount(string strWhere)
        {
            return dal.GetDetailsCount(strWhere);
        }
		#endregion  ExtensionMethod
	}
}

