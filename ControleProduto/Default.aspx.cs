using System;
using System.Collections.Generic;
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

        }

        protected void IncluiCookie(string CdsUsuario, string CdsSenha)
        {
            Misc.oCriptografia oCriptografia = new Misc.oCriptografia();
            HttpCookie cookieUsuario = new HttpCookie("textoCookieUsuario");
            HttpCookie cookieSenha = new HttpCookie("textoCookieSenha");
            TimeSpan somarTempo = new TimeSpan(0, 10, 0, 0); //Tempo de Expiração

            cookieUsuario.Value = CdsUsuario;
            cookieUsuario.Expires = DateTime.Now + somarTempo;
            Response.Cookies.Add(cookieUsuario);

            cookieSenha.Value = CdsSenha;
            cookieSenha.Expires = DateTime.Now + somarTempo;
            Response.Cookies.Add(cookieSenha);
        }

        protected void RemoveCookie()
        {
            HttpCookie cookieUsuario = new HttpCookie("textoCookieUsuario");
            cookieUsuario.Expires = DateTime.Now.AddDays(-1);
            cookieUsuario.Value = string.Empty;
            Response.Cookies.Add(cookieUsuario);

            HttpCookie cookieSenha = new HttpCookie("textoCookieSenha");
            cookieSenha.Expires = DateTime.Now.AddDays(-1);
            cookieSenha.Value = string.Empty;
            Response.Cookies.Add(cookieSenha);
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
                MenuLogado.Attributes.Add("class", "nav navbar-nav navbar-right");
                MenuDeslogado.Attributes.Add("class", "nav navbar-nav navbar-right hidden");
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
                MenuDeslogado.Attributes.Add("class", "nav navbar-nav navbar-right");
                MenuLogado.Attributes.Add("class", "nav navbar-nav navbar-right hidden");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}