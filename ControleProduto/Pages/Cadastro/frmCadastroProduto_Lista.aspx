<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCadastroProduto_Lista.aspx.cs" Inherits="ControleProduto.Pages.Cadastro.frmCadastroProduto_Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">

        </style>
    </head>
    <body>
        <form id="form1" runat="server">

            <div style="width:960px;">
                <div style="float:right;">
                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="100px" OnClick="btnNovo_Click" />
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
                                        <asp:ListItem Value="0" Text="(Todos)" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Inativo"></asp:ListItem>
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
                                <asp:HyperLinkField DataTextField="NCDPRODUTO" DataNavigateUrlFields="NCDPRODUTO" DataNavigateUrlFormatString="frmCadastroProduto.aspx?CodigoProduto={0}" NavigateUrl="frmCadastroProduto.aspx?CodigoProduto={0}" />                                
                                <asp:BoundField DataField="CDSPRODUTO" HeaderText="Descrição" />
                                <asp:BoundField DataField="NVLSALDO" HeaderText="Saldo" />
                                <asp:BoundField DataField="BIDATIVO_TEXTO" HeaderText="Ativo" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </fieldset>
            </div>
        </form>
    </body>
</html>
