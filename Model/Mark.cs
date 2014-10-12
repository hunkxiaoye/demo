//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable()]
    public class Mark
    {
        public int Id
        {
            get;
            set;
        }
        public string Markname
        {
            get;
            set;
        }
        public string Markurl
        {
            get;
            set;
        }
    }
}
