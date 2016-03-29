using System;

namespace model.table
{
    using model.utils;

    public class company : baseTable
    {
        /// <summary> 
        /// 城市charId UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String city_charId { get; set; }

        /// <summary> 
        /// 区域charId UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String district_charId { get; set; }

        /// <summary> 
        /// 公司地址 VARCHAR 200    
        /// </summary> 
        public String address { get; set; }

        /// <summary> 
        /// 系统负责人姓名 VARCHAR 50    
        /// </summary> 
        public String name { get; set; }

        /// <summary> 
        /// 系统负责人手机号码 CHAR 11    
        /// </summary> 
        public String telephone { get; set; }

        /// <summary> 
        /// 启用状态 1：正常 2：欠费 3：停用 SMALLINT 2    
        /// </summary> 
        public Int16 state { get; set; }

        /// <summary> 
        /// 授权密钥 VARCHAR 16    
        /// </summary> 
        public String secretKey { get; set; }
    }
}
