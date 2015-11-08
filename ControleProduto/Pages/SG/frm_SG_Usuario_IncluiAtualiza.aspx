<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_SG_Usuario_IncluiAtualiza.aspx.cs" Inherits="ControleProduto.Pages.SG.frm_SG_Usuario_IncluiAtualiza" %>

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
                    <legend>Dados do Usuário</legend>

                    <table>
                        <tr>
                            <td>Código:</td>
                            <td>
                                <asp:TextBox ID="txtCodigo" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Nome:</td>
                            <td>
                                <asp:TextBox ID="txtDescricao" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Nome de Usuário:</td>
                            <td>
                                <asp:TextBox ID="txtNomeUsuario" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Ativo:</td>
                            <td><asp:CheckBox ID="chkAtivo" runat="server" Checked="true" /></td>                            
                        </tr>
                    </table>

                    <div style="float:left;">
                        <asp:Button ID="btnIncluir" runat="server" Width="100px" Text="Incluir" OnClick="btnIncluir_Click" />
                        <asp:Button ID="btnAlterar" runat="server" Width="100px" Text="Alterar" OnClick="btnAlterar_Click"  />
                        <asp:Button ID="btnNovo" runat="server" Width="100px" Text="Novo" OnClick="btnNovo_Click"  />
                        <asp:Button ID="btnVoltar" runat="server" Width="100px" Text="Voltar" OnClick="btnVoltar_Click"  />
                    </div>
                </fieldset>

                <div id="dvAlterar_Senha" runat="server">
                    <fieldset> 
                        <legend>Alterar Senha</legend>
                        <table>
                            <tr>
                                <td colspan="2"><asp:CheckBox ID="chkSenhaPadrao" runat="server" Checked="false" Text="Aplicar senha padrão" AutoPostBack="true" OnCheckedChanged="chkSenhaPadrao_CheckedChanged" /></td>
                            </tr>
                            <tr>
                                <td>Digite a Senha:</td>
                                <td>
                                    <asp:TextBox ID="txtSenha_1" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Redigite a Senha:</td>
                                <td>
                                    <asp:TextBox ID="txtSenha_2" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <div style="float:left;">
                            <asp:Button ID="btnAlterar_Senha" runat="server" Width="100px" Text="Alterar" OnClick="btnAlterar_Senha_Click" />
                        </div>
                    </fieldset>
                </div>
            </div>    
            <asp:HiddenField ID="hdfCodigoUsuario" runat="server" />
        </form>
    </body>
</html>
