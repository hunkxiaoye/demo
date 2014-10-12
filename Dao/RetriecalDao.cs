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
    public partial class RetriecalDao
    {
        public Retriecal Add
            (Retriecal retriecal)
        {
            string sql = "INSERT INTO Retriecal (Rename)  output inserted.id VALUES (@Rename)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@rename", ToDBValue(retriecal.Rename)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE Retriecal WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Retriecal retriecal)
        {
            string sql =
                "UPDATE Retriecal " +
                "SET " +
            " rename = @rename"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", retriecal.Id)
					,new SqlParameter("@rename", ToDBValue(retriecal.Rename))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Retriecal GetById(int id)
        {
            string sql = "SELECT * FROM Retriecal WHERE Id = @Id";
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

        public Retriecal ToModel(SqlDataReader reader)
        {
            Retriecal retriecal = new Retriecal();

            retriecal.Id = (int)ToModelValue(reader, "Id");
            retriecal.Rename = (string)ToModelValue(reader, "Rename");
            return retriecal;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM Retriecal";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IList<Retriecal> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM Retriecal) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IList<Retriecal> GetAll()
        {
            string sql = "SELECT * FROM Retriecal";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IList<Retriecal> ToModels(SqlDataReader reader)
        {
            var list = new List<Retriecal>();
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
