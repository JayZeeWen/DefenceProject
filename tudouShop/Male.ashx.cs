using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 土豆购物
{
    /// <summary>
    /// Male 的摘要说明
    /// </summary>
    public class Male : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable bag = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID = 1 ");
            DataTable watch = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID = 2 ");
            DataTable cloth = SqlHelper.ExecuteDataTable("select top 6 * from t_Products where CTID =3");

            var data = new
            {
                bag1 = bag.Rows[0],
                bag2 = bag.Rows[1],
                bag3 = bag.Rows[2],
                bag4 = bag.Rows[3],
                bag5 = bag.Rows[4],
                bag6 = bag.Rows[5],
                watch1 = watch.Rows[0],
                watch2 = watch.Rows[1],
                watch3 = watch.Rows[2],
                watch4 = watch.Rows[3],
                watch5 = watch.Rows[4],
                watch6 = watch.Rows[5],
                cloth1 = cloth.Rows[0],
                cloth2 = cloth.Rows[1],
                cloth3 = cloth.Rows[2],
                cloth4 = cloth.Rows[3],
                cloth5 = cloth.Rows[4],
                cloth6 = cloth.Rows[5],
            };
            string html = CommandHelper.RenderHtml("Front/Male.html", data);
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