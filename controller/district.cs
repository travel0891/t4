﻿using System;
using System.Collections.Generic;
using System.Text;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public List<district> selectDistrict()
        {
            Int32 dataCount = 0, pageCount = 0;
            String orderString = "sort asc";
            return entityProvider.instance().selectDistrict(null, int.MaxValue, 1, out dataCount, out pageCount, orderString, null);
        }

        private static controllerProvider controller = null;

        private controllerProvider() { }

        public static controllerProvider instance()
        {
            return controller == null ? new controllerProvider() : controller;
        }
    }
}