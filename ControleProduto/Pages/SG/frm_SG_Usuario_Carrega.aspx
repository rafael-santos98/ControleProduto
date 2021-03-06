﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_SG_Usuario_Carrega.aspx.cs" Inherits="ControleProduto.Pages.SG.frm_SG_Usuario_Carrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">

        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="width:960px;">
                <div style="float:right;">
                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="100px" OnClick="btnNovo_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" Width="100px" OnClick="btnVoltar_Click"   />
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
                                <td><label>Nome:</label></td>
                                <td><asp:TextBox ID="txtDescricao" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><label>Nome de Usuário:</label></td>
                                <td><asp:TextBox ID="txtNomeUsuario" runat="server" Width="200px"></asp:TextBox></td>
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
                        <asp:GridView ID="gdvUsuario" Width="100%" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Código" DataTextField="NCDUSUARIO" DataNavigateUrlFields="NCDUSUARIO" DataNavigateUrlFormatString="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" NavigateUrl="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" />
                                <asp:HyperLinkField HeaderText="Nome" DataTextField="CDSUSUARIO" DataNavigateUrlFields="NCDUSUARIO" DataNavigateUrlFormatString="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" NavigateUrl="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" />
                                <asp:HyperLinkField HeaderText="Usuario" DataTextField="CNMUSUARIO" DataNavigateUrlFields="NCDUSUARIO" DataNavigateUrlFormatString="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" NavigateUrl="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" />
                                <asp:HyperLinkField HeaderText="Ativo" DataTextField="BIDATIVO_TEXTO" DataNavigateUrlFields="NCDUSUARIO" DataNavigateUrlFormatString="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" NavigateUrl="frm_SG_Usuario_IncluiAtualiza.aspx?CodigoUsuario={0}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </fieldset>
            </div>
        </form>
    </body>
</html>
