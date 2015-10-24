using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.Cadastro
{
    public partial class frmCadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CodigoProduto"] != null)
                {
                    CarregaPerfil_Atualizacao();
                    hdfCodigoProduto.Value = Request.QueryString["CodigoProduto"].ToString();
                    CarregaProduto();
                }
                else
                {
                    CarregaPerfil_Inclusao();
                }
            }
        }

        private void CarregaProduto()
        {
            try 
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                Nullable<Boolean> BidAtivo = null;                

                if (!string.IsNullOrEmpty(hdfCodigoProduto.Value)) ncdProduto = int.Parse(hdfCodigoProduto.Value);

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    txtCodigo.Text = dt.Rows[0]["NCDPRODUTO"] != DBNull.Value ? dt.Rows[0]["NCDPRODUTO"].ToString() : "";
                    txtDescricao.Text = dt.Rows[0]["CDSPRODUTO"] != DBNull.Value ? dt.Rows[0]["CDSPRODUTO"].ToString() : "";
                    chkAtivo.Checked = dt.Rows[0]["BIDATIVO"] != DBNull.Value ? Boolean.Parse(dt.Rows[0]["BIDATIVO"].ToString()) : false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Produto!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void IncluiProduto()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                bool BidAtivo = true;
                int Acao = 0;

                if (!string.IsNullOrEmpty(txtDescricao.Text.Trim())) cdsProduto = txtDescricao.Text.Trim();
                BidAtivo = chkAtivo.Checked;
                Acao = 1;

                dt = oMetodo.IncluiAtualizaProduto(ncdProduto, cdsProduto, BidAtivo, Acao, oConn.getConnection());

                if (dt != null)
                {
                    txtCodigo.Text = dt.Rows[0]["NCDPRODUTO"].ToString();
                    hdfCodigoProduto.Value = dt.Rows[0]["NCDPRODUTO"].ToString();                    
                    CarregaPerfil_Atualizacao();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + dt.Rows[0]["MENSAGEM"].ToString() + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Incluir Produto!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void AtualizaProduto()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                bool BidAtivo = true;
                int Acao = 0;

                if (!string.IsNullOrEmpty(hdfCodigoProduto.Value)) ncdProduto = int.Parse(hdfCodigoProduto.Value);
                if (!string.IsNullOrEmpty(txtDescricao.Text.Trim())) cdsProduto = txtDescricao.Text.Trim();
                BidAtivo = chkAtivo.Checked;
                Acao = 2;

                dt = oMetodo.IncluiAtualizaProduto(ncdProduto, cdsProduto, BidAtivo, Acao, oConn.getConnection());

                if (dt != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + dt.Rows[0]["MENSAGEM"].ToString() + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Atualizar Produto!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void CarregaPerfil_Inclusao()
        {
            try
            {
                btnIncluir.Enabled = true;
                btnAlterar.Enabled = false;
                btnNovo.Enabled = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Perfil de Inclusão!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void CarregaPerfil_Atualizacao()
        {
            try
            {
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnNovo.Enabled = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("frm_Cadastro_Produto_Lista.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Perfil de Atualização!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                return;
            }

            IncluiProduto();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                return;
            }

            AtualizaProduto();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                hdfCodigoProduto.Value = string.Empty;
                txtCodigo.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                chkAtivo.Checked = true;
                CarregaPerfil_Inclusao();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Perfil de Inclusão!');", true);
                String Error = ex.Message.ToString();
            }

        }

    }
}