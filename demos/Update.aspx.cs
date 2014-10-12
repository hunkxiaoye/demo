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
    public partial class Update : System.Web.UI.Page
    {
        Info info = new Info();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            info = new InfoBll().GetById(id);
        }

        public void ShowArea()
        {
            IList<Area> area = new AreaBll().GetAll();
            Area areas = new AreaBll().GetById(info.Aid);
            Response.Write(string.Format("<option value=\"\">{0}</option>", areas.Areaname));
            foreach (var are in area)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", are.Id, are.Areaname));
            }
        }
        public void ShowAttr()
        {
            IList<Attr> attrs = new AttrBll().GetAll();
            Attr attr = new AttrBll().GetById(info.Attrid);
            Response.Write(string.Format("<option value=\"\">{0}</option>", attr.Attrname));
            foreach (var st in attrs)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Attrname));
            }
        }
        public void ShowRetriecal()
        {

            IList<Retriecal> retriecal = new RetriecalBll().GetAll();
            Retriecal retriecals= new RetriecalBll().GetById(info.Rid);
            Response.Write(string.Format("<option value=\"\">{0}</option>", retriecals.Rename));
            foreach (var st in retriecal)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Rename));
            }
        }
        public void ShowState()
        {

            IList<State> state = new StateBll().GetAll();
            State states = new StateBll().GetById(info.Sid);
            Response.Write(string.Format("<option value=\"\">{0}</option>", states.Statename));
            foreach (var st in state)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Statename));
            }
        }
        public void ShowTops()
        {

            Response.Write(string.Format("<option value=\"\">{0}</option>", info.Tops));
            for (int i = 1; i < 10; i++)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", i, i));
            }

        }
        public void ShowMark()
        {

            IList<Mark> state = new MarkBll().GetAll();
            Mark marks = new MarkBll().GetById(info.Mid);
            Response.Write(string.Format("<option value=\"\">{0}</option>", marks.Markname));
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
            InfoBll ib = new InfoBll();
            ib.Update(info);
            Response.Redirect("Select.aspx");
        }
    }
}