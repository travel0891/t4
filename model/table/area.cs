using System;

namespace model.table
{
    using model.utils;

    public class area : baseTable
    {
        /// <summary> 
        /// 区域charId UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String district_charId { get; set; }

        /// <summary> 
        /// 商圈名称 VARCHAR 20    
        /// </summary> 
        public String name { get; set; }

        /// <summary> 
        /// 商圈排序 SMALLINT 2    
        /// </summary> 
        public Int16 sort { get; set; }
    }
}
