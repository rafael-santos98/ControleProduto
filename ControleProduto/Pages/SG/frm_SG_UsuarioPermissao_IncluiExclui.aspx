<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_SG_UsuarioPermissao_IncluiExclui.aspx.cs" Inherits="ControleProduto.Pages.SG.frm_SG_UsuarioPermissao_IncluiExclui" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:DropDownList ID="ddlUsuario" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"></asp:DropDownList>

            <div style="clear:both"><br /></div>

            <div style="width:1000px">
                <div style="float:left">
                    <asp:ListBox ID="lstPermissoesNaoAssociadas" runat="server" Width="350px" Height="200px" SelectionMode="Multiple"></asp:ListBox>
                </div>
                
                <div style="float:left; width:100px;text-align:center;">
                    <asp:Button ID="btnAdd" runat="server" Text=" >> " OnClick="btnAdd_Click" />
                    <asp:Button ID="btnRemove" runat="server" Text=" << " OnClick="btnRemove_Click" />
                </div>

                <div style="float:left">
                    <asp:ListBox ID="lstPermissoesAssociadas" runat="server" Width="350px" Height="200px"  SelectionMode="Multiple"></asp:ListBox>
                </div>
            </div>

        </form>
    </body>
</html>
