using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.SG
{
    public partial class frm_SG_Usuario_IncluiAtualiza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CodigoUsuario"] != null)
                {
                    CarregaPerfil_Atualizacao();
                    hdfCodigoUsuario.Value = Request.QueryString["CodigoUsuario"].ToString();
                    CarregaUsuario();
                }
                else
                {
                    CarregaPerfil_Inclusao();
                }
            }
        }

        private void CarregaUsuario()
        {
            try
            {
                //Declarações de variáveis
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                DataTable dt = new DataTable();
                int ncdUsuario = 0;
                string cdsUsuario = string.Empty;
                string cnmUsuario = string.Empty;
                Nullable<Boolean> bidAtivo = null;

                //Passagem dos valores para variáveis
                if (!string.IsNullOrEmpty(hdfCodigoUsuario.Value)) ncdUsuario = int.Parse(hdfCodigoUsuario.Value);

                dt = oMetodo.CarregaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    txtCodigo.Text = dt.Rows[0]["NCDUSUARIO"] != DBNull.Value ? dt.Rows[0]["NCDUSUARIO"].ToString() : "";
                    txtDescricao.Text = dt.Rows[0]["CDSUSUARIO"] != DBNull.Value ? dt.Rows[0]["CDSUSUARIO"].ToString() : "";
                    txtNomeUsuario.Text = dt.Rows[0]["CNMUSUARIO"] != DBNull.Value ? dt.Rows[0]["CNMUSUARIO"].ToString() : "";
                    chkAtivo.Checked = dt.Rows[0]["BIDATIVO"] != DBNull.Value ? Boolean.Parse(dt.Rows[0]["BIDATIVO"].ToString()) : false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Usuário!');", true);
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
                dvAlterar_Senha.Attributes.Add("style", "display:none;");
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
                dvAlterar_Senha.Attributes.Add("style", "display:inline;");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Perfil de Atualização!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void chkSenhaPadrao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSenhaPadrao.Checked)
            {
                txtSenha_1.Enabled = false;
                txtSenha_2.Enabled = false;
            }
            else
            {
                txtSenha_1.Enabled = true;
                txtSenha_2.Enabled = true;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("frm_SG_Usuario_Carrega.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar a Tela de Retorno!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpa dados de Usuário
                txtCodigo.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                txtNomeUsuario.Text = string.Empty;
                chkAtivo.Checked = true;
                hdfCodigoUsuario.Value = string.Empty;

                //Limpa dados de Resetar Senha
                chkSenhaPadrao.Checked = false;
                txtSenha_1.Text = string.Empty;
                txtSenha_2.Text = string.Empty;

                //Perfil de Inclusão
                CarregaPerfil_Inclusao();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar a Tela de Retorno!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnAlterar_Senha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkSenhaPadrao.Checked)
                {
                    if (string.IsNullOrEmpty(txtSenha_1.Text.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Preencha o campo digite a senha!');", true);
                        return;
                    }

                    if (string.IsNullOrEmpty(txtSenha_2.Text.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Preencha o campo redigite a senha!');", true);
                        return;
                    }

                    if (txtSenha_1.Text.Trim() != txtSenha_2.Text.Trim())
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('As senhas digitadas não confere!');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Alterar a Senha de Usuário!');", true);
                String Error = ex.Message.ToString();
            }

        }
    }
}