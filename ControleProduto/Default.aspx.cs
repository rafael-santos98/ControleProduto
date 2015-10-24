using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProduto_Cadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Cadastro/frm_Cadastro_Produto_Carrega.aspx");
        }

        protected void btnProduto_Movimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Movimento/frm_Movimento_Produto_Carrega.aspx");
        }
    }
}