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
    public partial class InfoDao
    {
        public Info Add
            (Info info)
        {
            string sql = "INSERT INTO Info (Aid, Sid, Mid, Rid, Tops, Description, Comment, Attrid, Title)  output inserted.id VALUES (@Aid, @Sid, @Mid, @Rid, @Tops, @Description, @Comment, @Attrid, @Title)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@aid", ToDBValue(info.Aid)),
						new SqlParameter("@sid", ToDBValue(info.Sid)),
						new SqlParameter("@mid", ToDBValue(info.Mid)),
						new SqlParameter("@rid", ToDBValue(info.Rid)),
						new SqlParameter("@tops", ToDBValue(info.Tops)),
						new SqlParameter("@description", ToDBValue(info.Description)),
						new SqlParameter("@comment", ToDBValue(info.Comment)),
						new SqlParameter("@attrid", ToDBValue(info.Attrid)),
						new SqlParameter("@title", ToDBValue(info.Title)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE Info WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(Info info)
        {
            string sql =
                "UPDATE Info " +
                "SET " +
            " aid = @aid"
                + ", Sid = @sid"
                + ", Mid = @mid"
                + ", Rid = @rid"
                + ", Tops = @tops"
                + ", Description = @description"
                + ", Comment = @comment"
                + ", Attrid = @attrid"
                + ", Title = @title"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", info.Id)
					,new SqlParameter("@aid", ToDBValue(info.Aid))
					,new SqlParameter("@sid", ToDBValue(info.Sid))
					,new SqlParameter("@mid", ToDBValue(info.Mid))
					,new SqlParameter("@rid", ToDBValue(info.Rid))
					,new SqlParameter("@tops", ToDBValue(info.Tops))
					,new SqlParameter("@description", ToDBValue(info.Description))
					,new SqlParameter("@comment", ToDBValue(info.Comment))
					,new SqlParameter("@attrid", ToDBValue(info.Attrid))
					,new SqlParameter("@title", ToDBValue(info.Title))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public Info GetById(int id)
        {
            string sql = "SELECT * FROM Info WHERE Id = @Id";
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

        public Info ToModel(SqlDataReader reader)
        {
            Info info = new Info();

            info.Id = (int)ToModelValue(reader, "Id");
            info.Aid = (int)ToModelValue(reader, "Aid");
            info.Sid = (int)ToModelValue(reader, "Sid");
            info.Mid = (int)ToModelValue(reader, "Mid");
            info.Rid = (int)ToModelValue(reader, "Rid");
            info.Tops = (int)ToModelValue(reader, "Tops");
            info.Description = (string)ToModelValue(reader, "Description");
            info.Comment = (string)ToModelValue(reader, "Comment");
            info.Attrid = (int)ToModelValue(reader, "Attrid");
            info.Title = (string)ToModelValue(reader, "Title");
            return info;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM Info";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IList<Info> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM Info) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IList<Info> GetAll()
        {
            string sql = "SELECT * FROM Info";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IList<Info> ToModels(SqlDataReader reader)
        {
            var list = new List<Info>();
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
