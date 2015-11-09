<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Cadastro_Produto_Carrega.aspx.cs" Inherits="ControleProduto.Pages.Cadastro.frmCadastroProduto_Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>

        <!-- Meta Tags -->     
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <!-- JQuery Script -->             
        <script type="text/javascript" src="../../Scripts/jquery-1.9.1.js"></script>        

        <!-- Bootstrap Core CSS -->
        <link rel="stylesheet" href="../../Styles/bootstrap-3.3.5/css/bootstrap.css" media="screen" />
        <link rel="stylesheet" href="../../Styles/bootstrap-3.3.5/css/bootstrap-theme.min.css" media="screen" />
        <link rel="stylesheet" href="../../Styles/bootstrap-3.3.5/css/bootstrap.min.css" media="screen" />
        
        <!-- Bootstrap Script -->     
        <script type="text/javascript" src="../../Styles/bootstrap-3.3.5/js/bootstrap.js"></script>
        <script type="text/javascript" src="../../Styles/bootstrap-3.3.5/js/bootstrap.min.js"></script>

        <style type="text/css"></style>
        <script type="text/javascript"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="width:960px;">
                <div style="float:right;">
                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="100px" OnClick="btnNovo_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" Width="100px" OnClick="btnVoltar_Click"  />
                </div>                
            </div>

            <div style="clear:both;"></div>

            <div style="float:left; width:300px;">
                <fieldset>
                    <legend>Filtro</legend>

                    <div style="margin: 5px 5px 5px 5px;">
                        <table>
                            <tr>
                                <td><label>Código:</label></td>
                                <td><asp:TextBox ID="txtCodigo" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><label>Descrição:</label></td>
                                <td><asp:TextBox ID="txtDescricao" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><label>Ativo:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddlAtivo" runat="server" Width="100%">
                                        <asp:ListItem Value="" Text="(Todos)" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Inativo"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>

                        <div style="float:right;">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </fieldset>
            </div>

            <div style="float:left; width:650px; margin-left: 10px;">
                <fieldset> 
                    <legend>Resultados</legend>
                    <div style="margin: 5px 5px 5px 5px;">
                        <asp:GridView ID="gdvDados" Width="100%" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Código" DataTextField="NCDPRODUTO" DataNavigateUrlFields="NCDPRODUTO" DataNavigateUrlFormatString="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" NavigateUrl="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" />
                                <asp:HyperLinkField HeaderText="Descrição" DataTextField="CDSPRODUTO" DataNavigateUrlFields="NCDPRODUTO" DataNavigateUrlFormatString="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" NavigateUrl="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" />
                                <asp:HyperLinkField HeaderText="Saldo" DataTextField="NQTPRODUTOSALDO" DataNavigateUrlFields="NCDPRODUTO" DataNavigateUrlFormatString="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" NavigateUrl="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" />
                                <asp:HyperLinkField HeaderText="Ativo" DataTextField="BIDATIVO_TEXTO" DataNavigateUrlFields="NCDPRODUTO" DataNavigateUrlFormatString="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" NavigateUrl="frm_Cadastro_Produto_IncluiAtualiza.aspx?CodigoProduto={0}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </fieldset>
            </div>
        </form>
    </body>
</html>
