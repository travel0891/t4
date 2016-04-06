using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace view.module.system
{
    using model.table;
    using controller;

    public partial class search_area : viewBase
    {
        protected String districtList = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            List<district> listDistrict = controllerProvider.instance().searchDistrict();

            html.AppendFormat("<a href=\"javascript:;\" class=\"tal btn btn-primary\" type=\"button\">{0}上海市</a>", "<span onclick=\"javascript:alert('上海市')\" class=\"right lh20 glyphicon glyphicon-cog\" aria-hidden=\"true\"></span>");

            foreach (district districtItem in listDistrict)
            {
                html.AppendFormat("<a href=\"?charId={0}&district={1}\" class=\"btn btn-default btn-{0}\" type=\"button\">{1}</a>", districtItem.charId, districtItem.name);

                List<area> listArea = controllerProvider.instance().searchArea(districtItem);

                foreach (area areaItem in listArea)
                {
                    // html.AppendFormat("<li>{0}</li>", areaItem.name);
                }
            }

            districtList = html.ToString();
            // Response.Write(html.ToString());
            // Response.End();
        }
    }
}