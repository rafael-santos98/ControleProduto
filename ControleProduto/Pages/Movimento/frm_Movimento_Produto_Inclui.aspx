<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Movimento_Produto_Inclui.aspx.cs" Inherits="ControleProduto.Pages.Movimento.frmMovimentoProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="width:430px;margin: 5px 5px 5px 5px;"> 
                <fieldset> 
                    <legend>Movimento de Produto</legend>

                    <table>
                        <tr>
                            <td>Produto:</td>
                            <td>Tipo de Movimento:</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlProduto" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoMovimento" runat="server" Width="100%">
                                    <asp:ListItem Value="0" Text="(Selecione)" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="E" Text="Entrada"></asp:ListItem>
                                    <asp:ListItem Value="S" Text="Saída"></asp:ListItem>
                                    <asp:ListItem Value="C" Text="Cancelado"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Saldo Atual:</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtValorSaldo" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Quantidade:</td>
                            <td>Descrição:</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtValorQuantidade" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservacao" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <div style="float:right;">
                        <asp:Button ID="btnIncluir" runat="server" Width="100px" Text="Incluir" OnClick="btnIncluir_Click" />
                        <asp:Button ID="btnVoltar" runat="server" Width="100px" Text="Voltar" OnClick="btnVoltar_Click"  />
                    </div>
                </fieldset>
    
            </div>
        </form>
    </body>
</html>
