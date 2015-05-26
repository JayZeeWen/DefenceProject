using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using EShop.DBUtility;
namespace EShop.DAL
{
    //T_DeliveryAddress
    public partial class T_DeliveryAddress
    {

        public bool Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_DeliveryAddress");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(EShop.Model.T_DeliveryAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_DeliveryAddress(");
            strSql.Append("UserID,Name,Phone,PostCode,Address");
            strSql.Append(") values (");
            strSql.Append("@UserID,@Name,@Phone,@PostCode,@Address");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.NVarChar,25) ,            
                        new SqlParameter("@PostCode", SqlDbType.Int,4) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,200)             
              
            };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.PostCode;
            parameters[4].Value = model.Address;

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
        public bool Update(EShop.Model.T_DeliveryAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_DeliveryAddress set ");

            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" PostCode = @PostCode , ");
            strSql.Append(" Address = @Address  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.NVarChar,25) ,            
                        new SqlParameter("@PostCode", SqlDbType.Int,4) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,200)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.PostCode;
            parameters[5].Value = model.Address;
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
        public bool Delete(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_DeliveryAddress ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
            parameters[0].Value = id;


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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_DeliveryAddress ");
            strSql.Append(" where ID in (" + idlist + ")  ");
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
        public EShop.Model.T_DeliveryAddress GetModel(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, UserID, Name, Phone, PostCode, Address  ");
            strSql.Append("  from T_DeliveryAddress ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)
			};
            parameters[0].Value = id;


            EShop.Model.T_DeliveryAddress model = new EShop.Model.T_DeliveryAddress();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["PostCode"].ToString() != "")
                {
                    model.PostCode = int.Parse(ds.Tables[0].Rows[0]["PostCode"].ToString());
                }
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();

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
            strSql.Append(" FROM T_DeliveryAddress ");
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
            strSql.Append(" FROM T_DeliveryAddress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetRowByID(int id)
        {
            string sql = @"SELECT * FROM T_DeliveryAddress WHERE id = " + id.ToString();
            return DbHelperSQL.Query(sql).Tables[0];
        }


    }
}

