<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControleProduto._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Controle de Estoque</title>

        <link rel="stylesheet" href="Styles/bootstrap-3.3.5/css/bootstrap.min.css" media="screen" />
        <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>        
        <script type="text/javascript" src="Styles/bootstrap-3.3.5/js/bootstrap.min.js"></script>
        

        <style type="text/css">
            /**ASP MENU NAVBAR STYLE*/
            body
            {
                font-family: Arial;
                font-size: 10pt;
            }
            .main_menu
            {
                width: 100px;
                background-color: #8AE0F2;
                color: #000;
                text-align: center;
                height: 30px;
                line-height: 30px;
                margin-right: 5px;
            }
            .level_menu
            {
                width: 110px;
                background-color: #000;
                color: #fff;
                text-align: center;
                height: 30px;
                line-height: 30px;
                margin-top: 5px;
            }
            .selected
            {
                background-color: #852B91;
                color: #fff;
            }

            /**BOOTSTRAP NAVBAR STYLE*/
            .dropdown-submenu {
                position: relative;
            }

            .dropdown-submenu>.dropdown-menu {
                top: 0;
                left: 100%;
                margin-top: -6px;
                margin-left: -1px;
                -webkit-border-radius: 0 6px 6px 6px;
                -moz-border-radius: 0 6px 6px;
                border-radius: 0 6px 6px 6px;
            }

            .dropdown-submenu:hover>.dropdown-menu {
                display: block;
            }

            .dropdown-submenu>a:after {
                display: block;
                content: " ";
                float: right;
                width: 0;
                height: 0;
                border-color: transparent;
                border-style: solid;
                border-width: 5px 0 5px 5px;
                border-left-color: #ccc;
                margin-top: 5px;
                margin-right: -10px;
            }

            .dropdown-submenu:hover>a:after {
                border-left-color: #fff;
            }

            .dropdown-submenu.pull-left {
                float: none;
            }

            .dropdown-submenu.pull-left>.dropdown-menu {
                left: -100%;
                margin-left: 10px;
                -webkit-border-radius: 6px 0 6px 6px;
                -moz-border-radius: 6px 0 6px 6px;
                border-radius: 6px 0 6px 6px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--              
            <div>
                <asp:Menu ID="Menu" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu_MenuItemClick">
                    <Items>                        
                        <asp:MenuItem Text="Cadastro">
                            <asp:MenuItem Text="Produto">
                                <asp:MenuItem Text="Cadastro de Produto" NavigateUrl="../Cadastro/frm_Cadastro_Produto_Carrega.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>                         
                        <asp:MenuItem Text="Prodedimento">
                            <asp:MenuItem Text="Produto">
                                <asp:MenuItem Text="Movimento de Produto" NavigateUrl="../Movimento/frm_Movimento_Produto_Carrega.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>                        
                        <asp:MenuItem Text="Segurança"></asp:MenuItem>                        
                    </Items>
                    <LevelMenuItemStyles>
                        <asp:MenuItemStyle CssClass="main_menu" />
                        <asp:MenuItemStyle CssClass="level_menu" />
                        <asp:MenuItemStyle CssClass="level_menu" />
                    </LevelMenuItemStyles>
                </asp:Menu>
            </div>
            <div style="clear:both"><br /></div>
        --%>

            <div style="clear:both"><br /></div>

            <nav class="navbar navbar-inverse container">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span> 
                        </button>                            
                        <%--<a class="navbar-brand">WebSiteName</a>--%>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav">                                
                            <li><a href="#">Página Inicial</a></li>
                            <li>
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Cadastro <b class="caret"></b></a>
                                <ul class="dropdown-menu">                                        
                                    <li class="dropdown-submenu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Produto</a>
                                        <ul class="dropdown-menu">
                                            <li><a href="#">Cadastro de Produto</a></li>
                                        </ul>
                                    </li>                                        
                                </ul>
                            </li>

                            <li>
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Procedimento <b class="caret"></b></a>
                                <ul class="dropdown-menu">                                        
                                    <li class="dropdown-submenu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Produto</a>
                                        <ul class="dropdown-menu">
                                            <li><a href="#">Movimento de Produto</a></li>
                                        </ul>
                                    </li>                                        
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>     
            
            <div style="clear:both"><br /></div>   
        </form>
    </body>
</html>
