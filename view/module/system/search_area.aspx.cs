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

            html.AppendFormat("<a class=\"tal btn btn-primary\">{0}上海市</a>"
                , "<span id=\"districtSettings\" class=\"right lh20 glyphicon glyphicon-cog\"></span>");

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