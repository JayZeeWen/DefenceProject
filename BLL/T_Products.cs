using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EShop.Model;
namespace EShop.BLL
{
	/// <summary>
	/// T_Products
	/// </summary>
	public partial class T_Products
	{
		private readonly EShop.DAL.T_Products dal=new EShop.DAL.T_Products();
		public T_Products()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProID)
		{
			return dal.Exists(ProID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EShop.Model.T_Products model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EShop.Model.T_Products model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ProID)
		{
			
			return dal.Delete(ProID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProIDlist )
		{
			return dal.DeleteList(ProIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EShop.Model.T_Products GetModel(long ProID)
		{
			
			return dal.GetModel(ProID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EShop.Model.T_Products GetModelByCache(long ProID)
		{
			
			string CacheKey = "T_ProductsModel-" + ProID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EShop.Model.T_Products)objModel;
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
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EShop.Model.T_Products> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EShop.Model.T_Products> DataTableToList(DataTable dt)
		{
			List<EShop.Model.T_Products> modelList = new List<EShop.Model.T_Products>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EShop.Model.T_Products model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

        public DataSet GetProducts(string strWhere, string orderby, int pageIndex, int pageSize)
        {
            return dal.GetProducts(strWhere, orderby,pageIndex,pageSize);
        }
		#endregion  ExtensionMethod
	}
}

