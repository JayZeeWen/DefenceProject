using EShop.BLL;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 土豆购物;

namespace tudouShop
{
    public partial class Payment : System.Web.UI.Page
    {
        long x;
        public long LoginID
        {

            get
            {
                if (Session["LoginUser"] != null)
                {
                    x = long.Parse(Session["LoginUser"].ToString());

                }
                return x;
            }
        }         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginID != 0)
            {
              
                BindAddressDataSource();
                BindCartDataSource();
            }
            else
            {
                nullsession();
            }
        }
    

        public void BindAddressDataSource()
        {
            EShop.BLL.T_DeliveryAddress deliverbll = new T_DeliveryAddress();
            rptAddress.DataSource = deliverbll.GetList(1, "", "id");
            rptAddress.DataBind();
        }
        public void BindCartDataSource()
        {            
            int totalcount = Convert.ToInt32(SqlHelper.ExecuteScalar("select COUNT(*) from T_Cart where UserID=@UserID", new SqlParameter("@UserID", LoginID)));           
            //总价
            decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                       select c.Userid as UserID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                                       where  UserID= @UserId", new SqlParameter("@UserId", LoginID)));
            ltlTotal.Text = "$" + money;
            decimal moneyaccount = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select Assets from t_Users where  UserID= @UserId"
                                                 , new SqlParameter("@UserId", LoginID)));
            ltlbalance.Text = "$" + moneyaccount;
            string name = Convert.ToString(SqlHelper.ExecuteScalar("select Account from t_Users where UserID=@UserID", new SqlParameter("@UserID", LoginID)));
            Name.Text = name;
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string pfp = Context.Request["PFP"];
            DataTable dt = SqlHelper.ExecuteDataTable("select * from t_Users where PFP =@PFP and UserID= @UserId"
                                                   , new SqlParameter("@PFP", pfp), new SqlParameter("@UserId", LoginID));
             decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                       select c.Userid as UserID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                                       where  UserID= @UserId", new SqlParameter("@UserId", LoginID)));
             decimal moneyaccount = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select Assets from t_Users where  UserID= @UserId"
                                                 , new SqlParameter("@UserId", LoginID)));
            
            if (dt.Rows.Count == 1)
            {
                if(moneyaccount>=money)
                {
                    moneyaccount = moneyaccount - money;
                    SqlHelper.ExecuteScalar(@"update t_Users set Assets=@moneyaccount where  UserID= @UserId"
                                                 , new SqlParameter("@moneyaccount", moneyaccount), new SqlParameter("@UserId", LoginID));
                    SqlHelper.ExecuteScalar(@"delete T_Cart  where  UserID= @UserId"
                                                 , new SqlParameter("@UserId", LoginID));
                    Response.Redirect("~/Success.aspx");
                }
                else
                {
                    lblerror.Text = "余额不足";
                }
            }
            else if (dt.Rows.Count == 0)
            {
                lblerror.Text = "请输入正确密码";
                              
            }
            else
            {
                Alert.ShowInTop("找到多条数据，请联系技术人员");
            }
           
        }
        protected void submitsec_Click(object sender, EventArgs e)
        {         
            string Addmoney = Context.Request["money"];          
            decimal moneyaccount = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select Assets from t_Users where  UserID= @UserId"
                                                , new SqlParameter("@UserId", LoginID)));
            moneyaccount = moneyaccount + decimal.Parse(Addmoney);
            SqlHelper.ExecuteScalar(@"update t_Users set Assets=@moneyaccount where  UserID= @UserId"
                                                 , new SqlParameter("@moneyaccount", moneyaccount), new SqlParameter("@UserId", LoginID));          
            Response.Redirect("~/Payment.aspx");
            
        }
        public void nullsession()
        {
            Response.Redirect("~/aspx/Login.aspx");
        }
    }
}