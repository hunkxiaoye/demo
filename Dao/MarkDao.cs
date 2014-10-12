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
    public partial class MarkDao
    {
        public Mark Add
            (Mark mark)
        {
            string sql = "INSERT INTO Mark (Markname, Markurl)  output inserted.id VALUES (@Markname, @Markurl)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@markname", ToDBValue(mark.Markname)),
						new SqlParameter("@markurl", ToDBValue(mark.Markurl)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE Mark WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Mark mark)
        {
            string sql =
                "UPDATE Mark " +
                "SET " +
            " markname = @markname"
                + ", Markurl = @markurl"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", mark.Id)
					,new SqlParameter("@markname", ToDBValue(mark.Markname))
					,new SqlParameter("@markurl", ToDBValue(mark.Markurl))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Mark GetById(int id)
        {
            string sql = "SELECT * FROM Mark WHERE Id = @Id";
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

        public Mark ToModel(SqlDataReader reader)
        {
            Mark mark = new Mark();

            mark.Id = (int)ToModelValue(reader, "Id");
            mark.Markname = (string)ToModelValue(reader, "Markname");
            mark.Markurl = (string)ToModelValue(reader, "Markurl");
            return mark;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM Mark";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IList<Mark> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM Mark) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IList<Mark> GetAll()
        {
            string sql = "SELECT * FROM Mark";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IList<Mark> ToModels(SqlDataReader reader)
        {
            var list = new List<Mark>();
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
