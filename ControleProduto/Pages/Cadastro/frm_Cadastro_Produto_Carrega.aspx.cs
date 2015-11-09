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
            CarregaAcesso();

            if (!Page.IsPostBack)
            {
                CarregaGridProduto();
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

                if (!CarregaAcessoPagina(Session["sUsuario"].ToString(), 1, 0)) //Usuário sem permissão
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