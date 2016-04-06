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
        public List<company> selectCompany(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from company ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,city_charId ,district_charId ,address ,name ,telephone ,state ,secretKey ");
            sbSQL.Append(" from company ");

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

            List<company> listCompanyModel = new List<company>();
            company companyModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                companyModel = new company();
                companyModel.intId = dr.GetInt32(0);
                companyModel.charId = dr.GetGuid(1).ToString();
                companyModel.city_charId = dr.GetGuid(2).ToString();
                companyModel.district_charId = dr.GetGuid(3).ToString();
                companyModel.address = dr.GetString(4);
                companyModel.name = dr.GetString(5);
                companyModel.telephone = dr.GetString(6);
                companyModel.state = dr.GetInt16(7);
                companyModel.secretKey = dr.GetString(8);
                listCompanyModel.Add(companyModel);
            }
            dr.Close();

            return listCompanyModel;
        }

        public company selectCompanyByCharId(String charId)
        {
            company companyModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,city_charId ,district_charId ,address ,name ,telephone ,state ,secretKey ");
            sbSQL.Append(" from company ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                companyModel = new company();
                companyModel.intId = dr.GetInt32(0);
                companyModel.charId = dr.GetGuid(1).ToString();
                companyModel.city_charId = dr.GetGuid(2).ToString();
                companyModel.district_charId = dr.GetGuid(3).ToString();
                companyModel.address = dr.GetString(4);
                companyModel.name = dr.GetString(5);
                companyModel.telephone = dr.GetString(6);
                companyModel.state = dr.GetInt16(7);
                companyModel.secretKey = dr.GetString(8);
            }
            dr.Close();
            return companyModel;
        }

        public Int32 insertCompany(company companyModel)
        {
            return query.instance().insert(companyModel);
        }

        public Int32 updateCompany(company companyModel)
        {
            return query.instance().update(companyModel);
        }

        public Int32 deleteCompany(company companyModel)
        {
            return query.instance().delete(companyModel);
        }
    }
}
