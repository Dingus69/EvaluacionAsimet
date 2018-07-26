<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="EvaluacionG5.WEB.menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" type="text/javascript"></script>
    <script src="include/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Menu(op) {
            switch (op) {
                case "2":
                    $('#SubMenuAdm').modal('show');
                    break;
                case "3":
                    $('#SubMenuGestion').modal('show');
                    break;
            }
        }
        function Ir(op) {
            switch (op) {
                case "1":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/evaluacion/dashboard.aspx") %>";
                    break;
                case "2_1":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/lista_asignaciones.aspx") %>";
                    break;
                case "2_2":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/lista_instrumentos.aspx") %>";
                    break;
                case "2_3":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/carga_nomina.aspx") %>";
                    break;
                case "2_4":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/mantenedor_usuarios.aspx") %>";
                    break;
                case "2_5":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/mantenedor_escala.aspx") %>";
                    break;
                case "2_6":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/mantenedor_tipo_seccion.aspx") %>";
                    break;
                case "2_7":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/mantenedor_parametros.aspx") %>";
                    break;
                case "2_8":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/administracion/mantenedor_cursos.aspx") %>";
                    break;
                case "3_1":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/gestion/reporte_detallado.aspx") %>";
                    break;
                case "3_2":
                    document.location.href = "<%= Page.ResolveClientUrl("~/modulos/gestion/reporte_consolidado.aspx") %>";
                    break;
            }

        }
    </script>
    <div class="container">
        <h1 class="text-center">Menú Principal</h1>
        <hr />
        <div class="col-md-4 text-center" id="itemEval" runat="server">
            <a href="#"><img src="include/images/clipboard.svg" class="icon-menu img-responsive" onclick="Ir('1');" /><h4>Evaluación</h4></a>
        </div>
        <div class="col-md-4 text-center" id="itemAdmin" runat="server">
            <a href="#"><img src="include/images/settings.svg" class="icon-menu img-responsive" onclick="Menu('2');" /><h4>Administración</h4></a>
        </div>
        <div class="col-md-4 text-center" id="itemGestion" runat="server">
            <a href="#"><img src="include/images/reportes.svg" class="icon-menu img-responsive" onclick="Ir('3_1');" /><h4>Reportes e Índices</h4></a>
        </div>
    </div>

    <div id="SubMenuAdm" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: titulos,_titMenuAdministracion%>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_2');">
                        <span>
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: menu,_menuAdmEvaluacion%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_1');">
                        <span>
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: menu,_menuAdmAsignacion%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_3');">
                        <span>
                            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: menu,_menuAdmCargaUsuarios%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_4');">
                        <span>
                            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: menu,_menuAdmUsuario%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_8');">
                        <span>
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: menu,_menuAdmCursos%>" /></span>
                    </div>
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_5');">
                        <span>
                            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: menu,_menuAdmEscala%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_6');">
                        <span>
                            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: menu,_menuAdmTiposSeccion%>" /></span>
                    </div>
                    <br />
                    <div class="ItemSubMenu glyphicon glyphicon-cog" onclick="Ir('2_7');">
                        <span>
                            <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: menu,_menuAdmParametros%>" /></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="SubMenuGestion" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: titulos,_titMenuGestion%>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="ItemSubMenu" onclick="Ir('3_1');">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: menu,_menuGestionConsolidado%>" /></span>
                    </div>
                    <div class="ItemSubMenu" onclick="Ir('3_2');">
                        <span>
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: menu,_menuGestionDetalleEvaluaciones%>" /></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
