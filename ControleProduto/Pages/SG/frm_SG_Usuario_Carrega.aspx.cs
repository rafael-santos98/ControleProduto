using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.SG
{
    public partial class frm_SG_Usuario_Carrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaAcesso();

            if (!Page.IsPostBack)
            {
                CarregaGridUsuario();
            }
        }

        private void CarregaAcesso()
        {
            try
            {
                //Usuário não logado
                if (Session["sUsuario"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Acesso negado'); window.location.href='../../frmInicial.aspx';", true);
                    return;
                }

                if (!CarregaAcessoPagina(Session["sUsuario"].ToString(), 3, 0)) //Usuário sem permissão
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Acesso negado'); window.location.href='../../frmInicial.aspx';", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Permissão de Acesso!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private Boolean CarregaAcessoPagina(string cnmUsuario, int ncdFuncionalidade, int ncdSubFuncionalidade)
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioAcessoPagina(cnmUsuario, ncdFuncionalidade, ncdSubFuncionalidade, oConn.getConnection());

                if (dt != null)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["RETORNO"])) return true;
                    else return false;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CarregaGridUsuario()
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
                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim())) ncdUsuario = int.Parse(txtCodigo.Text.Trim());
                if (!string.IsNullOrEmpty(txtDescricao.Text.Trim())) cdsUsuario = txtDescricao.Text.Trim();
                if (!string.IsNullOrEmpty(txtNomeUsuario.Text.Trim())) cdsUsuario = txtNomeUsuario.Text.Trim();
                if (ddlAtivo.SelectedIndex > 0) bidAtivo = ddlAtivo.SelectedValue == "1" ? true : false;

                dt = oMetodo.CarregaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    gdvUsuario.DataSource = dt;
                    gdvUsuario.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Usuário!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregaGridUsuario();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("frm_SG_Usuario_IncluiAtualiza.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Tela de Inclusão de Usuário!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../../frmInicial.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar a Tela Inicial!');", true);
                String Error = ex.Message.ToString();
            }
        }

        
    }
}