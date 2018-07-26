<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="editar_evaluacion.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.evaluacion.editar_evaluacion" %>

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
                    $('#modEditarPregunta').modal('show');
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
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titEditarEvaluacion%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" visible="false">
                <div class="cbp-mc-1column">
                    <h2>
                        <asp:Label ID="lblNombreFormulario" runat="server" Text="Label"></asp:Label></h2>

                </div>
            </div>
            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" visible="false">
                <div class="cbp-mc-10column">                    
                    <label><asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiRut%>" /></label>
                    <asp:TextBox ID="txtRut" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">                    
                    <label><asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">                    
                    <label><asp:Literal ID="Literal25" runat="server" Text="<%$ Resources: etiquetas,_etiGerencia%>" /></label>
                    <asp:TextBox ID="txtGerencia" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">                    
                    <label><asp:Literal ID="Literal23" runat="server" Text="<%$ Resources: etiquetas,_etiCargo%>" /></label>
                    <asp:TextBox ID="txtCargo" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10" id="divRelacion" runat="server">                    
                    <label><asp:Literal ID="Literal24" runat="server" Text="<%$ Resources: etiquetas,_etiRelacion%>" /></label>
                    <asp:TextBox ID="txtRelacion" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column">                    
                    <label><asp:Literal ID="Literal26" runat="server" Text="<%$ Resources: etiquetas,_etiResultado%>" /></label>
                    <asp:TextBox ID="txtResultado" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" visible="false">
                <div class="cbp-mc-10column quintuple10">
                    <h2>
                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcion%>"></asp:Label></h2>
                    <asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="cbp-mc-10column quintuple10">
                    <h2>
                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources: etiquetas,_etiObservacion%>"></asp:Label></h2>
                    <asp:Label ID="lblObservacion" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2>
                        <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentosSecciones%>" />
                    </h2>
                </div>
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdSecciones" runat="server" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="grdSecciones_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                        <div class="cbp-mc-10column nonuple10">
                                            <div>
                                                <asp:Label ID="lblNombreSeccion" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdfPreguntasNuevas" runat="server" Value='<%# Bind("FLAG_AGREGAR_PREGUNTAS") %>' />
                                            <asp:HiddenField ID="hdfCodSeccion" runat="server" Value='<%# Bind("CODSECCIONINSTRUMENTO") %>' />
                                        </div>
                                        <div class="cbp-mc-10column">
                                            <div style="text-align: center;">
                                                <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiPonderacionSeccion%>" />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                        <div class="cbp-mc-10column nonuple10">
                                            <div>
                                                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionSeccion%>" />
                                            </div>
                                            <div>
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("DESCRIPCION") %>' /></div>
                                        </div>
                                        <div class="cbp-mc-10column">
                                            <div class="ponderacion">
                                                <asp:Label ID="lblPonderacionSeccion" runat="server" Text='<%# Bind("PONDERACION") %>'></asp:Label>%
                                            </div>
                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" id="divAgregarPregunta" runat="server" visible="false">
                                        <div class="cbp-mc-1column">
                                            <h2>
                                                <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentosSeccionPreguntas%>" />
                                                <asp:Label ID="Label2" runat="server" Text=" - "></asp:Label>
                                                <asp:LinkButton ID="lnkAgregarPregunta" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarPregunta%>" OnClick="lnkAgregarPregunta_Click"></asp:LinkButton>
                                            </h2>
                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                        <div class="table-wrapper cbp-mc-1column">
                                            <asp:GridView ID="grdPreguntas" runat="server" AutoGenerateColumns="false" CssClass="GridAnidado" DataSource='<%# Bind("PREGUNTAS") %>'>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabPregunta%>" HeaderStyle-Width="80%">
                                                        <ItemTemplate>
                                                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                <div class="cbp-mc-1column">
                                                                    <asp:Label ID="lblPregunta" runat="server" Text='<%# Bind("TEXTO") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hdfCodPregunta" runat="server" Value='<%# Bind("CODPREGUNTAEMPLEADO") %>' />
                                                                    <asp:HiddenField ID="hdfDescripcion" runat="server" Value='<%# Bind("DESCRIPCION") %>' />
                                                                    <asp:HiddenField ID="hdfAccion" runat="server" Value='<%# Bind("ACCION") %>' />
                                                                    <asp:HiddenField ID="hdfCompromiso" runat="server" Value='<%# Bind("COMPROMISO") %>' />
                                                                    <asp:HiddenField ID="hdfIndicador" runat="server" Value='<%# Bind("INDICADOR") %>' />
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabVer%>" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                <div class="cbp-mc-1column imgBotton">
                                                                    <asp:ImageButton ID="imgVerDetalles" runat="server" ImageUrl="~/include/images/css/EDITAR.png" Width="30" Height="30" OnClick="imgVerDetalles_Click" />
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabPonderacion%>" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                <div class="cbp-mc-1column">
                                                                    <asp:TextBox ID="txtPonderacionPregunta" runat="server" onkeypress="return numbersonly(event);" Text='<%# Bind("PONDERACION") %>'></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column quintuple10 text-left">
                    <asp:Button ID="btnVolver" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                </div>
                <div class="cbp-mc-10column quintuple10 text-right">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
                </div>
            </div>

        </div>
    </div>


    <div id="modEditarPregunta" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titVerDetalles %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiTextoPregunta%>" /></label>
                            <asp:TextBox ID="txtPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            <asp:HiddenField ID="hdfCodSeccion" runat="server" />
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionPregunta%>" /></label>
                            <asp:TextBox ID="txtDescripPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiAccionPregunta%>" /></label>
                            <asp:TextBox ID="txtAccionPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: etiquetas,_etiCompromisoPregunta%>" /></label>
                            <asp:TextBox ID="txtCompromisoPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources: etiquetas,_etiIndicadorPregunta%>" /></label>
                            <asp:TextBox ID="txtIndicadorPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnCerrarPregunta" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                            <asp:Button ID="btnGuardarPregunta" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardarPregunta_Click" />
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
                    <h4 class="modal-title"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                    <asp:Button ID="btnContinuar" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuar_Click" />
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
                    <h4 class="modal-title"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                    <h4 class="modal-title"><asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" /> 
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

</asp:Content>
