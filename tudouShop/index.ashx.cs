using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 土豆购物
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
           
            DataTable MalePro = SqlHelper.ExecuteDataTable("select top 4 * from T_Products where CTID in (select CTID from T_CType where TID = 1) order by shelveDate desc");
            DataTable FemalePro = SqlHelper.ExecuteDataTable("select top 4 * from T_Products where CTID in (select CTID from T_CType where TID = 2) order by shelveDate desc");
            DataTable EPro = SqlHelper.ExecuteDataTable("select top 4 * from T_Products where CTID in (select CTID from T_CType where TID = 3) order by shelveDate desc");
            DataTable LPro = SqlHelper.ExecuteDataTable("select top 4 * from T_Products where CTID in (select CTID from T_CType where TID = 4) order by shelveDate desc");
            DataTable BPro = SqlHelper.ExecuteDataTable("select top 4 * from T_Products where CTID in (select CTID from T_CType where TID = 5) order by shelveDate desc");           
            DataTable Brands = SqlHelper.ExecuteDataTable("select * from T_Brand");

            var data = new
            {
                Brands = Brands.Rows, 
                MalePro1 = MalePro.Rows[0], MalePro2 = MalePro.Rows[1], MalePro3 = MalePro.Rows[2], MalePro4 = MalePro.Rows[3],
                fp1 = FemalePro.Rows[0],fp2 = FemalePro.Rows[1],fp3 = FemalePro.Rows[2],fp4 = FemalePro.Rows[3],
                ep1 = EPro.Rows[0],ep2 = EPro.Rows[1],ep3 = EPro.Rows[2],ep4 = EPro.Rows[3],
                lp1 = LPro.Rows[0],lp2 = LPro.Rows[1],lp3 = LPro.Rows[2],lp4 = LPro.Rows[3],
                bp1 = BPro.Rows[0],bp2 = BPro.Rows[1],bp3 = BPro.Rows[2],bp4 = BPro.Rows[3]
                };
            string html = CommandHelper.RenderHtml("Front/Index.html", data);
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