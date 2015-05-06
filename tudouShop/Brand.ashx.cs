using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace 土豆购物
{
    /// <summary>
    /// Brand 的摘要说明
    /// </summary>
    public class Brand : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable hots = SqlHelper.ExecuteDataTable("select top 6 * from T_Products where CTID in (select CTID from T_CType where TID = 5 ) order by ShelveDate");
            var data = new { hots = hots.Rows };

            string html = CommandHelper.RenderHtml("Front/Brand.html",data);
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