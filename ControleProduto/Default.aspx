<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControleProduto._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <div style="width:470px;margin: 5px 5px 5px 5px;"> 
                <fieldset>
                    <legend>Produto</legend>

                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnProduto_Cadastro" runat="server" Text="Cadastro" Width="150px" Height="45px" OnClick="btnProduto_Cadastro_Click" />
                            </td>
                            <td>
                                Consulta, Inclusão e Alteração de Produto.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnProduto_Movimento" runat="server" Text="Movimento" Width="150px" Height="45px" OnClick="btnProduto_Movimento_Click" />
                            </td>
                            <td>
                                Consulta e Inclusão de Movimento de Produto.
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </form>
    </body>
</html>
