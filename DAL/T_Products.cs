using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EShop.DBUtility;//Please add references
using EShop.Model;
namespace EShop.DAL
{
	/// <summary>
	/// 数据访问类:T_Products
	/// </summary>
	public partial class T_Products
	{
		public T_Products()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Products");
			strSql.Append(" where ProID=@ProID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.BigInt,8)			};
			parameters[0].Value = ProID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EShop.Model.T_Products model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Products(");
			strSql.Append("CTID,BraID,ProName,Price,SalePoint,Des,Stock,Img,ShelveDate,state)");
			strSql.Append(" values (");
			strSql.Append("@CTID,@BraID,@ProName,@Price,@SalePoint,@Des,@Stock,@Img,@ShelveDate,0)");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8),
					new SqlParameter("@BraID", SqlDbType.BigInt,8),
					new SqlParameter("@ProName", SqlDbType.NVarChar,20),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@SalePoint", SqlDbType.Int,4),
					new SqlParameter("@Des", SqlDbType.NVarChar,-1),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@Img", SqlDbType.NVarChar,-1),
					new SqlParameter("@ShelveDate", SqlDbType.DateTime)};			
			parameters[0].Value = model.CTID;
			parameters[1].Value = model.BraID;
			parameters[2].Value = model.ProName;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.SalePoint;
			parameters[5].Value = model.Des;
			parameters[6].Value = model.Stock;
			parameters[7].Value = model.Img;
			parameters[8].Value = model.ShelveDate;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EShop.Model.T_Products model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Products set ");
			strSql.Append("CTID=@CTID,");
			strSql.Append("BraID=@BraID,");
			strSql.Append("ProName=@ProName,");
			strSql.Append("Price=@Price,");
			strSql.Append("SalePoint=@SalePoint,");
			strSql.Append("Des=@Des,");
			strSql.Append("Stock=@Stock,");
			strSql.Append("Img=@Img,");
			strSql.Append("ShelveDate=@ShelveDate");
			strSql.Append(" where ProID=@ProID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8),
					new SqlParameter("@BraID", SqlDbType.BigInt,8),
					new SqlParameter("@ProName", SqlDbType.NVarChar,20),
					new SqlParameter("@Price", SqlDbType.Decimal,5),
					new SqlParameter("@SalePoint", SqlDbType.Int,4),
					new SqlParameter("@Des", SqlDbType.NVarChar,-1),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@Img", SqlDbType.NVarChar,-1),
					new SqlParameter("@ShelveDate", SqlDbType.DateTime),
					new SqlParameter("@ProID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.CTID;
			parameters[1].Value = model.BraID;
			parameters[2].Value = model.ProName;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.SalePoint;
			parameters[5].Value = model.Des;
			parameters[6].Value = model.Stock;
			parameters[7].Value = model.Img;
			parameters[8].Value = model.ShelveDate;
			parameters[9].Value = model.ProID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ProID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update T_Products set state = 1 ");
			strSql.Append(" where ProID=@ProID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.BigInt,8)};
			parameters[0].Value = ProID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ProIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Products ");
			strSql.Append(" where ProID in ("+ProIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EShop.Model.T_Products GetModel(long ProID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProID,CTID,BraID,ProName,Price,SalePoint,Des,Stock,Img,ShelveDate from T_Products ");
			strSql.Append(" where ProID=@ProID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProID", SqlDbType.BigInt,8)			};
			parameters[0].Value = ProID;

			EShop.Model.T_Products model=new EShop.Model.T_Products();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EShop.Model.T_Products DataRowToModel(DataRow row)
		{
			EShop.Model.T_Products model=new EShop.Model.T_Products();
			if (row != null)
			{
				if(row["ProID"]!=null && row["ProID"].ToString()!="")
				{
					model.ProID=long.Parse(row["ProID"].ToString());
				}
				if(row["CTID"]!=null && row["CTID"].ToString()!="")
				{
					model.CTID=long.Parse(row["CTID"].ToString());
				}
				if(row["BraID"]!=null && row["BraID"].ToString()!="")
				{
					model.BraID=long.Parse(row["BraID"].ToString());
				}
				if(row["ProName"]!=null)
				{
					model.ProName=row["ProName"].ToString();
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["SalePoint"]!=null && row["SalePoint"].ToString()!="")
				{
					model.SalePoint=int.Parse(row["SalePoint"].ToString());
				}
				if(row["Des"]!=null)
				{
					model.Des=row["Des"].ToString();
				}
				if(row["Stock"]!=null && row["Stock"].ToString()!="")
				{
					model.Stock=int.Parse(row["Stock"].ToString());
				}
				if(row["Img"]!=null)
				{
					model.Img=row["Img"].ToString();
				}
				if(row["ShelveDate"]!=null && row["ShelveDate"].ToString()!="")
				{
					model.ShelveDate=DateTime.Parse(row["ShelveDate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProID,CTID,BraID,ProName,Price,SalePoint,Des,Stock,Img,ShelveDate ");
			strSql.Append(" FROM T_Products ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ProID,CTID,BraID,ProName,Price,SalePoint,Des,Stock,Img,ShelveDate ");
			strSql.Append(" FROM T_Products ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Products ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int pageIndex, int pageSize)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProID Desc");
			}
			strSql.Append(")AS Row, T.*  from T_Products T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (pageIndex - 1) * pageSize + 1, pageIndex * pageSize);
			return DbHelperSQL.Query(strSql.ToString());
		}

        
         /// <summary>
        /// 分页获取数据列表
         /// </summary>
         /// <param name="PageSize"></param>
         /// <param name="PageIndex"></param>
         /// <param name="strWhere"></param>
         /// <returns></returns>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_Products";
            parameters[1].Value = "ProID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

		#endregion  BasicMethod


		#region  ExtensionMethod

        /// <summary>
        /// 获得含有类型、品牌名称的数据列表
        /// </summary>
        public DataSet GetProducts(string strWhere, string orderby, int pageIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by p." + orderby);
            }
            else
            {
                strSql.Append("order by p.ProID Desc");
            }
            strSql.Append(@")AS Row, p.*,b.BraName,ct.TID,ct.CTName,t.TName  from T_Products p left join T_Brand b on p.BraID = b.BraID
							                                                            left join T_CType ct on p.CTID = ct.CTID
							                                                            left join T_Type t on ct.TID = t.TID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", pageIndex * pageSize + 1, (pageIndex + 1) * pageSize);
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

