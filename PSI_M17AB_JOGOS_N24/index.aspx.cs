using System;
using System.Data;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable data = Database.Instance.get_products();

                foreach (DataRow row in data.Rows)
                {
                    divCardsGames.InnerHtml += BuildGameCard(row[1].ToString(), int.Parse(row[0].ToString()));
                }
            }
        }

        private string BuildGameCard(string name, int id)
        {
            string card =
                "<div class='demo-updates mdl-card mdl-shadow--2dp mdl-cell--4-col mdl-cell--4-col-phone mdl-color--blue-grey-800'>" +
                    "<div class='mdl-card__title'>" +
                        "<a href='product.aspx?id=" + id + "'>" +
                            "<h2 class='mdl-card__title-text'>" + name + "</h2>" +
                        "</a>" +
                    "</div>" +
                    "<div class='mdl-card__media'>" +
                        "<img src='/pics/" + id + ".jpg' Width='400' Height='225'>" +
                    "</div>" +
                "</div>";

            return card;
        }
    }
}