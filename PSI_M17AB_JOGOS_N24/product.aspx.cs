using System;
using System.Data;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null && Session["profile"].ToString() == "1")
                {
                    divAdmin.Visible = true;
                }
                else
                    divAdmin.Visible = false;

                try
                {
                    int id = int.Parse(Request["id"]);

                    DataTable tbl = Database.Instance.get_product_with_id(id);
                    lblTituloImg.Text = tbl.Rows[0]["product_name"].ToString();
                    productName.Text = tbl.Rows[0]["product_name"].ToString();
                    lblTitulo.Text = tbl.Rows[0]["product_name"].ToString() + " " + tbl.Rows[0]["price"].ToString() + "€";


                    lblDescription.Text = tbl.Rows[0]["product_description"].ToString();
                    productDescription.Text = tbl.Rows[0]["product_description"].ToString();

                    productPrice.Text = tbl.Rows[0]["price"].ToString();
                    img.ImageUrl = @"~/pics/" + id + ".jpg";

                    var reviews = Database.Instance.reviews_product(id);
                    foreach (DataRow item in reviews.Rows)
                    {
                        divReviews.InnerHtml += BuildReviewCard(item["title"].ToString(), item["body"].ToString());
                    }
                }
                catch
                {
                    lblTituloImg.Text = "rip";
                }
            }
        }

        private string BuildReviewCard(string title, string body)
        {
            string card =
                "<div class='demo-updates mdl-card mdl-shadow--2dp mdl-cell--6-col mdl-cell--6-col-phone mdl-color--blue-grey-800'>" +
                    "<div class='mdl-card__title'>" +
                            "<h2 class='mdl-card__title-text'>" + title + "</h2>" +
                    "</div>" +
                    "<div class='mdl-card__supporting-text'>" +
                            "<h2 class='mdl-card__title-text'>" + body + "</h2>" +
                    "</div>" +
                "</div>&nbsp&nbsp&nbsp";

            return card;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"]);
            Database.Instance.delete_product(id);
            Response.Redirect("index.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                string name = productName.Text;
                if (name == string.Empty)
                    throw new Exception("Name cannot be empty ( ͡° ͜ʖ ͡°)");

                string description = productDescription.Text;
                if (description == string.Empty)
                    throw new Exception("Description cannot be empty ( ͡° ͜ʖ ͡°)");

                int price = int.Parse(productPrice.Text);
                if (price < 0)
                    throw new Exception("Price cannot be negative ( ͡° ͜ʖ ͡°)");

                lblError.Text = Database.Instance.edit_product(id, name, description, price).ToString();

                Response.Redirect("product.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"] == null)
                    Response.Redirect("register.aspx");

                int id_product = int.Parse(Request["id"]);
                int id_user = int.Parse(Session["id"].ToString());

                string title = tbTitle.Text;
                if (title == string.Empty)
                    throw new Exception("Title cannot be empty ( ͡° ͜ʖ ͡°)");

                string body = tbBody.Text;
                if (body == string.Empty)
                    throw new Exception("Body cannot be empty ( ͡° ͜ʖ ͡°)");


                lblError.Text = Database.Instance.review_product(id_user, id_product, title, body).ToString();
                //Response.Redirect("product.aspx?id=" + id_product);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}