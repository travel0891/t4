using System;
using System.Collections.Generic;
using System.Text;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public List<city> searchCity()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectCity(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }
    }
}