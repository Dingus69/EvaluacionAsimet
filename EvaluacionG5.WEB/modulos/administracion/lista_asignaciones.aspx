<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="lista_asignaciones.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.lista_asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/include/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }
        function Menu(op) {
            switch (op) {
                case "0":
                    $('#modal-danger').modal('show');
                    break;
                case "1":
                    $('#modBuscar').modal('show');
                    break;
            }
        }
    </script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '< Ant',
            nextText: 'Sig >',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
        $(function () {
            $("#<%=txtInicio.ClientID%>").datepicker();
            $("#<%=txtFin.ClientID%>").datepicker();
        });
    </script>
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAsignarEvaluacion%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column triple10">
                    <label>
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiInstrumento%>" /></label>
                    <asp:DropDownList ID="ddlInstrumentos" runat="server"></asp:DropDownList>
                </div>
                <div class="cbp-mc-10column triple10">
                    <label>
                        <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="256"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiDirecciónEval%>" /></label>
                    <asp:DropDownList ID="ddlDireccion" runat="server"></asp:DropDownList>
                </div>
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiInicio%>" /></label>
                    <asp:TextBox ID="txtInicio" runat="server"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiFin%>" /></label>
                    <asp:TextBox ID="txtFin" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiConsultar%>" OnClick="btnConsultar_Click" />
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiNuevo%>" OnClick="btnNuevo_Click" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="50" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="imgEditar" ImageUrl="~/include/images/css/EDITAR.png" runat="server" OnClick="imgEditar_Click" />--%>
                                    <asp:LinkButton ID="lnkEditar" runat="server" data-toggle="tooltip" OnClick="lnkEditar_Click" title="<%$ Resources: etiquetas,_etiEditar%>"><span class="glyphicon glyphicon-edit" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfCodInstrumento" runat="server" Value='<%# Bind("NOMBRE") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabInstrumento%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstrumento" runat="server" Text='<%# Bind("NOMBRE_INSTRUMENTO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabInicio%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabFin%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabCantAsignaciones%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblAsignaciones" runat="server" Text='<%# Bind("ASIGNACIONES") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="modal modal-warning fade" id="modal-warning">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                    <asp:Button ID="btnContinuarGuardar" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarGuardar_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal modal-success fade" id="modal-success">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title"><asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal modal-danger fade" id="modal-danger">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title"><asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script>
        $(document).ready(function(){
            $('[data-toggle="tooltip"]').tooltip();   
        });
    </script>
</asp:Content>
