using System;

namespace model.table
{
    using model.utils;

    public class city : baseTable
    {
        /// <summary> 
        /// 城市名称 VARCHAR 12    
        /// </summary> 
        public String name { get; set; }

        /// <summary> 
        /// 城市区号 VARCHAR 4    
        /// </summary> 
        public String code { get; set; }

        /// <summary> 
        /// 城市排序 SMALLINT 2    
        /// </summary> 
        public Int16 sort { get; set; }
    }
}
