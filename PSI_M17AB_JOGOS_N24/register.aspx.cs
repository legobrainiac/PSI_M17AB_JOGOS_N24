using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEmail.Text == string.Empty || !tbEmail.Text.Contains(".") || !tbEmail.Text.Contains("@"))
                    throw new Exception("Email with incorrect format");

                if (tbUsername.Text == string.Empty)
                    throw new Exception("Username can't be empty...");

                if (tbPassword.Text == string.Empty)
                    throw new Exception("Password can't be empty...");

                var res = Database.Instance.add_user(tbUsername.Text, tbPassword.Text, tbEmail.Text, 0);

                if (res == true)
                {
                    Response.Redirect("account.aspx");
                }
                else
                    throw new Exception("Something went wrong... try again later...");
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable tbl;
            bool login = Database.Instance.check_user_login(tbUsernameLogin.Text, tBpasswordLogin.Text, out tbl);

            if (login)
            {
                Session["username"] = tbl.Rows[0]["username"].ToString();
                Session["profile"] = tbl.Rows[0]["tipo"].ToString();
                Session["id"] = tbl.Rows[0]["id"].ToString();
                Response.Redirect("account.aspx");
            }
        }
    }
}