using System;
using System.Collections.Generic;
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
                    //CarregaProduto();
                }
                else
                {
                    CarregaPerfil_Inclusao();
                }
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
    }
}