using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie cookieUsuario = Request.Cookies["textoCookieUsuario"];
                HttpCookie cookieSenha = Request.Cookies["textoCookieSenha"];

                if (cookieUsuario != null && cookieSenha != null)
                {
                    if (!string.IsNullOrEmpty(cookieUsuario.Value) && !string.IsNullOrEmpty(cookieSenha.Value))
                    {
                        chkLembrar.Checked = true;
                        if (Logar(cookieUsuario.Value, cookieSenha.Value))
                        {
                            MenuLogado.Attributes.Add("class", "nav navbar-nav navbar-right");
                            MenuDeslogado.Attributes.Add("class", "nav navbar-nav navbar-right hidden");
                        }
                    }
                }
            }
        }

        private Boolean Logar(string cnmUsuario, string cdsSenha)
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oUsuario oMetodo = new SF_AP.oUsuario();
                DataTable dt = new DataTable();

                dt = oMetodo.CarregaUsuarioAcesso(cnmUsuario, cdsSenha, oConn.getConnection());

                if (dt != null)
                {   
                    if (Convert.ToBoolean(dt.Rows[0]["RETORNO"]))
                    {
                        if (chkLembrar.Checked == true)
                        {

                            HttpCookie cookieUsuario = new HttpCookie("textoCookieUsuario");
                            HttpCookie cookieSenha = new HttpCookie("textoCookieSenha");
                            TimeSpan somarTempo = new TimeSpan(0, 10, 0, 0); //Tempo de Expiração

                            cookieUsuario.Value = cnmUsuario;
                            cookieUsuario.Expires = DateTime.Now + somarTempo;
                            Response.Cookies.Add(cookieUsuario);

                            cookieSenha.Value = cdsSenha;
                            cookieSenha.Expires = DateTime.Now + somarTempo;
                            Response.Cookies.Add(cookieSenha);
                        }
                        Session["sUsuario"] = cnmUsuario;

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean Deslogar()
        {
            try
            {
                HttpCookie cookieUsuario = new HttpCookie("textoCookieUsuario");
                cookieUsuario.Expires = DateTime.Now.AddDays(-1);
                cookieUsuario.Value = string.Empty;
                Response.Cookies.Add(cookieUsuario);

                HttpCookie cookieSenha = new HttpCookie("textoCookieSenha");
                cookieSenha.Expires = DateTime.Now.AddDays(-1);
                cookieSenha.Value = string.Empty;
                Response.Cookies.Add(cookieSenha);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkbtnPaginaInicial_Click(object sender, EventArgs e)
        {
            try
            {
                IfrmRedirect.Attributes.Add("src", "frmInicial.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkbtnCadastroProduto_Click(object sender, EventArgs e)
        {
            try
            {
                IfrmRedirect.Attributes.Add("src", "Pages/Cadastro/frm_Cadastro_Produto_Carrega.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkbtnMovimentoProduto_Click(object sender, EventArgs e)
        {
            try
            {
                IfrmRedirect.Attributes.Add("src", "Pages/Movimento/frm_Movimento_Produto_Carrega.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Misc.oCriptografia oCriptografia = new Misc.oCriptografia();
                string cnmUsuario = txtUsuario.Text.Trim();
                string cdsSenha = oCriptografia.SHA512(txtUsuarioSenha.Text.Trim()).ToUpper();

                if (Logar(cnmUsuario, cdsSenha))
                {
                    MenuLogado.Attributes.Add("class", "nav navbar-nav navbar-right");
                    MenuDeslogado.Attributes.Add("class", "nav navbar-nav navbar-right hidden");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (Deslogar())
                {
                    Session["sUsuario"] = null;
                    MenuDeslogado.Attributes.Add("class", "nav navbar-nav navbar-right");
                    MenuLogado.Attributes.Add("class", "nav navbar-nav navbar-right hidden");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}