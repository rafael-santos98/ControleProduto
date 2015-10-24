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
                Nullable<Boolean> BidAtivo = null;

                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim())) ncdProduto = int.Parse(txtCodigo.Text.Trim());
                if (!string.IsNullOrEmpty(txtDescricao.Text.Trim())) cdsProduto = txtDescricao.Text.Trim();
                if (ddlAtivo.SelectedIndex > 0) BidAtivo = ddlAtivo.SelectedValue == "1" ? true : false;

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    gdvDados.DataSource = dt;
                    gdvDados.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Produtos!');", true);
                String Error = ex.Message.ToString();
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
                Response.Redirect("frm_Cadastro_Produto_IncluiAtualiza.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Tela de Inclusão de Produto!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../../Default.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar a Tela Inicial!');", true);
                String Error = ex.Message.ToString();
            }
        }
    }
}