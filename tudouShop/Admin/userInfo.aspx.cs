using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tudouShop.Admin
{
    public partial class userInfo : System.Web.UI.Page
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
                if (!string.IsNullOrEmpty(pro.Price.ToString()))
                {
                    nbxPrice.Text = pro.Price.ToString();
                }
                if (!string.IsNullOrEmpty(pro.Stock.ToString()))
                {
                    nbxStack.Text = pro.Stock.ToString();
                }
                if (!string.IsNullOrEmpty(pro.SalePoint.ToString()))
                {
                    nbxSalePoint.Text = pro.SalePoint.ToString();
                }
                dtpShelveDate.SelectedDate = pro.ShelveDate;
                if(!string.IsNullOrEmpty(pro.BraID.ToString()))
                {
                    ddlBrand.SelectedValue = pro.BraID.ToString();
                }
                txtDesc.Text = pro.Des;
                
 
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
            pro.Price = Convert.ToDecimal(nbxPrice.Text);
            pro.Stock = Convert.ToInt32(nbxStack.Text);
            pro.Des = txtDesc.Text;
            pro.ShelveDate = dtpShelveDate.SelectedDate;
            pro.BraID =Convert.ToInt32( ddlBrand.SelectedValue);
            pro.SalePoint = Convert.ToInt32(nbxSalePoint.Text);
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