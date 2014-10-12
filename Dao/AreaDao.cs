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
	public partial class AreaDao
	{
        public Area Add
			(Area area)
		{
				string sql ="INSERT INTO Area (Areaname)  output inserted.id VALUES (@Areaname)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@areaname", ToDBValue(area.Areaname)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE Area WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(Area area)
        {
            string sql =
                "UPDATE Area " +
                "SET " +
			" areaname = @areaname" 
               
            +" WHERE id = @id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@id", area.Id)
					,new SqlParameter("@areaname", ToDBValue(area.Areaname))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public Area GetById(int id)
        {
            string sql = "SELECT * FROM Area WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
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
		
		public Area ToModel(SqlDataReader reader)
		{
			Area area = new Area();

			area.Id = (int)ToModelValue(reader,"Id");
			area.Areaname = (string)ToModelValue(reader,"Areaname");
			return area;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM Area";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IList<Area> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by id) rownum FROM Area) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IList<Area> GetAll()
		{
			string sql = "SELECT * FROM Area";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IList<Area> ToModels(SqlDataReader reader)
		{
			var list = new List<Area>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
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
