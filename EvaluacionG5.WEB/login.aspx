<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EvaluacionG5.WEB.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap -->
    <link href="include/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!--Google Fonts-->
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" />

    <!-- Estilo Login -->
    <link href="include/bootstrap/css/login.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/include/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">

        function Menu(op) {
            switch (op) {
                case "0":
                    $('#modal-danger').modal('show');
                    break;
                case "1":
                    $('#modRecuperarContrasena').modal('show');
                    break;
            }
        }
    </script>


    <title>Evaluación G5</title>
</head>
<body runat="server" id="bodyLogin">
    <form id="form1" runat="server">

        <div class="container" style="margin-top: 40px">
            <div class="row">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>Login</strong>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="row">
                                    <div class="center-block">
                                        <img class="logog5 img-responsive" src="include/images/logo-header.png" alt="G5 Evaluación" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-md-10  col-md-offset-1 ">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="glyphicon glyphicon-user"></i>
                                                </span>
                                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario" name="loginname"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="glyphicon glyphicon-lock"></i>
                                                </span>
                                                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Password" name="password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group text-right">
                                            <asp:LinkButton ID="lnkOlvidasteContrasena" runat="server" Text="¿Olvidaste tu contraseña?" OnClick="lnkOlvidasteContrasena_Click"></asp:LinkButton>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnIngresar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div id="modRecuperarContrasena" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document" style="width: 25%">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                            data-backdrop="false">
                            <span aria-hidden="true">×</span>
                        </button>
                        <h2>
                            <asp:Literal ID="Literal54" runat="server" Text="<%$ Resources: titulos,_titOlvidoContrasena %>" /></h2>
                    </div>
                    <div class="modal-body">
                        <div>
                            <div class="row form-group">
                                <div class="col-sm-12">
                                    <label>Rut</label>
                                    <asp:TextBox ID="txtRut" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-6">
                                    <label></label>
                                    <asp:Image ID="imgCaptcha" runat="server" />
                                </div>
                                <div class="col-sm-6">
                                    <label>Escriba el texto</label>
                                    <asp:TextBox ID="txtCaptcha" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="cbp-mc-form text-center" style="width: 90%; margin-left: auto; margin-right: auto;">
                                    <asp:Button ID="btnRecuperar" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnRecuperar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>

    <footer class="footer">
        <div class="container">
            <p class="text-muted text-center">Desarrollado por <a href="#" target="_blank">Grupo5</a></p>
        </div>
    </footer>


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="include/bootstrap/js/bootstrap.min.js"></script>


    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="ContenedorLogin">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="User"></asp:TextBox>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="Pass"></asp:TextBox>
                    <asp:Button ID="btnIngresar" runat="server" Text="" CssClass="Ingresar" onclick="btnIngresar_Click" />
                    <asp:LinkButton ID="lnkCambioClave" CssClass="lnkCambioClave" runat="server" OnClick="lnkCambioClave_Click" >Cambiar Clave</asp:LinkButton>
                </div>	
            </ContentTemplate>
        </asp:UpdatePanel>	
        <div id="modActualizaClave" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        Actualizar clave</h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label1" runat="server" Text="Clave actual"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtPassAntigua" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label2" runat="server" Text="Clave Nueva"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtClaveNueva" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label3" runat="server" Text="Repetir la nueva clave"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtClaveNuevaRepetir" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" CssClass="cbp-mc-submit" Text="Actualizar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divActualizaClave2" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        Actualizar clave</h2>
                </div>
                <div class="modal-body">
                    <div id="div2" class="cbp-mc-form" runat="server" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label5" runat="server" Text="Rut usuario"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtRutUsuarioCambioClave" runat="server" MaxLength="128"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label6" runat="server" Text="Clave actual"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtClaveActual2" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label7" runat="server" Text="Clave Nueva"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtClaveNueva2" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-2column">
                            <asp:Label ID="Label8" runat="server" Text="Repetir la nueva clave"></asp:Label>
                        </div>
                        <div class="cbp-mc-2column">
                            <asp:TextBox ID="txtClaveNuevarepetir2" runat="server" MaxLength="128" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnActualizar2" runat="server" OnClick="btnActualizar2_Click" CssClass="cbp-mc-submit" Text="Actualizar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</body>
</html>
