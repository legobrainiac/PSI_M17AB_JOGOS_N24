using System;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                    username.Text = "Unknown";
                else
                    username.Text = Session["username"].ToString();
            }
        }
    }
}