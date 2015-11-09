using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.SG
{
    public partial class frm_SG_UsuarioPermissao_IncluiExclui : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaAcesso();

            if (!Page.IsPostBack)
            {
                CarregaDropDownUsuario();
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

                //Administrador tem acesso
                if (Session["sUsuario"].ToString() == "admin")
                {
                    return;
                }

                if (!CarregaAcessoPagina(Session["sUsuario"].ToString(), 4, 0)) //Usuário sem permissão
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

        private void CarregaDropDownUsuario()
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

                dt = oMetodo.CarregaUsuario(ncdUsuario, cdsUsuario, cnmUsuario, bidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    ddlUsuario.DataSource = dt;
                    ddlUsuario.DataValueField = "NCDUSUARIO";
                    ddlUsuario.DataTextField = "CNMUSUARIO";
                    ddlUsuario.DataBind();

                    ddlUsuario.Items.Insert(0, new ListItem("(Selecione)", ""));
                    ddlUsuario.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Usuário!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void CarregaUsuarioPermissoesNaoAssociadas()
        {
            try
            {
                //Declarações de variáveis
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                DataTable dt = new DataTable();
                string cnmUsuario = string.Empty;
                int Acao = 0;

                //Passagem dos valores para variáveis
                if (ddlUsuario.SelectedIndex > 0) cnmUsuario = ddlUsuario.SelectedItem.Text;
                Acao = 1;

                dt = oMetodo.CarregaUsuarioPermissaoAcesso(cnmUsuario, Acao, oConn.getConnection());

                if (dt != null)
                {
                    lstPermissoesNaoAssociadas.DataSource = dt;
                    lstPermissoesNaoAssociadas.DataTextField = "CDSCFUNSUB";
                    lstPermissoesNaoAssociadas.DataValueField = "NCDFUNSUB";
                    lstPermissoesNaoAssociadas.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert(Erro ao Carregar Lista de Permissões Não Associadas!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void CarregaUsuarioPermissoesAssociadas()
        {
            try
            {
                //Declarações de variáveis
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                DataTable dt = new DataTable();
                string cnmUsuario = string.Empty;
                int Acao = 0;

                //Passagem dos valores para variáveis
                if (ddlUsuario.SelectedIndex > 0) cnmUsuario = ddlUsuario.SelectedItem.Text;
                Acao = 2;

                dt = oMetodo.CarregaUsuarioPermissaoAcesso(cnmUsuario, Acao, oConn.getConnection());

                if (dt != null)
                {
                    lstPermissoesAssociadas.DataSource = dt;
                    lstPermissoesAssociadas.DataTextField = "CDSCFUNSUB";
                    lstPermissoesAssociadas.DataValueField = "NCDPERMISSAOACESSO";
                    lstPermissoesAssociadas.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Lista de Permissões Associadas!');", true);
                String Error = ex.Message.ToString();
            }
        }

        private void IncluiUsuarioPermissao()
        {
            try
            {
                //Percorrendo o listbox e obtendo o código da funcionalidade e subfuncionalidade
                foreach (ListItem item in lstPermissoesNaoAssociadas.Items)
                {
                    //Adicionando permissão do item selecionado
                    if (item.Selected == true)
                    {
                        //Declarações de variáveis
                        Misc.oConexao oConn = new Misc.oConexao();
                        SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                        DataTable dt = new DataTable();
                        int ncdPermissaoAcesso = 0;
                        string cnmUsuario = string.Empty;
                        int ncdFuncionalidade = 0;
                        int ncdSubFuncionalidade = 0;
                        int Acao = 0;

                        //Define valor para variáveis
                        string[] ncdFunSub = item.Value.ToString().Split('|');
                        cnmUsuario = ddlUsuario.SelectedItem.Text.ToString();
                        ncdFuncionalidade = int.Parse(ncdFunSub[0].ToString());
                        ncdSubFuncionalidade = int.Parse(ncdFunSub[1].ToString());
                        Acao = 1;

                        dt = oMetodo.IncluiExcluiPermisssaoAcessoUsuario(ncdPermissaoAcesso, cnmUsuario, ncdFuncionalidade, ncdSubFuncionalidade, Acao, oConn.getConnection());
                    }
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert(Erro ao Incluir Permissão de Acesso!');", true);
                String Error = ex.Message.ToString();
            }

        }

        private void ExcluiUsuarioPermissao()
        {
            try
            {
                //Percorrendo o listbox e obtendo o código da funcionalidade e subfuncionalidade
                foreach (ListItem item in lstPermissoesAssociadas.Items)
                {
                    //Removendo permissão do item selecionado
                    if (item.Selected == true)
                    {
                        //Declarações de variáveis
                        Misc.oConexao oConn = new Misc.oConexao();
                        SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                        DataTable dt = new DataTable();
                        int ncdPermissaoAcesso = 0;
                        string cnmUsuario = string.Empty;
                        int ncdFuncionalidade = 0;
                        int ncdSubFuncionalidade = 0;
                        int Acao = 0;

                        //Define valor para variáveis
                        ncdPermissaoAcesso = int.Parse(item.Value.ToString());
                        Acao = 2;

                        dt = oMetodo.IncluiExcluiPermisssaoAcessoUsuario(ncdPermissaoAcesso, cnmUsuario, ncdFuncionalidade, ncdSubFuncionalidade, Acao, oConn.getConnection());
                    }
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert(Erro ao Incluir Permissão de Acesso!');", true);
                String Error = ex.Message.ToString();
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex > 0)
            {
                CarregaUsuarioPermissoesNaoAssociadas();
                CarregaUsuarioPermissoesAssociadas();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex > 0)
            {
                IncluiUsuarioPermissao();
                CarregaUsuarioPermissoesAssociadas();
                CarregaUsuarioPermissoesNaoAssociadas();
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex > 0) 
            {
                ExcluiUsuarioPermissao();
                CarregaUsuarioPermissoesAssociadas();
                CarregaUsuarioPermissoesNaoAssociadas();
            }
        }
    }
}