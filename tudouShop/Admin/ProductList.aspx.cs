using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using Newtonsoft.Json.Linq;

namespace EShop
{
    public partial class ProductList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ProductList));
            if (!IsPostBack)
            {
                BindGrid();
                
                btnNew.OnClientClick = InfoWindows.GetShowReference("ProductInfo.aspx?t=0", "新增商品");
            }
        }

        private void BindGrid()
        {
            Grid1.DataSource = GetSourceTable();
            Grid1.DataBind();
            BindDropDownListDataSet();
        }

        private DataTable GetSourceTable()
        {
            BLL.T_Products proBLl = new BLL.T_Products();
            string condition = " state = 0";
            //获取数据总条数
            Grid1.RecordCount = proBLl.GetRecordCount(condition);
            //获取分页数据
            DataTable dt = proBLl.GetProducts(condition, "ProID", Grid1.PageIndex, Grid1.PageSize).Tables[0];

            return dt;  
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #region 绑定下拉列表数据源
        public void BindDropDownListDataSet()
        {
            //类型数据源
            BLL.T_Type typebll = new BLL.T_Type ();
            DataTable dt = typebll.GetAllList().Tables[0];
            ddlType.DataSource = dt;
            ddlType.DataTextField = "TName";
            ddlType.DataValueField = "TID";
            ddlType.DataBind();

            //品牌数据源
            BLL.T_Brand brandBll = new BLL.T_Brand();
            DataTable Branddt = brandBll.GetAllList().Tables[0];
            ddlBrand.DataSource = Branddt;
            ddlBrand.DataTextField = "BraName";
            ddlBrand.DataValueField = "BraID";
            ddlBrand.DataBind();
 
        }
        #endregion

        [AjaxPro.AjaxMethod]
        public string getTypeName(int TID)
        {
            BLL.T_Type typebll = new BLL.T_Type();
            Model.T_Type type = typebll.GetModel(TID);
            return type.TName;
        }

        [AjaxPro.AjaxMethod]
        public string getBrandName(int BID)
        {
            BLL.T_Brand bll = new BLL.T_Brand();
            Model.T_Brand brand = bll.GetModel(BID);
            return brand.BraName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();

            foreach (int rowIndex in modifiedDict.Keys)
            {
                int rowID = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                DataRow row = FindRowByID(rowID);

                UpdateDataRow(modifiedDict[rowIndex], row);
            }

            BindGrid();

            labResult.Text = "用户修改的数据：" + Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None);

            Alert.Show("数据保存成功！（表格数据已重新绑定）");
        }

        protected string GetEditUrl(object id, object name)
        {
            return InfoWindows.GetShowReference("ProductInfo.aspx?id=" + id, "编辑 - " + name);
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == "Del")
            {                
                int rowID = Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0].ToString());
                BLL.T_Products probll = new BLL.T_Products();
                probll.Delete(rowID);                
                Alert.Show("成功删除");
                BindGrid();
            }
        }

        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetSourceData();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }

        
    }
}