//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Dao
{
    public partial class AttrDao
    {
        public Attr Add
            (Attr attr)
        {
            string sql = "INSERT INTO Attr (Attrname)  output inserted.id VALUES (@Attrname)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@attrname", ToDBValue(attr.Attrname)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE Attr WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Attr attr)
        {
            string sql =
                "UPDATE Attr " +
                "SET " +
            " attrname = @attrname"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", attr.Id)
					,new SqlParameter("@attrname", ToDBValue(attr.Attrname))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Attr GetById(int id)
        {
            string sql = "SELECT * FROM Attr WHERE Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public Attr ToModel(SqlDataReader reader)
        {
            Attr attr = new Attr();

            attr.Id = (int)ToModelValue(reader, "Id");
            attr.Attrname = (string)ToModelValue(reader, "Attrname");
            return attr;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM Attr";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IList<Attr> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM Attr) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IList<Attr> GetAll()
        {
            string sql = "SELECT * FROM Attr";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IList<Attr> ToModels(SqlDataReader reader)
        {
            var list = new List<Attr>();
            while (reader.Read())
            {
                list.Add(ToModel(reader));
            }
            return list;
        }

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        protected object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }
    }
}
