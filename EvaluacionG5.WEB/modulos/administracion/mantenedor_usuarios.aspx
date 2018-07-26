<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="mantenedor_usuarios.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.mantenedor_usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script src="<%= Page.ResolveClientUrl("~/include/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function CargarFoto() {

            __doPostBack("CargarFoto", ""); 

        }

    </script>
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
                    $('#modEditar').modal('show');
                    break;
                case "2":
                    $('#modal-warning').modal('show');
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
            $("#<%=txtFechaContrato.ClientID%>").datepicker();
            $("#<%=txtFechaNacimiento.ClientID%>").datepicker();
        });
    </script>
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdmUsuarios%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiRut%>" /></label>
                    <asp:TextBox ID="txtRutUsuario" runat="server" MaxLength="12"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column sextuple10">
                    <label>
                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column triple10">
                    <asp:Button ID="btnConsultar" runat="server" Text="<%$ Resources: etiquetas,_etiConsultar%>" CssClass="cbp-mc-submit" OnClick="btnConsultar_Click" />
                    <asp:Button ID="btnNuevo" runat="server" Text="<%$ Resources: etiquetas,_etiNuevo%>" CssClass="cbp-mc-submit" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnCargaMasiva" runat="server" Text="Carga masiva" CssClass="cbp-mc-submit" OnClick="btnCargaMasiva_Click" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="grdResultados_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditar" runat="server" data-toggle="tooltip" OnClick="lnkEditar_Click" title="<%$ Resources: etiquetas,_etiEditar%>"><span class="glyphicon glyphicon-edit" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                    <%--<asp:LinkButton ID="lnkEliminar" runat="server" data-toggle="tooltip" OnClick="lnkEliminar_Click" title="<%$ Resources: etiquetas,_etiEliminar%>"><span class="glyphicon glyphicon-remove" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUT_COMPLETO") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfEmail" runat="server" Value='<%# Bind("EMAIL") %>' />
                                    <asp:HiddenField ID="hdfPassword" runat="server" Value='<%# Bind("PASSWORD") %>' />
                                    <asp:HiddenField ID="hdfFlagActivo" runat="server" Value='<%# Bind("FLAG_ACTIVO") %>' />
                                    <asp:HiddenField ID="hdfEsEmpleado" runat="server" Value='<%# Bind("ES_EMPLEADO") %>' />
                                    <asp:HiddenField ID="hdfFechaNacimiento" runat="server" Value='<%# Bind("FECHA_NACIMIENTO") %>' />
                                    <asp:HiddenField ID="hdfCodSexo" runat="server" Value='<%# Bind("COD_SEXO") %>' />
                                    <asp:HiddenField ID="hdfCodComuna" runat="server" Value='<%# Bind("COD_COMUNA") %>' />
                                    <asp:HiddenField ID="hdfCodNivelEducacional" runat="server" Value='<%# Bind("COD_NIVEL_EDUCACIONAL") %>' />
                                    <asp:HiddenField ID="hdfCodNivelOcupacional" runat="server" Value='<%# Bind("COD_NIVEL_OCUPACIONAL") %>' />
                                    <asp:HiddenField ID="hdfFechaIngreso" runat="server" Value='<%# Bind("FECHA_INGRESO") %>' />
                                    <asp:HiddenField ID="hdfRutEmpresa" runat="server" Value='<%# Bind("RUT_EMPRESA") %>' />
                                    <asp:HiddenField ID="hdfCodGerencia" runat="server" Value='<%# Bind("COD_GERENCIA") %>' />
                                    <asp:HiddenField ID="hdfCodCentroCosto" runat="server" Value='<%# Bind("COD_CENTRO_COSTO") %>' />
                                    <asp:HiddenField ID="hdfCodSucursal" runat="server" Value='<%# Bind("COD_SUCURSAL") %>' />
                                    <asp:HiddenField ID="hdfCodArea" runat="server" Value='<%# Bind("COD_AREA") %>' />
                                    <asp:HiddenField ID="hdfCodUnidad" runat="server" Value='<%# Bind("COD_UNIDAD") %>' />
                                    <asp:HiddenField ID="hdfCodDireccion" runat="server" Value='<%# Bind("COD_DIRECCION") %>' />
                                    <asp:HiddenField ID="hdfCodCargo" runat="server" Value='<%# Bind("COD_CARGO") %>' />
                                    <asp:HiddenField ID="hdfCodRol" runat="server" Value='<%# Bind("COD_ROL") %>' />
                                    <asp:HiddenField ID="hdfCodClasificador1" runat="server" Value='<%# Bind("COD_CLASIFICADOR_1") %>' />
                                    <asp:HiddenField ID="hdfCodClasificador2" runat="server" Value='<%# Bind("COD_CLASIFICADOR_2") %>' />
                                    <asp:HiddenField ID="hdfRutJefe" runat="server" Value='<%# Bind("RUT_JEFE") %>' />
                                    <asp:HiddenField ID="hdfRutVisador" runat="server" Value='<%# Bind("RUT_VISADOR") %>' />
                                    <asp:HiddenField ID="hdfFamiliaCargo" runat="server" Value='<%# Bind("COD_FAMILIA_CARGO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRE_USUARIO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApPaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("APELLIDO_PATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApMaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("APELLIDO_MATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabEmail%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div id="modEditar" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 80% !important;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titAdmUsuarios %>" />
                    </h2>
                </div>
                <div class="modal-body">

                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column double10 text-center">
                            <asp:Image ID="imgAvatar" runat="server" ImageUrl="~/include/usuarios/avatar-usuario-generico.png" Width="180" Height="180" CssClass="AvatarFichaMantenedor" />
                            <br />
                            <div class="cbp-mc-10column triple10 divfileUpload text-center">

                                <%--<div class="btn btn-default btn-file text-center">
                                    <span id="ctl00_ContentPlaceHolder1_Label1">Subir foto</span>
                                    <input type="file" name="ctl00$ContentPlaceHolder1$fulPreguntas" id="ctl00_ContentPlaceHolder1_fulPreguntas" class="upload" placeholder="Foto" />
                                </div>--%>
                                <div class="btn btn-default btn-file">
                                    <asp:Label ID="Label1" runat="server" Text="Subir foto"></asp:Label>
                                    <asp:FileUpload ID="fulFoto" runat="server" CssClass="upload" placeholder="Subir foto" onchange="CargarFoto()" />
                                </div>
                            </div>

                        </div>
                        <div class="cbp-mc-10column octuple10">
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiRut%>" /></label>
                                    <asp:TextBox ID="txtRut" runat="server" MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column cuadruple10">
                                    <label>
                                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="128"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiApPaterno%>" /></label>
                                    <asp:TextBox ID="txtApPaterno" runat="server" MaxLength="128"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiApMaterno%>" /></label>
                                    <asp:TextBox ID="txtApMaterno" runat="server" MaxLength="128"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column triple10">
                                    <label>
                                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiEmail%>" /></label>
                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="128"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column triple10">
                                    <label>
                                        Empresa</label>
                                    <asp:DropDownList ID="ddlEmpresa" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtEmpresa" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                    <label>
                                        Contraseña</label>
                                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                    <label>
                                        Repetir</label>
                                    <asp:TextBox ID="txtRepPassword" runat="server" MaxLength="10" ></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="chk" Text="<%$ Resources: etiquetas,_etiActivo%>" />
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-1column" style="margin-top 5px !important; margin-bottom: 5px !important">
                                    <h2>
                                        <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: titulos,_etiPerfiles%>" />
                                    </h2>
                                </div>
                            </div>

                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column triple10">
                                    <label>
                                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                                    <asp:ListBox ID="lstDisponibles" runat="server" Rows="3"></asp:ListBox>
                                </div>
                                <div class="cbp-mc-10column double10 text-center">
                                    <asp:Button ID="btnIrUno" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUno_Click" />
                                    <asp:Button ID="btnIrTodos" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodos_Click" />
                                    <asp:Button ID="btnVolverUno" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUno_Click" />
                                    <asp:Button ID="btnVolverTodos" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodos_Click" />
                                </div>
                                <div class="cbp-mc-10column triple10">
                                    <label>
                                        <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                                    <asp:ListBox ID="lstAsignados" runat="server" Rows="3"></asp:ListBox>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>


                        </div>
                    </div>


                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column double10">
                            <asp:CheckBox ID="chkEsEmpleado" runat="server" CssClass="chk" Text="Es empleado" AutoPostBack="true" OnCheckedChanged="chkEsEmpleado_CheckedChanged" />
                        </div>
                    </div>
                    <div id="divDatosEmpleado" runat="server">


                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="cbp-mc-10column">
                                <label>
                                    F. Nacimiento</label>
                                <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                            </div>
                            <div class="cbp-mc-10column">
                                <label>
                                    Sexo</label>
                                <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Región</label>
                                <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Comuna</label>
                                <asp:DropDownList ID="ddlComuna" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column">
                                <label>
                                    F. Contrato</label>
                                <asp:TextBox ID="txtFechaContrato" runat="server"></asp:TextBox>
                            </div>
                            <div class="cbp-mc-10column">
                                <label>
                                    Rut Jefe</label>
                                <asp:TextBox ID="txtRutJefe" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="cbp-mc-10column">
                                <label>
                                    Niv. Educ.</label>
                                <asp:DropDownList ID="ddlNivEscolaridad" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column">
                                <label>
                                    Niv. Ocupac.</label>
                                <asp:DropDownList ID="ddlNivOcupacional" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Gerencia</label>
                                <asp:DropDownList ID="ddlGerencia" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column double10">
                                <label>
                                    Sucursal</label>
                                <asp:DropDownList ID="ddlSucursal" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Area</label>
                                <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                            </div>

                        </div>

                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Dirección</label>
                                <asp:DropDownList ID="ddlDireccion" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Unidad</label>
                                <asp:DropDownList ID="ddlUnidad" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column double10">
                                <label>
                                    Centro Costo</label>
                                <asp:DropDownList ID="ddlCentroCosto" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column double10">
                                <label>
                                    Rol</label>
                                <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Tipo cargo</label>
                                <asp:DropDownList ID="ddlFamiliaCargo" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column triple10">
                                <label>
                                    Cargo</label>
                                <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column double10">
                                <label>
                                    Clasificador 1</label>
                                <asp:DropDownList ID="ddlClasif1" runat="server"></asp:DropDownList>
                            </div>
                            <div class="cbp-mc-10column double10">
                                <label>
                                    Clasificador 2</label>
                                <asp:DropDownList ID="ddlClasif2" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                    </div>







                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column text-center">
                            <asp:Button ID="btnVolver" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                            <asp:Button ID="btnGuardar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
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
                        <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                        <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                        <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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

