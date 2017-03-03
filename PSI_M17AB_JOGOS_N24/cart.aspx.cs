using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cart;
            List<int> games;

            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["cart"] as HttpCookie;
                if (cookie != null)
                {
                    cart = cookie.Value;
                    games = JsonConvert.DeserializeObject<List<int>>(cart);

                    foreach (int id in games)
                    {
                        DataTable game = Database.Instance.get_product_with_id(id);
                        divCart.InnerHtml += BuildCartEntry(game.Rows[0][1].ToString(), game.Rows[0][2].ToString());
                    }

                    if(games.Count == 0)
                    {
                        divCart.InnerHtml += "<h1> You have an empty car, go buy some games!!! </h1>";
                    }
                }
            }
        }

        protected string BuildCartEntry(string name, string description)
        {
            return $@"
            <div class='mdl-card'>
                <div class='mdl-card__title'>
                    {name} 
                </div>
                <div class='mdl-card__supporting-text'>
                    {description}
                </div>
            </div></br>";
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("register.aspx");

            int id_user = int.Parse(Session["id"].ToString());

            string cart;
            List<int> games;

            HttpCookie cookie = Request.Cookies["cart"] as HttpCookie;
            if (cookie != null)
            {
                cart = cookie.Value;
                games = JsonConvert.DeserializeObject<List<int>>(cart);

                Database.Instance.ProcessCart(games, id_user);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(cookie);
            }
        }
    }
}