<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCadastroProduto.aspx.cs" Inherits="ControleProduto.Pages.Cadastro.frmCadastroProduto" %>

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
                    <legend>Dados do Produto</legend>

                    <table>
                        <tr>
                            <td>Código:</td>
                            <td>
                                <asp:TextBox ID="txtCodigo" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Descrição:</td>
                            <td>
                                <asp:TextBox ID="txtDescricao" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Ativo:</td>
                            <td><asp:CheckBox ID="chkAtivo" runat="server" Checked="true" /></td>                            
                        </tr>
                    </table>

                    <div style="float:left;">
                        <asp:Button ID="btnIncluir" runat="server" Width="100px" Text="Incluir" OnClick="btnIncluir_Click" />
                        <asp:Button ID="btnAlterar" runat="server" Width="100px" Text="Alterar" OnClick="btnAlterar_Click" />
                        <asp:Button ID="btnNovo" runat="server" Width="100px" Text="Novo" OnClick="btnNovo_Click" />
                        <asp:Button ID="btnVoltar" runat="server" Width="100px" Text="Voltar" OnClick="btnVoltar_Click" />
                    </div>
                </fieldset>
            </div>
            <asp:HiddenField ID="hdfCodigoProduto" runat="server" />
        </form>
    </body>
</html>
