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

            List<district> listDistrict = controllerProvider.instance().searchDistrict();

            foreach (district districtItem in listDistrict)
            {
                html.AppendFormat("<ul>{0}", districtItem.name);

                List<area> listArea = controllerProvider.instance().searchArea(districtItem);

                foreach (area areaItem in listArea)
                {
                    html.AppendFormat("<li>{0}</li>", areaItem.name);
                }

                html.Append("</ul>");
            }

            Response.Write(html.ToString());
            Response.End();
        }
    }
}