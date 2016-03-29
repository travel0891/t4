using System;

namespace model.table
{
    using model.utils;

    public class district : baseTable
    {
        /// <summary> 
        /// 城市charId UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String city_charId { get; set; }

        /// <summary> 
        /// 区域名称 VARCHAR 12    
        /// </summary> 
        public String name { get; set; }

        /// <summary> 
        /// 区域排序 SMALLINT 2    
        /// </summary> 
        public Int16 sort { get; set; }
    }
}
