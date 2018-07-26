<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="mantenedor_cursos.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.mantenedor_cursos" %>

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
                    $('#modEditar').modal('show');
                    break;
                case "2":
                    $('#modal-warning').modal('show');
                    break;
                case "3":
                    $('#modal-success').modal('show');
                    break;
            }
        }
    </script>
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdminCursos%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column quintuple10">
                    <label>
                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label>
                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiAreaCurso%>" /></label>
                    <asp:DropDownList ID="ddlAreaBusqueda" runat="server"></asp:DropDownList>
                </div>
                <div class="cbp-mc-10column triple10">
                    <asp:Button ID="btnConsultar" runat="server" Text="<%$ Resources: etiquetas,_etiConsultar%>" CssClass="cbp-mc-submit" OnClick="btnConsultar_Click" />
                    <asp:Button ID="btnNuevo" runat="server" Text="<%$ Resources: etiquetas,_etiNuevo%>" CssClass="cbp-mc-submit" OnClick="btnNuevo_Click" />
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
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabCodigo%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("CODCURSO") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfProveedor" runat="server" Value='<%# Bind("PROVEEDOR") %>' />
                                    <asp:HiddenField ID="hdfDuracion" runat="server" Value='<%# Bind("DURACION") %>' />
                                    <asp:HiddenField ID="hdfCodModalidad" runat="server" Value='<%# Bind("CODMODALIDAD") %>' />
                                    <asp:HiddenField ID="hdfCodAreaCurso" runat="server" Value='<%# Bind("CODAREACURSO") %>' />
                                    <asp:HiddenField ID="hdfCodigoSence" runat="server" Value='<%# Bind("CODIGOSENCE") %>' />
                                    <asp:HiddenField ID="hdfLugarEjecucion" runat="server" Value='<%# Bind("LUGAREJECUCION") %>' />
                                    <asp:HiddenField ID="hdfCostoParticipante" runat="server" Value='<%# Bind("COSTOPARTICIPANTE") %>' />
                                    <asp:HiddenField ID="hdfMaxParticipantes" runat="server" Value='<%# Bind("MAXPARTICIPANTES") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombreCurso%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRECURSO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabModalidad%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblMadalidad" runat="server" Text='<%# Bind("NOMMODALIDAD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabAreaCurso%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblArea" runat="server" Text='<%# Bind("NOMAREACURSO") %>'></asp:Label>
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
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titAdminCursos %>" />
                    </h2>
                </div>
                <div class="modal-body">

                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column">
                            <label>
                                Código</label>
                            <asp:TextBox ID="txtCodigoCurso" runat="server" MaxLength="16"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column cuadruple10">
                            <label>
                                Nombre Curso</label>
                            <asp:TextBox ID="txtNombreCurso" runat="server" MaxLength="256"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                Area</label>
                            <asp:DropDownList ID="ddlAreaCurso" runat="server" ></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                Modalidad</label>
                            <asp:DropDownList ID="ddlModalidadCurso" runat="server"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-10column">
                            <label>
                                Cod. SENCE</label>
                            <asp:TextBox ID="txtCodigoSence" runat="server" MaxLength="16"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column triple10">
                            <label>
                                Proveedor</label>
                            <asp:TextBox ID="txtProveedorCurso" runat="server" MaxLength="256"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column">
                            <label>
                                Duración</label>
                            <asp:TextBox ID="txtDuracionCurso" runat="server" MaxLength="4" onkeypress="return numbersonly(event);"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column cuadruple10">
                            <label>
                                Lugar de ejecución</label>
                            <asp:TextBox ID="txtLugarEjecucionCurso" runat="server" MaxLength="256"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column">
                            <label>
                                Costo P/P</label>
                            <asp:TextBox ID="txtCostoCurso" runat="server" MaxLength="8" onkeypress="return numbersonly(event);"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column">
                            <label>
                                Max. Partic.</label>
                            <asp:TextBox ID="txtMaxParticCurso" runat="server" MaxLength="4" onkeypress="return numbersonly(event);"></asp:TextBox>
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

