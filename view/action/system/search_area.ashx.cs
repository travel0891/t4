using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using model.table;
using controller;
using System.Threading;

namespace view.action.system
{
    /// <summary>
    /// search_area 的摘要说明
    /// </summary>
    public class search_area : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            String action = context.Request.QueryString["action"];
            // Thread.Sleep(2000);
            switch (action)
            {
                case "searchAreaByDistrictCharId":
                    if (!String.IsNullOrEmpty(context.Request.QueryString["districtCharId"]))
                    {
                        StringBuilder areaHtml = new StringBuilder();
                        district districtModel = new district();
                        districtModel.charId = context.Request.QueryString["districtCharId"];
                        List<area> listArea = controllerProvider.instance().searchArea(districtModel);
                        areaHtml = new StringBuilder();
                        areaHtml.Append("<table class=\"table table-hover\">");
                        areaHtml.Append("<tbody>");
                        if (listArea.Count == 0)
                        {
                            areaHtml.Append("<tr><td class=\"text-center\" colspan=\"2\">暂无商圈</td></tr>");
                        }
                        else
                        {
                            foreach (area areaItem in listArea)
                            {
                                areaHtml.Append("<tr>");
                                areaHtml.AppendFormat("<td class=\"text-left\">{0}</td>", areaItem.name);
                                areaHtml.AppendFormat("<td class=\"text-right\"><a herf=\"{0}\">编辑</a><a class=\"ml14\" herf=\"{0}\">删除</a></td>", areaItem.charId);
                                areaHtml.Append("</tr>");
                            }
                        }
                        areaHtml.Append("</tbody>");
                        areaHtml.Append("</table>");
                        context.Response.Write(areaHtml.ToString());
                        context.Response.End();
                    }
                    break;
                default:
                    break;
            }
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