using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;

namespace demos
{
    public partial class ld : System.Web.UI.Page
    {
        protected string arealist_json;
        protected string statelist_json;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<Area> arealist = new AreaBll().GetAll();
                arealist_json = JsonHelper.ToJson<IList<Area>>(arealist);
                IList<State> statelist = new StateBll().GetAll();
                statelist_json = JsonHelper.ToJson<IList<State>>(statelist);
            }
        }
    }
}