using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class RetriecalBll
    {
        public Retriecal Add(Retriecal retriecal)
        {
            return new RetriecalDao().Add(retriecal);
        }

        public int DeleteById(int id)
        {
            return new RetriecalDao().DeleteById(id);
        }

        public int Update(Retriecal retriecal)
        {
            return new RetriecalDao().Update(retriecal);
        }


        public Retriecal GetById(int id)
        {
            return new RetriecalDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new RetriecalDao().GetTotalCount();
        }

        public IList<Retriecal> GetPagedData(int minrownum, int maxrownum)
        {
            return new RetriecalDao().GetPagedData(minrownum, maxrownum);
        }

        public IList<Retriecal> GetAll()
        {
            return new RetriecalDao().GetAll();
        }
    }
}
