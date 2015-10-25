using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.SG
{
    public partial class frmMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaMenu();            
        }

        private void CarregaMenu()
        {
            try
            {
                MenuPrincipal.Items.Clear();
                DataTable dt = new DataTable();
                dt.Columns.Add("MenuID", typeof(int));
                dt.Columns.Add("MenuName", typeof(string));
                dt.Columns.Add("MenuLocation", typeof(string));
                dt.Columns.Add("ParentID", typeof(int));

                dt.Rows.Add(1, "Home Page", "../../Default.aspx", 0);
                dt.Rows.Add(2, "Cadastro", null, 0);
                dt.Rows.Add(3, "Movimento", null, 0);
                dt.Rows.Add(4, "Produto", "../Cadastro/frm_Cadastro_Produto_Carrega.aspx", 2);
                dt.Rows.Add(5, "Produto", "../Movimento/frm_Movimento_Produto_Carrega.aspx", 3);
                

                DataRow[] drowpar = dt.Select("ParentID=" + 0);
                foreach (DataRow dr in drowpar)
                {
                    MenuPrincipal.Items.Add(new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(), "", dr["MenuLocation"].ToString()));
                }

                foreach (DataRow dr in dt.Select("ParentID >" + 0))
                {
                    MenuItem mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(), "", dr["MenuLocation"].ToString());
                    MenuPrincipal.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Erro ao Carregar Produto!');", true);
                String Error = ex.Message.ToString();
            }
        }
    }
}