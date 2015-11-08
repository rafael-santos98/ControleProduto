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
            if (!Page.IsPostBack)
            {
                CarregaDropDownUsuario();
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

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex > 0)
            {
                CarregaUsuarioPermissoesNaoAssociadas();
                CarregaUsuarioPermissoesAssociadas();    
            }            
        }
    }
}