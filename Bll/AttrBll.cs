using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class AttrBll
    {
        public Attr Add(Attr attr)
        {
            return new AttrDao().Add(attr);
        }

        public int DeleteById(int id)
        {
            return new AttrDao().DeleteById(id);
        }

        public int Update(Attr attr)
        {
            return new AttrDao().Update(attr);
        }


        public Attr GetById(int id)
        {
            return new AttrDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new AttrDao().GetTotalCount();
        }

        public IList<Attr> GetPagedData(int minrownum, int maxrownum)
        {
            return new AttrDao().GetPagedData(minrownum, maxrownum);
        }

        public IList<Attr> GetAll()
        {
            return new AttrDao().GetAll();
        }
    }
}
