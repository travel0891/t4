using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace model.entity
{
    using model.table;
    using model.utils;

    public partial class entityProvider 
    {
        public List<district> selectDistrict(district whereModel, Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from district ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,city_charId ,name ,sort ");
            sbSQL.Append(" from district ");

            String whereSQL = String.Empty;
            IDbDataParameter[] parameter = query.instance().builderParameter(out whereSQL, param);

            StringBuilder pageSQL = new StringBuilder();
            pageIndex = pageIndex > 0 ? pageIndex - 1 : 0;
            if (pageIndex > 0)
            {
                pageSQL.Append(" and intId > ");
                pageSQL.AppendFormat(" ( select max(intId) from (select top {0} intId from area {1} order by intId ) as dataList ) ", pageIndex * pageSize, whereSQL);
            }

            StringBuilder orderSQL = new StringBuilder();
            orderSQL.AppendFormat(" order by {0} ", String.IsNullOrEmpty(orderString) ? "intId asc" : orderString);

            List<district> listDistrictModel = new List<district>();
            district districtModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                districtModel = new district();
                districtModel.intId = dr.GetInt32(0);
                districtModel.charId = dr.GetGuid(1).ToString();
                districtModel.city_charId = dr.GetGuid(2).ToString();
                districtModel.name = dr.GetString(3);
                districtModel.sort = dr.GetInt16(4);
                listDistrictModel.Add(districtModel);
            }
            dr.Close();

            return listDistrictModel;
        }

        public district selectDistrictByCharId(String charId)
        {
            district districtModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,city_charId ,name ,sort ");
            sbSQL.Append(" from district ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                districtModel = new district();
                districtModel.intId = dr.GetInt32(0);
                districtModel.charId = dr.GetGuid(1).ToString();
                districtModel.city_charId = dr.GetGuid(2).ToString();
                districtModel.name = dr.GetString(3);
                districtModel.sort = dr.GetInt16(4);
            }
            dr.Close();
            return districtModel;
        }

        public Int32 insertDistrict(district districtModel)
        {
            return query.instance().insert(districtModel);
        }

        public Int32 updateDistrict(district districtModel)
        {
            return query.instance().update(districtModel);
        }

        public Int32 deleteDistrict(district districtModel)
        {
            return query.instance().delete(districtModel);
        }

        private static entityProvider entity = null;

        private entityProvider() { }

        public static entityProvider instance()
        {
            return entity == null ? new entityProvider() : entity;
        }
    }
}
