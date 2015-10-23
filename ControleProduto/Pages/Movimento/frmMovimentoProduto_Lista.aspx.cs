﻿using System;
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
            if (!Page.IsPostBack)
            {
                CarregaDropDownListProduto();
                CarregaGridProdutoMovimento();
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
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
                Nullable<DateTime> DtEntrada = null;
                Nullable<DateTime> DtSaida = null;
                int ncdProduto = 0;
                string cdsTipoMovimento = string.Empty;
                
                if (ddlProduto.SelectedIndex > 0) ncdProduto = int.Parse(ddlProduto.SelectedValue);
                if (ddlTipoMovimento.SelectedIndex > 0) cdsTipoMovimento = ddlTipoMovimento.SelectedValue;

                dt = oMetodo.CarregaProdutoMovimento(ncdProdutoMovimento, DtEntrada, DtSaida, ncdProduto, cdsTipoMovimento, oConn.getConnection());
                

                if (dt != null)
                {
                    gdvDados.DataSource = dt;
                    gdvDados.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
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
                Response.Redirect("frmMovimentoProduto.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}