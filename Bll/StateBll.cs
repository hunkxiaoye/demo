using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;

namespace Bll
{

    public partial class StateBll
    {
        public State Add(State state)
        {
            return new StateDao().Add(state);
        }

        public int DeleteById(int id)
        {
            return new StateDao().DeleteById(id);
        }

        public int Update(State state)
        {
            return new StateDao().Update(state);
        }


        public State GetById(int id)
        {
            return new StateDao().GetById(id);
        }
        public int GetTotalCount()
        {
            return new StateDao().GetTotalCount();
        }

        public IList<State> GetPagedData(int minrownum, int maxrownum)
        {
            return new StateDao().GetPagedData(minrownum, maxrownum);
        }

        public IList<State> GetAll()
        {
            return new StateDao().GetAll();
        }
    }
}
 