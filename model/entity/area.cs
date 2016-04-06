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
        public List<area> selectArea(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from area ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,district_charId ,name ,sort ");
            sbSQL.Append(" from area ");

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

            List<area> listAreaModel = new List<area>();
            area areaModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                areaModel = new area();
                areaModel.intId = dr.GetInt32(0);
                areaModel.charId = dr.GetGuid(1).ToString();
                areaModel.district_charId = dr.GetGuid(2).ToString();
                areaModel.name = dr.GetString(3);
                areaModel.sort = dr.GetInt16(4);
                listAreaModel.Add(areaModel);
            }
            dr.Close();

            return listAreaModel;
        }

        public area selectAreaByCharId(String charId)
        {
            area areaModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,district_charId ,name ,sort ");
            sbSQL.Append(" from area ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                areaModel = new area();
                areaModel.intId = dr.GetInt32(0);
                areaModel.charId = dr.GetGuid(1).ToString();
                areaModel.district_charId = dr.GetGuid(2).ToString();
                areaModel.name = dr.GetString(3);
                areaModel.sort = dr.GetInt16(4);
            }
            dr.Close();
            return areaModel;
        }

        public Int32 insertArea(area areaModel)
        {
            return query.instance().insert(areaModel);
        }

        public Int32 updateArea(area areaModel)
        {
            return query.instance().update(areaModel);
        }

        public Int32 deleteArea(area areaModel)
        {
            return query.instance().delete(areaModel);
        }
    }
}
