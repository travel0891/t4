using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace view
{
    using model.table;
    using controller;

    public partial class main1 : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            List<district> listDistrict = controllerProvider.instance().selectDistrict();

            html.Append("<ul>");

            foreach (district districtItem in listDistrict)
            {
                html.AppendFormat("<li>{0} {1} {2} {3}</li>", districtItem.charId, districtItem.intId, districtItem.name, districtItem.sort);
            }

            html.Append("</ul>");

            Response.Write(html.ToString());
            Response.End();
        }
    }
}