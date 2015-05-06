using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 土豆购物;

namespace FineUI.Examples
{
    /// <summary>
    /// Special2 的摘要说明
    /// </summary>
    public class Special2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string html = CommandHelper.RenderHtml("Front/Special2.html",null);
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