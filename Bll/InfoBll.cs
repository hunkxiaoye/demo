using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class InfoBll
    {
        public Info Add(Info info)
        {
            return new InfoDao().Add(info);
        }

        public int DeleteById(int id)
        {
            return new InfoDao().DeleteById(id);
        }

        public int Update(Info info)
        {
            return new InfoDao().Update(info);
        }

        public IList<Info> SelectAll(Info info)
        {
            return new InfoDao().SelectAll(info);

        }


        public Info GetById(int id)
        {
            return new InfoDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new InfoDao().GetTotalCount();
        }

        public IList<Info> GetPagedData(int minrownum, int maxrownum)
        {
            return new InfoDao().GetPagedData(minrownum, maxrownum);
        }

        public IList<Info> GetAll()
        {
            return new InfoDao().GetAll();
        }
    }
}
