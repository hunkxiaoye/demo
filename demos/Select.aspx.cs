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
    public partial class Select1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
                IList<Select> select = new List<Select>();
                var info = new InfoBll().GetAll();
                for (int i = 0; i < info.Count; i++)
                {
                    Select sel = new Select();
                    var area = new AreaBll().GetById(info[i].Aid);
                    var state = new StateBll().GetById(info[i].Sid);
                    var retriecal = new RetriecalBll().GetById(info[i].Rid);
                    var attr = new AttrBll().GetById(info[i].Attrid);
                    var mark = new MarkBll().GetById(info[i].Mid);
                    sel.Area = area.Areaname;
                    sel.State = state.Statename;
                    sel.MarkName = mark.Markname;
                    sel.MarkUrl = mark.Markurl;
                    sel.Retriecal = retriecal.Rename;
                    sel.Tops = info[i].Tops;
                    sel.Id = info[i].Id;
                    sel.AttrName = attr.Attrname;
                    select.Add(sel);
                    this.Repeater1.DataSource = select;
                    this.Repeater1.DataBind();



            } 
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
        public void ShowState()
        {

            IList<State> state = new StateBll().GetAll();
            foreach (var st in state)
            {
                Response.Write(string.Format("<option value=\"{0}\">{1}</option>", st.Id, st.Statename));
            }
        }

        public void Unnamed1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            IList<Select> select = new List<Select>();
            IList<Info> ins = new List<Info>();
            info.Aid = int.Parse(Request.Form["area"]);
            info.Sid = int.Parse(Request.Form["state"]);
            info.Rid = int.Parse(Request.Form["retriecal"]);
            info.Title = Request.Form["Title"];
            info.Attrid = int.Parse(Request.Form["attr"]);
            ins = new InfoBll().GetAll();
            for (int i = 0; i < ins.Count; i++)
            {
                Select selects = new Select();
                var area = new AreaBll().GetById(ins[i].Aid);
                var state = new StateBll().GetById(ins[i].Sid);
                var retriecal = new RetriecalBll().GetById(ins[i].Rid);
                var attr = new AttrBll().GetById(ins[i].Attrid);
                var mark = new MarkBll().GetById(ins[i].Mid);
                selects.Area = area.Areaname;
                selects.State = state.Statename;
                selects.MarkName =mark.Markname  ;
                selects.MarkUrl = mark.Markurl;
                selects.Retriecal = retriecal.Rename;
                selects.Tops = ins[i].Tops;
                selects.Id = ins[i].Id;
                selects.AttrName = attr.Attrname;
                select.Add(selects);
            }
            this.Repeater1.DataSource = select;
            this.Repeater1.DataBind();
        }

    }
}