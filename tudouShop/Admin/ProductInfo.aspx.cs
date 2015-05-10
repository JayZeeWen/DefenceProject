using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EShop.BLL;
using EShop.Model;

namespace tudouShop.Admin
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        //0:新增 1：修改
        private int type
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["t"]);
            }
        }

        private int ProID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["id"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            if (type == 1 && ProID != -1)
            {
                EShop.BLL.T_Products probll = new EShop.BLL.T_Products();
                EShop.Model.T_Products pro = probll.GetModel(ProID);
                txtProName.Text = pro.ProName;
                txtPrice.Text = pro.Price.ToString();
 
            }
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 保存窗体中数据的逻辑
            EShop.BLL.T_Products probll = new EShop.BLL.T_Products ();
            EShop.Model.T_Products pro;
            if (type == 0)
            {
                pro = new EShop.Model.T_Products();
            }
            else
            {
                pro = probll.GetModel(ProID);
            }
            pro.ProName = txtProName.Text;
            pro.Price = Convert.ToInt32(txtPrice.Text);

            if (type == 0)
            {
                probll.Add(pro);
            }
            else
            {
                probll.Update(pro);
            }
            // 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
    }
}