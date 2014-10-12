using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class MarkBll
    {
        public Mark Add(Mark mark)
        {
            return new MarkDao().Add(mark);
        }

        public int DeleteById(int id)
        {
            return new MarkDao().DeleteById(id);
        }

        public int Update(Mark mark)
        {
            return new MarkDao().Update(mark);
        }


        public Mark GetById(int id)
        {
            return new MarkDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new MarkDao().GetTotalCount();
        }

        public IList<Mark> GetPagedData(int minrownum, int maxrownum)
        {
            return new MarkDao().GetPagedData(minrownum, maxrownum);
        }

        public IList<Mark> GetAll()
        {
            return new MarkDao().GetAll();
        }
    }
}
