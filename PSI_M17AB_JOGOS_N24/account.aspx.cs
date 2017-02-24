using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("register.aspx");

            if (Session["profile"].ToString() == "1")
            {
                divUser.Visible = false;
                divAdmin.Visible = true;
            }
            else
            {
                divUser.Visible = true;
                divAdmin.Visible = false;
            }
        }
    }
}