using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EShop.DBUtility;//Please add references
namespace EShop.DAL
{
	/// <summary>
	/// 数据访问类:T_Orders
	/// </summary>
	public partial class T_Orders
	{
		public T_Orders()
		{}
		#region  BasicMethod

        public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Orders");
            strSql.Append(" where ");
            strSql.Append(" OrderID = @OrderID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt)
			};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(EShop.Model.T_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Orders(");
            strSql.Append("UserID,OrderDate,Address,state");
            strSql.Append(") values (");
            strSql.Append("@UserID,@OrderDate,@Address,@state");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@OrderDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Address", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@state", SqlDbType.Char,1)             
              
            };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrderDate;
            parameters[2].Value = model.Address;
            parameters[3].Value = model.state;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt64(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EShop.Model.T_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Orders set ");

            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" OrderDate = @OrderDate , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" state = @state  ");
            strSql.Append(" where OrderID=@OrderID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@OrderID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@OrderDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Address", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@state", SqlDbType.Char,1)             
              
            };

            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.OrderDate;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.state;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(long OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Orders ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt)
			};
            parameters[0].Value = OrderID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Orders ");
            strSql.Append(" where ID in (" + OrderIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public EShop.Model.T_Orders GetModel(long OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID, UserID, OrderDate, Address, state  ");
            strSql.Append("  from T_Orders ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt)
			};
            parameters[0].Value = OrderID;


            EShop.Model.T_Orders model = new EShop.Model.T_Orders();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = long.Parse(ds.Tables[0].Rows[0]["Address"].ToString());
                }
                model.state = ds.Tables[0].Rows[0]["state"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM T_Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append("select count(1) FROM T_Orders ");
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
				strSql.Append("order by T.OrderID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Orders T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
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
			parameters[0].Value = "T_Orders";
			parameters[1].Value = "OrderID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        public DataSet GetOrderDataSet(string strWhere, string orderby, int pageIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by p." + orderby+" desc");
            }
            else
            {
                strSql.Append("order by p.p.OrderDate desc");
            }
            strSql.Append(@")AS Row,p.*,tu.Account,tda.NAME,tda.[Address] AS deliverAddress,tda.Phone
                                                                        FROM T_Orders AS p 
						                                                LEFT JOIN T_Users AS tu ON P.UserID=tu.UserID
						                                                LEFT JOIN T_DeliveryAddress AS tda ON tda.id = p.[Address] ");
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

