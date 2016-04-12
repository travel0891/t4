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
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<a class=\"tal btn btn-primary\">");
            html.AppendFormat("<span id=\"districtSettings\" data-charid=\"{0}\" class=\"right lh20 glyphicon glyphicon-cog\"></span>", "F1DAADB8-FA99-49C5-854F-CE10CB44545B");
            html.Append("上海市</a>");

            List<district> listDistrict = controllerProvider.instance().searchDistrict();
            foreach (district districtItem in listDistrict)
            {
                html.AppendFormat("<a href=\"javascript:;\" class=\"btn district btn-default\" data-charid=\"{0}\" data-name=\"{1}\">{1}</a>"
                    , districtItem.charId, districtItem.name);
            }

            districtListId.InnerHtml = html.ToString();
        }
    }
}