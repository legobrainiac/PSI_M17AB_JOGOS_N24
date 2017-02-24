using System;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
            }

            if (Session["id"] == null)
            {
                username.Text = "( ͡° ͜ʖ ͡°)";
                divAdmin.Visible = false;
            }
            else
            {
                username.Text = Session["username"].ToString();
                if (Session["profile"].ToString() == "0")
                    divAdmin.Visible = false;
            }
        }
    }
}