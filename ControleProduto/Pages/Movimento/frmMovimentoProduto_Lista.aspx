<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMovimentoProduto_Lista.aspx.cs" Inherits="ControleProduto.Pages.Movimento.frmMovimentoProduto_Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="width:960px;">
                <div style="float:right;">
                    <asp:Button ID="btnIncluir" runat="server" Text="Incluir" Width="100px" OnClick="btnIncluir_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Width="100px" Text="Voltar" OnClick="btnVoltar_Click"  />
                </div>                

                <div style="clear:both;"></div>

                <div style="float:left; width:380px;">
                    <fieldset>
                        <legend>Filtro</legend>

                        <div style="margin: 5px 5px 5px 5px;">
                            <table>
                                <tr>
                                    <td><label>Código:</label></td>
                                    <td><asp:TextBox ID="txtCodigo" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><label>Data De:</label></td>
                                    <td><asp:TextBox ID="txtDataDe" runat="server" Width="100px"></asp:TextBox></td>
                                    <td><label>Até:</label></td>
                                    <td><asp:TextBox ID="txtDataAte" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><label>Produto:</label></td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlProduto" runat="server" Width="100%">
                                            <asp:ListItem Value="0" Text="(Todos)" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Inativo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td><label>Tipo Mov.:</label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoMovimento" runat="server" Width="100%">
                                            <asp:ListItem Value="0" Text="(Todos)" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="E" Text="Entrada"></asp:ListItem>
                                            <asp:ListItem Value="S" Text="Saída"></asp:ListItem>
                                            <asp:ListItem Value="C" Text="Cancelado"></asp:ListItem>
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
                
                <div style="float:left; width:570px; margin-left: 10px;">
                    <fieldset>
                        <legend>Resultados</legend>
                        <div style="margin: 5px 5px 5px 5px;">
                            <asp:GridView ID="gdvDados" Width="100%" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField HeaderText="Código" DataField="NCDPRODUTOMOVIMENTO" />
                                    <asp:BoundField HeaderText="Produto" DataField="CDSPRODUTO" />
                                    <asp:BoundField HeaderText="Observação" DataField="CDSOBSERVACAO" />
                                    <asp:BoundField HeaderText="Dt. Movimento" DataField="DTMOVIMENTO" />
                                    <asp:BoundField HeaderText="Qtde" DataField="NQTPRODUTOMOVIMENTO" />
                                    <asp:BoundField HeaderText="Tipo" DataField="CDSTIPOMOVIMENTO_TEXTO" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </fieldset>
                </div>
            </div>               
        </form>
    </body>
</html>
