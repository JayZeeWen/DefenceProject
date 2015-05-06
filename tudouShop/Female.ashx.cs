using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using 土豆购物;

namespace EShop
{
    /// <summary>
    /// Female 的摘要说明
    /// </summary>
    public class Female : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable bag = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID = 4");
            DataTable Perfume = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID = 5");
            DataTable cloth = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID =6");
            var data = new
            {
                bag1 = bag.Rows[0],
                bag2 = bag.Rows[1],
                bag3 = bag.Rows[2],
                bag4 = bag.Rows[3],
                bag5 = bag.Rows[4],
                bag6 = bag.Rows[5],
                Perfume1 = Perfume.Rows[0],
                Perfume2 = Perfume.Rows[1],
                Perfume3 = Perfume.Rows[2],
                Perfume4 = Perfume.Rows[3],
                Perfume5 = Perfume.Rows[4],
                Perfume6 = Perfume.Rows[5],
                cloth1 = cloth.Rows[0],
                cloth2 = cloth.Rows[1],
                cloth3 = cloth.Rows[2],
                cloth4 = cloth.Rows[3],
                cloth5 = cloth.Rows[4],
                cloth6 = cloth.Rows[5],
            };
            string html = CommandHelper.RenderHtml("Front/Female.html", data);
            context.Response.Write(html);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}