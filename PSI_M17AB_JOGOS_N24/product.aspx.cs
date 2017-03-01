using System;
using System.Data;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            }
            catch
            {
                lblTituloImg.Text = "rip";
            }
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

                //Response.Redirect("product.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}