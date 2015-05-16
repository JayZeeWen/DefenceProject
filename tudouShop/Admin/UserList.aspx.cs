using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EShop.BLL;

namespace tudouShop.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(UserList));
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
        }

        private DataTable GetSourceTable()
        {
            EShop.BLL.T_Users userBLl = new EShop.BLL.T_Users();
            string condition = " state != -1";
            //获取数据总条数
            Grid1.RecordCount = userBLl.GetRecordCount(condition);
            //获取分页数据
            DataTable dt = userBLl.GetListByPage(condition, "UserID", Grid1.PageIndex * Grid1.PageSize, (Grid1.PageIndex + 1) * Grid1.PageSize).Tables[0];

            return dt;
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
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

            //labResult.Text = "用户修改的数据：" + Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.None);

            Alert.Show("数据保存成功!");
        }

        protected string GetEditUrl(object id, object name)
        {
            return InfoWindows.GetShowReference("userInfo.aspx?id=" + id, "编辑 - " + name);
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int rowID = Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0].ToString());
                EShop.BLL.T_Users userbll = new EShop.BLL.T_Users();
                EShop.Model.T_Users user = userbll.GetModel(rowID);
                user.state = 1;
                userbll.Update(user);
                Alert.Show("成功激活");
                BindGrid();
            }
        }

        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetSourceTable();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ProId"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }

        private static void UpdateDataRow(Dictionary<string, object> rowDict, DataRow rowData)
        {
            EShop.BLL.T_Products probll = new EShop.BLL.T_Products();
            EShop.Model.T_Products pro = probll.GetModel(Convert.ToInt32(rowData["ProID"]));

            // 商品名称
            if (rowDict.ContainsKey("ProName"))
            {
                pro.ProName = Convert.ToString(rowDict["ProName"]);
            }

            // 商品价格
            if (rowDict.ContainsKey("Price"))
            {
                pro.Price = Convert.ToDecimal(rowDict["Price"]);
            }

            // 销售积分
            if (rowDict.ContainsKey("SalePoint"))
            {
                pro.SalePoint = Convert.ToInt32(rowDict["SalePoint"]);
            }

            // 库存
            if (rowDict.ContainsKey("Stock"))
            {
                pro.Stock = Convert.ToInt32(rowDict["Stock"]);
            }

            // 品牌
            if (rowDict.ContainsKey("BraID"))
            {
                pro.BraID = Convert.ToInt32(rowDict["BraID"]);
            }
            // 上架日期
            if (rowDict.ContainsKey("ShelveDate"))
            {
                pro.ShelveDate = Convert.ToDateTime(rowDict["ShelveDate"]);
            }
            probll.Update(pro);

        }
    }
}