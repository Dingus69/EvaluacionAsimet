<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="mantenedor_escala.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.mantenedor_escala" %>

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
                    $('#modEditar').modal('show');
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
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdmEscala%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="imgEditar" ImageUrl="~/include/images/css/EDITAR.png" runat="server" OnClick="imgEditar_Click" />
                                    <asp:ImageButton ID="imgEliminar" ImageUrl="~/include/images/css/ELIMINAR.png" runat="server" OnClick="imgEliminar_Click" />--%>
                                    <asp:LinkButton ID="lnkEditar" runat="server" data-toggle="tooltip" OnClick="lnkEditar_Click" title="<%$ Resources: etiquetas,_etiEditar%>"><span class="glyphicon glyphicon-edit" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnkEliminar" runat="server" data-toggle="tooltip" OnClick="lnkEliminar_Click" title="<%$ Resources: etiquetas,_etiEliminar%>"><span class="glyphicon glyphicon-remove" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabCodigo%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("CODESCALA") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfValorMenor" runat="server" Value='<%# Bind("VALORMENOR") %>' />
                                    <asp:HiddenField ID="hdfValorMayor" runat="server" Value='<%# Bind("VALORMAYOR") %>' />
                                    <asp:HiddenField ID="hdfInstrucciones" runat="server" Value='<%# Bind("INSTRUCCIONES") %>' />
                                    <asp:HiddenField ID="hdfFlagRangos" runat="server" Value='<%# Bind("FLAG_RANGOS") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMESCALA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column octuple10">
                </div>
                <div class="cbp-mc-10column text-right">
                    <asp:Button ID="btnConsultar" runat="server" Text="<%$ Resources: etiquetas,_etiConsultar%>" CssClass="btn btn-primary" OnClick="btnConsultar_Click" />
                </div>
                <div class="cbp-mc-10column text-right">
                    <asp:Button ID="btnNuevo" runat="server" Text="<%$ Resources: etiquetas,_etiNuevo%>" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
                </div>
            </div>
        </div>
    </div>

    <div id="modEditar" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titAdmEscala %>" />
                    </h2>
                </div>
                <div class="modal-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiCodigo%>" /></label>
                                    <asp:TextBox ID="txtCodEscala" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="128"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiValorMenor%>" /></label>
                                    <asp:TextBox ID="txtValorMenor" runat="server" MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiValorMayor%>" /></label>
                                    <asp:TextBox ID="txtValorMayor" runat="server" MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column octuple10">
                                    <label>
                                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiInstrucciones%>" /></label>
                                    <asp:TextBox ID="txtInstruncciones" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>

                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column octuple10">
                                    <h4>
                                        <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiRangos%>" />
                                    </h4>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column octuple10">
                                    <asp:RadioButton ID="rbEvaluacionAbierta" Text="Evaluación abierta" runat="server" CssClass="chk_sl" GroupName="grRango" OnCheckedChanged="rbEvaluacionAbierta_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="rbPorRangos" Text="Evaluación por rangos" runat="server" CssClass="chk_sl" GroupName="grRango" OnCheckedChanged="rbPorRangos_CheckedChanged" AutoPostBack="true" />
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div id="divRangos" runat="server" visible="false">
                                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                    <div class="cbp-mc-10column">
                                    </div>
                                    <div class="cbp-mc-10column double10">
                                        <label>
                                            <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                                        <asp:TextBox ID="txtNombreRango" runat="server" Text="" MaxLength="128"></asp:TextBox>
                                    </div>
                                    <div class="cbp-mc-10column double10">
                                        <label>
                                            <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcion%>" /></label>
                                        <asp:TextBox ID="txtDetalleRango" runat="server" Text="" MaxLength="256"></asp:TextBox>
                                    </div>
                                    <div class="cbp-mc-10column double10">
                                        <label>
                                            <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources: etiquetas,_etiValorRango%>" /></label>
                                        <asp:TextBox ID="txtValorRango" runat="server" Text="" MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                    </div>
                                    <div class="cbp-mc-10column">
                                        <asp:Button ID="btnAgregarRango" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAgregarPregunta%>" OnClick="btnAgregarRango_Click" />
                                    </div>
                                    <div class="cbp-mc-10column">
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                    <div class="cbp-mc-10column">
                                    </div>
                                    <div class="table-wrapper cbp-mc-10column octuple10">
                                        <asp:GridView ID="grdRangos" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEliminarRango" runat="server" data-toggle="tooltip" OnClick="lnkEliminarRango_Click" title="<%$ Resources: etiquetas,_etiEliminar%>"><span class="glyphicon glyphicon-remove" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                                    <ItemTemplate>
                                                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                            <div class="cbp-mc-1column">
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NOMBRERANGO") %>' MaxLength="128"></asp:TextBox>
                                                                <asp:HiddenField ID="hdfCodRango" runat="server" Value='<%# Bind("CODRANGO") %>' />
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabDescripcion%>">
                                                    <ItemTemplate>
                                                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                            <div class="cbp-mc-1column">
                                                                <asp:TextBox ID="txtDescripcionRango" runat="server" Text='<%# Bind("DESCRIPCIONRANGO") %>' MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabValor%>">
                                                    <ItemTemplate>
                                                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                            <div class="cbp-mc-1column">
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("VALORRANGO") %>' MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="cbp-mc-10column">
                                    </div>
                                </div>
                            </div>



                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column octuple10">
                                    <h4>
                                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiCategorias%>" />
                                    </h4>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column triple10">
                                    <label>
                                        <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                                    <asp:TextBox ID="txtNombreCategoria" runat="server" Text="" MaxLength="128"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiValorMenor%>" /></label>
                                    <asp:TextBox ID="txtValorMenorCategoria" runat="server" Text="" MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column double10">
                                    <label>
                                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiValorMayor%>" /></label>
                                    <asp:TextBox ID="txtValorMayorCategoria" runat="server" Text="" MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column">
                                    <asp:Button ID="btnAgregarCategoria" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAgregarPregunta%>" OnClick="btnAgregarCategoria_Click" />
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="table-wrapper cbp-mc-10column octuple10">
                                    <asp:GridView ID="grdCategorias" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminarCategoria" runat="server" data-toggle="tooltip" OnClick="lnkEliminarCategoria_Click" title="<%$ Resources: etiquetas,_etiEliminar%>"><span class="glyphicon glyphicon-remove" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                                <ItemTemplate>
                                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                        <div class="cbp-mc-1column">
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NOMBRECATEGORIA") %>' MaxLength="128"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabValorMenor%>">
                                                <ItemTemplate>
                                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                        <div class="cbp-mc-1column">
                                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("VALORMENOR") %>' MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabValorMayor%>">
                                                <ItemTemplate>
                                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                                        <div class="cbp-mc-1column">
                                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("VALORMAYOR") %>' MaxLength="3" onkeypress="return numbersonly(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="cbp-mc-10column">
                                </div>
                                <div class="cbp-mc-10column octuple10 text-center">
                                    <asp:Button ID="btnCerrar" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" OnClick="btnCerrar_Click" />
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
                                </div>
                                <div class="cbp-mc-10column">
                                </div>
                            </div>
                        </ContentTemplate>
                         <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                         </Triggers>
                    </asp:UpdatePanel>
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
                        <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                        <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                        <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litErrorDatosRelacionados" runat="server" Text="<%$ Resources: etiquetas,_etiErrorDatosRelacionados%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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





