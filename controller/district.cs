using System;
using System.Collections.Generic;
using System.Text;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public List<district> searchDistrict()
        {
            Int32 dataCount = 0, pageCount = 0;
            String orderString = "sort asc";
            return entityProvider.instance().selectDistrict(Int32.MaxValue, 1, out dataCount, out pageCount, orderString, null);
        }

        public List<district> searchDistrict(city cityModel)
        {
            Int32 dataCount = 0, pageCount = 0;
            Object[] whereArray = { "and", "city_charId", "=", cityModel.charId };
            String orderString = "sort asc";
            return entityProvider.instance().selectDistrict(Int32.MaxValue, 1, out dataCount, out pageCount, orderString, whereArray);
        }

        private static controllerProvider controller = null;

        private controllerProvider() { }

        public static controllerProvider instance()
        {
            return controller == null ? new controllerProvider() : controller;
        }
    }
}