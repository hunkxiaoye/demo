
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Serializable]
    public class Area
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        private string areaname;

        public string Areaname
        {
            get { return areaname; }
            set { this.areaname = value; }
        }
    }
}
