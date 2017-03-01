using System;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class manage_users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null || Session["profile"].ToString() == "0")
                Response.Redirect("index.aspx");

            if(!IsPostBack)
            {
                gvUsers.Columns.Clear();
                gvUsers.DataSource = Database.Instance.get_users();
                gvUsers.DataBind();
            }
        }
    }
}