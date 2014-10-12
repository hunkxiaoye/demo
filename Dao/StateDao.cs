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
    public partial class StateDao
    {
        public State Add
            (State state)
        {
            string sql = "INSERT INTO State (Statename)  output inserted.id VALUES (@Statename)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@statename", ToDBValue(state.Statename)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE State WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(State state)
        {
            string sql =
                "UPDATE State " +
                "SET " +
            " statename = @statename"

            + " WHERE id = @id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", state.Id)
					,new SqlParameter("@statename", ToDBValue(state.Statename))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public State GetById(int id)
        {
            string sql = "SELECT * FROM State WHERE Id = @Id";
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

        public State ToModel(SqlDataReader reader)
        {
            State state = new State();

            state.Id = (int)ToModelValue(reader, "Id");
            state.Statename = (string)ToModelValue(reader, "Statename");
            return state;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM State";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IList<State> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM State) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IList<State> GetAll()
        {
            string sql = "SELECT * FROM State";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IList<State> ToModels(SqlDataReader reader)
        {
            var list = new List<State>();
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
