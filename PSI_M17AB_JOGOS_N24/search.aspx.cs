using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //TODO(legobrainiac): update sql script to include primary in reviews table
            {
                DataTable data = Database.Instance.get_products();
                foreach (DataRow row in data.Rows)
                    divResult.InnerHtml += BuildGameCard(row[1].ToString(), int.Parse(row[0].ToString()));
            }
        }

        private string BuildGameCard(string name, int id)
        {
            string card =
                "<div class='demo-updates mdl-card mdl-shadow--2dp mdl-cell--3-col mdl-cell--4-col-phone mdl-color--blue-grey-800'>" +
                    "<div class='mdl-card__title'>" +
                        "<a href='product.aspx?id=" + id + "'>" +
                            "<h2 class='mdl-card__title-text'>" + name + "</h2>" +
                        "</a>" +
                    "</div>" +
                    "<div class='mdl-card__media'>" +
                        "<img src='/pics/" + id + ".jpg' Width='400' Height='225'>" +
                    "</div>" +
                "</div>&nbsp&nbsp&nbsp";

            return card;
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            divResult.InnerHtml = "";
            DataTable data = Database.Instance.get_products_like(tbSearch.Text);
            foreach (DataRow row in data.Rows)
                divResult.InnerHtml += BuildGameCard(row[1].ToString(), int.Parse(row[0].ToString()));
        }
    }
}