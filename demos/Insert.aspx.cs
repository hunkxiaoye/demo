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
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowArea()
        {

            IList<Area> area = new AreaBll().GetAll();
            foreach (var are in area)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", are.Id, are.Areaname));
            }
        }
        public void ShowAttr()
        {

            IList<Attr> attr = new AttrBll().GetAll();
            foreach (var st in attr)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Attrname));
            }
        }
        public void ShowRetriecal()
        {

            IList<Retriecal> retriecal = new RetriecalBll().GetAll();
            foreach (var st in retriecal)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Rename));
            }
        }
        public void ShowTops()
        {

            for (int i = 1; i < 10; i++)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>",i,i));
            }
        }
        public void ShowState()
        {

            IList<State> state = new StateBll().GetAll();
            foreach (var st in state)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Statename));
            }
        }
        public void ShowMark()
        {

            IList<Mark> state = new MarkBll().GetAll();
            foreach (var st in state)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Markname));
            }
        }
        public void Unnamed1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Aid = int.Parse(Request.Form["area"]);
            info.Sid = int.Parse(Request.Form["state"]);
            info.Rid = int.Parse(Request.Form["retriecal"]);
            info.Mid = int.Parse(Request.Form["mark"]); 
            info.Attrid = int.Parse(Request.Form["attr"]);
            info.Tops = int.Parse(Request.Form["top"]);
            info.Title = Request.Form["title"];
            info.Description = Request.Form["description"];
            info.Comment = Request.Form["comment"];
            InfoBll ib =new InfoBll();
            ib.Add(info);
            Response.Redirect("Select.aspx");
        }
    }
}