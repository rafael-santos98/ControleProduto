using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.Movimento
{
    public partial class frmMovimentoProduto_Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaAcesso();

            if (!Page.IsPostBack)
            {
                CarregaDropDownListProduto();
                CarregaGridProdutoMovimento();
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

                if (!CarregaAcessoPagina(Session["sUsuario"].ToString(), 2, 0)) //Usuário sem permissão
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

        private void CarregaDropDownListProduto()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                Nullable<Boolean> BidAtivo = null;

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    ddlProduto.DataSource = dt;
                    ddlProduto.DataValueField = "NCDPRODUTO";
                    ddlProduto.DataTextField = "CDSPRODUTO";
                    ddlProduto.DataBind();

                    ddlProduto.Items.Insert(0, new ListItem("(Selecione)", ""));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Produtos!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void CarregaGridProdutoMovimento()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProdutoMovimento oMetodo = new SF_AP.oProdutoMovimento();
                DataTable dt = new DataTable();
                int ncdProdutoMovimento = 0;
                Nullable<DateTime> dtMovimentoDe = null;
                Nullable<DateTime> dtMovimentoAte = null;
                int ncdProduto = 0;
                string cdsTipoMovimento = string.Empty;

                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim())) ncdProdutoMovimento = int.Parse(txtCodigo.Text.Trim());
                if (!string.IsNullOrEmpty(txtDataDe.Text.Trim())) dtMovimentoDe = DateTime.Parse(txtDataDe.Text.Trim());
                if (!string.IsNullOrEmpty(txtDataAte.Text.Trim())) dtMovimentoAte = DateTime.Parse(txtDataAte.Text.Trim());
                if (ddlProduto.SelectedIndex > 0) ncdProduto = int.Parse(ddlProduto.SelectedValue);
                if (ddlTipoMovimento.SelectedIndex > 0) cdsTipoMovimento = ddlTipoMovimento.SelectedValue;

                dt = oMetodo.CarregaProdutoMovimento(ncdProdutoMovimento, dtMovimentoDe, dtMovimentoAte, ncdProduto, cdsTipoMovimento, oConn.getConnection());


                if (dt != null)
                {
                    gdvDados.DataSource = dt;
                    gdvDados.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Movimento de Produtos!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregaGridProdutoMovimento();
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("frm_Movimento_Produto_Inclui.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Tela de Movimento de Produto!');", true);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Tela Inicial!');", true);
                String Error = ex.Message.ToString();

            }
        }
    }
}