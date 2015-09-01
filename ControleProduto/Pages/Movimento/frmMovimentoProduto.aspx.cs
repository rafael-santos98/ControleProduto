using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleProduto.Pages.Movimento
{
    public partial class frmMovimentoProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaDropDownListProduto();
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
                int BidAtivo = 0;

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

        private void CarregaProduto_Saldo()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProduto oMetodo = new SF_AP.oProduto();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                string cdsProduto = string.Empty;
                int BidAtivo = 0;

                if (ddlProduto.SelectedIndex > 0) ncdProduto = int.Parse(ddlProduto.SelectedValue);

                dt = oMetodo.CarregaProduto(ncdProduto, cdsProduto, BidAtivo, oConn.getConnection());

                if (dt != null)
                {
                    txtValorSaldo.Text = dt.Rows[0]["NVLSALDO"] != DBNull.Value ? dt.Rows[0]["NVLSALDO"].ToString() : "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        private void IncluiProdutoMovimento()
        {
            try
            {
                Misc.oConexao oConn = new Misc.oConexao();
                SF_AP.oProdutoMovimento oMetodo = new SF_AP.oProdutoMovimento();
                DataTable dt = new DataTable();
                int ncdProduto = 0;
                float nvlQuantidade = 0;
                string cdsObservacao = string.Empty;
                string cdsTipoMovimento = string.Empty;

                if (ddlProduto.SelectedIndex > 0) ncdProduto = int.Parse(ddlProduto.SelectedValue);
                if (ddlTipoMovimento.SelectedIndex > 0) cdsTipoMovimento = ddlTipoMovimento.SelectedValue;
                if (!string.IsNullOrEmpty(txtValorQuantidade.Text.Trim())) nvlQuantidade = float.Parse(txtValorQuantidade.Text.Trim());

                dt = oMetodo.IncluiProdutoMovimento(ncdProduto, nvlQuantidade, cdsObservacao, cdsTipoMovimento, oConn.getConnection());


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["BIDAUTORIZACAO"].ToString() == "1")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + dt.Rows[0]["MENSAGEM"].ToString() + "');", true);
                            CarregaProduto_Saldo();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + dt.Rows[0]["MENSAGEM"].ToString() + "');", true);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlProduto.SelectedIndex > 0)
            {
                CarregaProduto_Saldo();
            }
            else
            {
                txtValorSaldo.Text = string.Empty;
            }
        }

        protected void btnVoltar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("frmMovimentoProduto_Lista.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void btnIncluir_Click(object sender, System.EventArgs e)
        {
            if (ddlProduto.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Preencha o campo Produto!');", true);
                return;
            }

            if (ddlTipoMovimento.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Preencha o campo Tipo Movimento!');", true);
                return;
            }

            if (string.IsNullOrEmpty(txtValorQuantidade.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), string.Empty, "alert('Preencha o campo Tipo Movimento!');", true);
                return;
            }

            IncluiProdutoMovimento();
        }
    }
}