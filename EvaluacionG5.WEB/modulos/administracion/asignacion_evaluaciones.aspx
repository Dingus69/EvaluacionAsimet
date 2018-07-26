<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="asignacion_evaluaciones.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.asignacion_evaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
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
                case "2":
                    $('#modal-warning').modal('show');
                    break;
                case "3":
                    $('#modal-danger').modal('show');
                    break;
                case "4":
                    $('#modal-success').modal('show');
                    break;
            }
        }
    </script>
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
            $("#<%=txtActInicio.ClientID%>").datepicker();
            $("#<%=txtActFin.ClientID%>").datepicker();
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
                <div class="cbp-mc-10column triple10">
                    <h2>
                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titColaboradores%>" />
                        <asp:Button ID="btnBuscarColaboradores" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiBuscar%>" OnClick="btnBuscarColaboradores_Click" />
                    </h2>
                </div>
                <div class="cbp-mc-10column">
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdColaboradores" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="50" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUTCOMPLETO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBREEMPLEADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApPaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("APELLIDOPATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApMaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("APELLIDOMATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabGerencia%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblGerencia" runat="server" Text='<%# Bind("NOMBRE_GERENCIA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabCargo%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblCargo" runat="server" Text='<%# Bind("NOMBRE_CARGO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabJefe%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblJefe" runat="server" Text='<%# Bind("JEFE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div id="divActualizacion" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="cbp-mc-1column">
                        <h2>
                            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: titulos,_titActualizacion%>" /></h2>
                    </div>
                </div>
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="cbp-mc-10column">
                        <label>
                            <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources: etiquetas,_etiInicio%>" /></label>
                        <asp:TextBox ID="txtActInicio" runat="server"></asp:TextBox>
                    </div>
                    <div class="cbp-mc-10column">
                        <label>
                            <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources: etiquetas,_etiFin%>" /></label>
                        <asp:TextBox ID="txtActFin" runat="server"></asp:TextBox>
                    </div>
                    <div class="cbp-mc-10column octuple10">
                        <asp:Button ID="btnAplicarFechas" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAplicarFechas%>" OnClick="btnAplicarFechas_Click" />
                        <asp:Button ID="btnSeleccionTodos" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiSelecTodos%>" OnClick="btnSeleccionTodos_Click" />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiActualizar%>" OnClick="btnActualizar_Click" />
                    </div>
                </div>
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdAsignaciones" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdAsignaciones_RowDataBound">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="50" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabEvaluar%>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEvaluar" runat="server" data-toggle="tooltip" OnClick="lnkEvaluar_Click" title="<%$ Resources: etiquetas,_etiEvaluar%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUTCOMPLETO") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfCodInstrumentoEmpleado" runat="server" Value='<%# Bind("CODINSTRUMENTOEMPLEADO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreEvaluado" runat="server" Text='<%# Bind("NOMBRE_EVALUADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabInicio%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIOEVALUACION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabFin%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FINEVALUACION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabEstado%>">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="hdfCodEstado" runat="server" Value='<%# Bind("CODESTADOEVAL") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabEvaluador%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblEvaluador" runat="server" Text='<%# Bind("NOMBRE_EVALUADOR") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabResultado%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("RESULTADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnEliminarColaborador" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiEliminar%>" OnClick="btnEliminarColaborador_Click" Visible="false" />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

    <div id="modBuscar" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95% !important">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titBuscadorColaboradores %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                            <asp:TextBox ID="txtNombreColaborador" MaxLength="128" runat="server"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divEmpresa" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiEmpresa%>" /></label>
                            <asp:DropDownList ID="ddlEmpresa" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divGerencia" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiGerencia%>" /></label>
                            <asp:DropDownList ID="ddlGerencia" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divCentroCosto" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiCentroCosto%>" /></label>
                            <asp:DropDownList ID="ddlCentroCosto" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divSucursal" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiSucursal%>" /></label>
                            <asp:DropDownList ID="ddlSucursal" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divArea" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiArea%>" /></label>
                            <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divCargo" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiCargo%>" /></label>
                            <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divRol" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiRol%>" /></label>
                            <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divClasificador1" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador1%>" /></label>
                            <asp:DropDownList ID="ddlClasificador1" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divClasificador2" runat="server" visible="false">
                            <label>
                                <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador2%>" /></label>
                            <asp:DropDownList ID="ddlClasificador2" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="table-wrapper cbp-mc-1column">
                            <asp:GridView ID="grdColaboradoresTmp" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="50" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUTCOMPLETO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBREEMPLEADO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApPaterno%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("APELLIDOPATERNO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApMaterno%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("APELLIDOMATERNO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabGerencia%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGerencia" runat="server" Text='<%# Bind("NOMBRE_GERENCIA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabCargo%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCargo" runat="server" Text='<%# Bind("NOMBRE_CARGO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabJefe%>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJefe" runat="server" Text='<%# Bind("JEFE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiBuscar%>" OnClick="btnBuscar_Click" />
                            <asp:Button ID="btnAgregar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAgregarSeleccionados%>" OnClick="btnAgregar_Click" />
                            <asp:Button ID="btnAgregarTodos" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAgregarTodos%>" OnClick="btnAgregarTodos_Click" />
                            <asp:Button ID="btnCerrar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" OnClick="btnCerrar_Click" />
                        </div>
                    </div>
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
                    <h4 class="modal-title">
                        <asp:Literal ID="Literal29" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal30" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal31" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                    <h4 class="modal-title">
                        <asp:Literal ID="Literal32" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal33" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                    <h4 class="modal-title">
                        <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>


