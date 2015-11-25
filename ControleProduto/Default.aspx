<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControleProduto._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Home Page - Controle de Estoque</title>
        
        <!-- Meta Tags -->     
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <!-- JQuery Script -->             
        <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>        

        <!-- Bootstrap Core CSS -->
        <link rel="stylesheet" href="Styles/bootstrap-3.3.5/css/bootstrap.css" media="screen" />
        <link rel="stylesheet" href="Styles/bootstrap-3.3.5/css/bootstrap-theme.min.css" media="screen" />
        <link rel="stylesheet" href="Styles/bootstrap-3.3.5/css/bootstrap.min.css" media="screen" />
        
        <!-- Bootstrap Script -->     
        <script type="text/javascript" src="Styles/bootstrap-3.3.5/js/bootstrap.js"></script>
        <script type="text/javascript" src="Styles/bootstrap-3.3.5/js/bootstrap.min.js"></script>

        <style type="text/css">
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

            /**/
      
        </style>

     <script type="text/javascript">
         function pageLoad() {
             // Setup drop down menu
             $('.dropdown-toggle').dropdown();

             // Fix input element click problem
             $('.dropdown input, .dropdown label').click(function (e) {
                 e.stopPropagation();
             });
         }
    </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   

            <div style="clear:both"><br /></div>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <div style="clear:both"><br /></div>

            <%--           
            <nav class="navbar navbar-inverse container">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span> 
                        </button>                            
                        <a class="navbar-brand">WebSiteName</a>
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
            --%>
            <nav class="navbar navbar-inverse container">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span> 
                        </button>                            
                        <a class="navbar-brand">Controle de Estoque</a>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav">                                
                            <li>
                                <asp:LinkButton ID="lnkbtnPaginaInicial" runat="server" CommandName="PaginaInicial" Text="Página Inicial" OnClick="lnkbtnPaginaInicial_Click"></asp:LinkButton>
                            </li>
                            <li>
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Cadastro <b class="caret"></b></a>
                                <ul class="dropdown-menu">                                        
                                    <li class="dropdown-submenu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Produto</a>
                                        <ul class="dropdown-menu">
                                            <li>
                                                <asp:LinkButton ID="lnkbtnCadastroProduto" runat="server" Text="Cadastro de Produto" OnClick="lnkbtnCadastroProduto_Click"></asp:LinkButton>
                                            </li>
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
                                            <li>                                                
                                                <asp:LinkButton ID="lnkbtnMovimentoProduto" runat="server" Text="Movimento de Produto" OnClick="lnkbtnMovimentoProduto_Click"></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>                                        
                                </ul>
                            </li>

                            <li>
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Segurança <b class="caret"></b></a>
                                <ul class="dropdown-menu">                                        
                                    <li class="dropdown-submenu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Usuário</a>
                                        <ul class="dropdown-menu">
                                            <li>                                                
                                                <asp:LinkButton ID="lnkbtnSGCadastroUsuario" runat="server" Text="Cadastro de Usuário" OnClick="lnkbtnSGCadastroUsuario_Click"></asp:LinkButton>
                                            </li>
                                        </ul>                                     
                                    </li> 
                                    <li class="dropdown-submenu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Permissões</a>
                                        <ul class="dropdown-menu">
                                            <li>                                                
                                                <asp:LinkButton ID="lnkbtnSGPermissaoUsuario" runat="server" Text="Permissões por Usuário" OnClick="lnkbtnSGPermissaoUsuario_Click"></asp:LinkButton>
                                            </li>
                                        </ul>                                     
                                    </li>                                                                              
                                </ul>
                            </li>
                        </ul>

                        <!-- Deslogado-->
                        <ul id="MenuDeslogado" runat="server" class="nav navbar-nav navbar-right">                  
                            <li class="dropdown">
                                <a href=#" class="dropdown-toggle" data-toggle="dropdown">Entrar <b class="caret"></b></a>
                                <div class="dropdown-menu" style="width:300px">
                                    <div class="login-panel panel panel-default">
                                        <div class="panel-body">                            
                                            <fieldset>
                                                <div class="form-group">                                                    
                                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuário" name="usuario"></asp:TextBox>
                                                </div>
                                                <div class="form-group">                                                    
                                                    <asp:TextBox ID="txtUsuarioSenha" runat="server" CssClass="form-control" placeholder="Password" name="password" TextMode="Password"></asp:TextBox>
                                                </div>
                                                <div class="checkbox">
                                                    <label>
                                                        <input id="chkLembrar" runat="server" name="remember" type="checkbox" value="Remember Me">Remember Me
                                                    </label>
                                                </div>
                                                <!-- Change this to a button or input when using this as a form -->                                                
                                                <asp:Button ID="btnLogin"  runat="server" CssClass="btn btn-success btn-block" Text="Log-In" OnClick="btnLogin_Click" />
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>

                        <!-- Logado-->
                        <ul id="MenuLogado" runat="server" class="nav navbar-nav navbar-right hidden">                  
                            <li class="dropdown">
                                <a href=#" class="dropdown-toggle" data-toggle="dropdown">Sair <b class="caret"></b></a>
                                <div class="dropdown-menu" style="width:300px">
                                    <div class="login-panel panel panel-default">
                                        <div class="panel-body">                            
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <p class="text-center">
                                                        <span class="icon-size"><img src="Images/icon-log-in.jpg"</span>
                                                    </p>
                                                </div>
                                                <div class="col-lg-8">
                                                    <p class="text-left"><asp:Label ID="lblNomeCompletoUsuario" runat="server" Font-Bold="true"></asp:Label></p>
                                                    <p class="text-left small"><asp:Label ID="lblNickNameUsuario" runat="server"></asp:Label></p>
                                                </div>

                                                <div class="divider"></div>

                                                <div class="col-lg-12">
                                                    <p>                                            
                                                        <asp:Button ID="btnLogout"  runat="server" CssClass="btn btn-danger btn-block" Text="Log-Out" OnClick="btnLogout_Click" />
                                                    </p>
                                                </div>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>                         
                    </div>
                </div>
            </nav>              
            
            <div style="clear:both"><br /></div>   

            <iframe id="IfrmRedirect" runat="server" src="frmInicial.aspx" scrolling="yes" frameborder="0" style="width:100%; height:720px; overflow:hidden;"></iframe>
        </form>
    </body>
</html>
