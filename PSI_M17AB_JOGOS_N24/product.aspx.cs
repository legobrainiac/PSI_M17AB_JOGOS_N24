using System;
using System.Data;

namespace PSI_M17AB_JOGOS_N24
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                DataTable tbl = Database.Instance.get_product_with_id(id);
                lblTituloImg.Text = tbl.Rows[0]["product_name"].ToString();
                lblTitulo.Text = tbl.Rows[0]["product_name"].ToString();
                lblDescription.Text = tbl.Rows[0]["product_description"].ToString();
                img.ImageUrl = @"~/pics/" + id + ".jpg";
            }
            catch
            {
                lblTituloImg.Text = "rip";
            }
        }
    }
}