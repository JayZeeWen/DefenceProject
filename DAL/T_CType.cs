﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EShop.DBUtility;//Please add references
namespace EShop.DAL
{
	/// <summary>
	/// 数据访问类:T_CType
	/// </summary>
	public partial class T_CType
	{
		public T_CType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CType");
			strSql.Append(" where CTID=@CTID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CTID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EShop.Model.T_CType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CType(");
			strSql.Append("CTID,TID,CTName)");
			strSql.Append(" values (");
			strSql.Append("@CTID,@TID,@CTName)");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8),
					new SqlParameter("@TID", SqlDbType.BigInt,8),
					new SqlParameter("@CTName", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.CTID;
			parameters[1].Value = model.TID;
			parameters[2].Value = model.CTName;

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
		public bool Update(EShop.Model.T_CType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CType set ");
			strSql.Append("TID=@TID,");
			strSql.Append("CTName=@CTName");
			strSql.Append(" where CTID=@CTID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.BigInt,8),
					new SqlParameter("@CTName", SqlDbType.NVarChar,20),
					new SqlParameter("@CTID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.TID;
			parameters[1].Value = model.CTName;
			parameters[2].Value = model.CTID;

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
		public bool Delete(long CTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CType ");
			strSql.Append(" where CTID=@CTID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CTID;

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
		public bool DeleteList(string CTIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CType ");
			strSql.Append(" where CTID in ("+CTIDlist + ")  ");
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
		public EShop.Model.T_CType GetModel(long CTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CTID,TID,CTName from T_CType ");
			strSql.Append(" where CTID=@CTID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CTID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CTID;

			EShop.Model.T_CType model=new EShop.Model.T_CType();
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
		public EShop.Model.T_CType DataRowToModel(DataRow row)
		{
			EShop.Model.T_CType model=new EShop.Model.T_CType();
			if (row != null)
			{
				if(row["CTID"]!=null && row["CTID"].ToString()!="")
				{
					model.CTID=long.Parse(row["CTID"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=long.Parse(row["TID"].ToString());
				}
				if(row["CTName"]!=null)
				{
					model.CTName=row["CTName"].ToString();
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
			strSql.Append("select CTID,TID,CTName ");
			strSql.Append(" FROM T_CType ");
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
			strSql.Append(" CTID,TID,CTName ");
			strSql.Append(" FROM T_CType ");
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
			strSql.Append("select count(1) FROM T_CType ");
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
				strSql.Append("order by T.CTID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CType T ");
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
			parameters[0].Value = "T_CType";
			parameters[1].Value = "CTID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

