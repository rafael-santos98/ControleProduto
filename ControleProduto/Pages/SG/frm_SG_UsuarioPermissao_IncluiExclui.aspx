<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_SG_UsuarioPermissao_IncluiExclui.aspx.cs" Inherits="ControleProduto.Pages.SG.frm_SG_UsuarioPermissao_IncluiExclui" %>

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

        <style type="text/css">
 
                    </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="container">
                
                <h1 class="text-center">Permissões de Acesso por Usuário</h1>
                <hr />

                <label for="ddlUsuario" class="control-label">Usuário:</label>                
                
                <div class="form-group">
                    <asp:DropDownList ID="ddlUsuario" runat="server" Width="200px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"></asp:DropDownList>
                </div>
                

                <div style="clear:both"><br /></div>

                <div style="width:1000px">
                    <div style="float:left">
                        <asp:ListBox ID="lstPermissoesNaoAssociadas" runat="server" Width="350px" Height="200px" SelectionMode="Multiple" CssClass="list-group"></asp:ListBox>
                    </div>
                
                    <div style="float:left; width:100px;text-align:center;">
                        <asp:Button ID="btnAdd" runat="server" Text=" >> " CssClass="btn btn-primary"  OnClick="btnAdd_Click" />
                        <asp:Button ID="btnRemove" runat="server" Text=" << " CssClass="btn btn-primary" OnClick="btnRemove_Click" />
                    </div>

                    <div style="float:left">
                        <asp:ListBox ID="lstPermissoesAssociadas" runat="server" Width="350px" Height="200px"  SelectionMode="Multiple" CssClass="list-group"></asp:ListBox>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>
