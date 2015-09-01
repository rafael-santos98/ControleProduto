using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.Cadastro
{
    public partial class frmCadastroProduto_Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGridProduto();
            }     
        }

        private void CarregaGridProduto()
        {          
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                int BidAtivo = 0;

                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim())) ncdProduto = int.Parse(txtCodigo.Text.Trim());
                if (!string.IsNullOrEmpty(txtDescricao.Text.Trim())) cdsProduto = txtDescricao.Text.Trim();
                if (ddlAtivo.SelectedIndex > 0) BidAtivo = int.Parse(ddlAtivo.SelectedValue);

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo,oConn.getConnection());

                if (dt != null)
                {
                    gdvDados.DataSource = dt;
                    gdvDados.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {            
            CarregaGridProduto();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try 
            {
                Response.Redirect("frmCadastroProduto.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}