//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable()]
    public class State
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        private string statename;

        public string Statename
        {
            get { return statename; }
            set { this.statename = value; }
        }

        private int aid;

        public int Aid
        {
            get { return aid; }
            set { this.aid = value; }
        }
    }
}
