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
        public List<city> selectCity(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from city ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,name ,code ,sort ");
            sbSQL.Append(" from city ");

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

            List<city> listCityModel = new List<city>();
            city cityModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                cityModel = new city();
                cityModel.intId = dr.GetInt32(0);
                cityModel.charId = dr.GetGuid(1).ToString();
                cityModel.name = dr.GetString(2);
                cityModel.code = dr.GetString(3);
                cityModel.sort = dr.GetInt16(4);
                listCityModel.Add(cityModel);
            }
            dr.Close();

            return listCityModel;
        }

        public city selectCityByCharId(String charId)
        {
            city cityModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,name ,code ,sort ");
            sbSQL.Append(" from city ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                cityModel = new city();
                cityModel.intId = dr.GetInt32(0);
                cityModel.charId = dr.GetGuid(1).ToString();
                cityModel.name = dr.GetString(2);
                cityModel.code = dr.GetString(3);
                cityModel.sort = dr.GetInt16(4);
            }
            dr.Close();
            return cityModel;
        }

        public Int32 insertCity(city cityModel)
        {
            return query.instance().insert(cityModel);
        }

        public Int32 updateCity(city cityModel)
        {
            return query.instance().update(cityModel);
        }

        public Int32 deleteCity(city cityModel)
        {
            return query.instance().delete(cityModel);
        }
    }
}
