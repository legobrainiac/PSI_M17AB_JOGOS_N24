using System;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class add_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = productName.Text;
                if (name == string.Empty)
                    throw new Exception("Name cannot be empty ( ͡° ͜ʖ ͡°)");

                string description = productDescription.Text;
                if (description == string.Empty)
                    throw new Exception("Description cannot be empty ( ͡° ͜ʖ ͡°)");

                int price = int.Parse(productPrice.Text);
                if (price < 0)
                    throw new Exception("Price cannot be negative ( ͡° ͜ʖ ͡°)");

                int id = Database.Instance.add_product(name, description, price);

                if (fuImage.PostedFile.ContentLength > 0 &&
                    fuImage.PostedFile.ContentType == "image/jpeg")
                {
                    string file = Server.MapPath(@"~\pics\");
                    file += id + ".jpg";
                    fuImage.SaveAs(file);
                }

                Response.Redirect("product.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }


        }

    }
}