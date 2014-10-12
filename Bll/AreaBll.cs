using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class AreaBll
    {
        public Area Add(Area area)
        {
            return new AreaDao().Add(area);
        }

        public int DeleteById(int id)
        {
            return new AreaDao().DeleteById(id);
        }

        public int Update(Area area)
        {
            return new AreaDao().Update(area);
        }


        public Area GetById(int id)
        {
            return new AreaDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new AreaDao().GetTotalCount();
        }

        public List<Area> GetPagedData(int minrownum, int maxrownum)
        {
            return new AreaDao().GetPagedData(minrownum, maxrownum);
        }

        public List<Area> GetAll()
        {
            return new AreaDao().GetAll();
        }
    }
}
