using System;
using System.Collections.Generic;
using System.Text;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public List<area> searchArea()
        {
            Int32 dataCount = 0, pageCount = 0;
            String orderString = "sort asc";
            return entityProvider.instance().selectArea(Int32.MaxValue, 1, out dataCount, out pageCount, orderString, null);
        }

        public List<area> searchArea(district districtModel)
        {
            Int32 dataCount = 0, pageCount = 0;
            Object[] whereArray = { "and", "district_charId", "=", districtModel.charId };
            String orderString = "sort asc";
            return entityProvider.instance().selectArea(Int32.MaxValue, 1, out dataCount, out pageCount, orderString, whereArray);
        }
    }
}