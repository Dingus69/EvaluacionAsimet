<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="instrumento.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.instrumento" %>

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
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentos%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <label>
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiNombreInstrumento%>" /></label>
                    <asp:TextBox ID="txtNombreInstrumento" runat="server" MaxLength="128"></asp:TextBox>
                    <asp:HiddenField ID="hdfCodInstrumento" runat="server" Value="0" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column quintuple10">
                    <label>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionInstrumento%>" /></label>
                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="4000" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column quintuple10">
                    <label>
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiObservacionInstrumento%>" /></label>
                    <asp:TextBox ID="txtObservacion" runat="server" MaxLength="4000" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiEscala%>" /></label>
                    <asp:DropDownList ID="ddlEscalas" runat="server"></asp:DropDownList>
                </div>
                <div class="cbp-mc-10column" visible="false" style="display: none;">
                    <label>
                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiGrado%>" /></label>
                    <asp:DropDownList ID="ddlGrados" runat="server"></asp:DropDownList>
                </div>
                <div class="cbp-mc-10column octuple10">
                    <asp:CheckBox ID="chkAutoevaluacion" Text="<%$ Resources: etiquetas,_etiAutoevaluacion%>" runat="server" CssClass="chk" />
                    <asp:CheckBox ID="chkApelacion" Text="<%$ Resources: etiquetas,_etiApelacion%>" runat="server" CssClass="chk" />
                    <asp:CheckBox ID="chkVisacion" Text="<%$ Resources: etiquetas,_etiVisacion%>" runat="server" CssClass="chk" />
                    <asp:CheckBox ID="chkConCalibracion" Text="<%$ Resources: etiquetas,_etiConObservaciones%>" runat="server" CssClass="chk" />
                    <asp:CheckBox ID="chkObjetivos" Text="<%$ Resources: etiquetas,_etiConObservaciones%>" runat="server" CssClass="chk" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal25" runat="server" Text="<%$ Resources: titulos,_titPonderaciones%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources: etiquetas,_etiPondEutoEvaluacion%>" /></label>
                    <asp:TextBox ID="txtPondAutoEvaluacion" runat="server"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources: etiquetas,_etiPondJefaturas%>" /></label>
                    <asp:TextBox ID="txtPondJefatura" runat="server"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal28" runat="server" Text="<%$ Resources: etiquetas,_etiPondColaboradores%>" /></label>
                    <asp:TextBox ID="txtPondColaboradores" runat="server"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal34" runat="server" Text="<%$ Resources: etiquetas,_etiPondPares%>" /></label>
                    <asp:TextBox ID="txtPondPares" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2>
                        <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentosSecciones%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column triple10">
                    <label></label>
                    <asp:Button ID="btnAgregarSeccion" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiAgregarSeccion%>" OnClick="btnAgregarSeccion_Click" />
                </div>
                <div class="cbp-mc-10column triple10 divfileUpload">
                    <%--<label>
                        <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiSeccionesXLSTitulo%>" /></label>--%>
                    <div class="btn btn-default btn-file">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources: etiquetas,_etiSeccionesXLSFUL%>"></asp:Label>
                        <asp:FileUpload ID="fulPreguntas" runat="server" CssClass="upload" placeholder="<%$ Resources: etiquetas,_etiSeccionesXLSFUL%>" />
                    </div>
                    <asp:HyperLink ID="hplDescargarFormato" runat="server" data-toggle="tooltip" NavigateUrl="~/include/plantillas/formato_carga_secciones.xls" Target="_blank" title="<%$ Resources: etiquetas,_etiDescargarFormato%>"><span class="glyphicon glyphicon-download-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:HyperLink>
                </div>
                <div class="cbp-mc-10column triple10">
                    <label></label>
                    <asp:Button ID="btnCargarSecciones" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCargar%>" OnClick="btnCargarSecciones_Click" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper_0 cbp-mc-1column">
                    <asp:GridView ID="grdSecciones" runat="server" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="grdSecciones_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                        <div class="cbp-mc-1column triple10">
                                            <label>
                                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiNombreSeccion%>" /></label>
                                            <asp:TextBox ID="txtNombreSeccion" runat="server" MaxLength="256" Text='<%# Bind("NOMBRE") %>'></asp:TextBox>
                                        </div>
                                        <div class="cbp-mc-10column double10">
                                            <label>
                                                <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiTipoSeccion%>" /></label>
                                            <asp:DropDownList ID="ddlTipoSeccion" runat="server"></asp:DropDownList>
                                            <asp:HiddenField ID="hdfCodSeccion" runat="server" Value='<%# Bind("CODSECCION") %>' />
                                            <asp:HiddenField ID="hdfCodInstrumento" runat="server" Value='<%# Bind("CODINSTRUMENTO") %>' />
                                            <asp:HiddenField ID="hdfCodTipoSeccion" runat="server" Value='<%# Bind("CODTIPOSECCION") %>' />
                                        </div>
                                        <div class="cbp-mc-10column">
                                            <label>
                                                <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: etiquetas,_etiOrdenSeccion%>" /></label>
                                            <asp:TextBox ID="txtOrden" runat="server" MaxLength="2" Text='<%# Bind("ORDEN") %>' onkeypress="return numbersonly(event);"></asp:TextBox>
                                        </div>
                                        <div class="cbp-mc-10column">
                                            <label>
                                                <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiPonderacionSeccion%>" /></label>
                                            <asp:TextBox ID="txtPonderacion" runat="server" MaxLength="3" Text='<%# Bind("PONDERACION") %>' onkeypress="return numbersonly(event);"></asp:TextBox>
                                        </div>
                                        <div class="cbp-mc-10column triple10">
                                            <asp:CheckBox ID="chkNuevasPreguntas" Text="<%$ Resources: etiquetas,_etiPermitirNuevasPreguntas%>" runat="server" CssClass="chk" />
                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                        <div class="cbp-mc-1column">
                                            <label>
                                                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionSeccion%>" /></label>
                                            <asp:TextBox ID="txtDescripcionSeccion" runat="server" MaxLength="4000" TextMode="MultiLine" Text='<%# Bind("DESCRIPCION") %>'></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                        <div class="cbp-mc-1column">
                                            <h2>
                                                <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentosSeccionPreguntas%>" />
                                                <asp:Label ID="Label2" runat="server" Text=" - "></asp:Label>
                                                <asp:LinkButton ID="lnkAgregarPregunta" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarPregunta%>" OnClick="lnkAgregarPregunta_Click"></asp:LinkButton>
                                            </h2>
                                        </div>
                                    </div>
                                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                        <div class="table-wrapper_0 cbp-mc-1column">
                                            <asp:GridView ID="grdPreguntas" runat="server" ShowHeader="false" AutoGenerateColumns="false" CssClass="GridAnidado" DataSource='<%# Bind("PREGUNTAS") %>'>
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                <div class="cbp-mc-10column octuple10">
                                                                    <label>
                                                                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiTextoPregunta%>" /></label>
                                                                    <asp:TextBox ID="txtPregunta" runat="server" MaxLength="4000" Text='<%# Bind("TEXTO") %>'></asp:TextBox>
                                                                    <asp:HiddenField ID="hdfCodPregunta" runat="server" Value='<%# Bind("CODPREGUNTA") %>' />
                                                                    <asp:HiddenField ID="hdfDescripcion" runat="server" Value='<%# Bind("DESCRIPCION") %>' />
                                                                    <asp:HiddenField ID="hdfAccion" runat="server" Value='<%# Bind("ACCION") %>' />
                                                                    <asp:HiddenField ID="hdfCompromiso" runat="server" Value='<%# Bind("COMPROMISO") %>' />
                                                                    <asp:HiddenField ID="hdfIndicador" runat="server" Value='<%# Bind("INDICADOR") %>' />
                                                                </div>
                                                                <div class="cbp-mc-10column">
                                                                    <label>
                                                                        <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiPonderacionSeccion%>" /></label>
                                                                    <asp:TextBox ID="txtPonderacionPregunta" runat="server" MaxLength="3" Text='<%# Bind("PONDERACION") %>' onkeypress="return numbersonly(event);"></asp:TextBox>
                                                                </div>
                                                                <div class="cbp-mc-10column imgBotton">
                                                                    <label></label>
                                                                    <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/include/images/css/EDITAR.png" Width="30" Height="30" OnClick="imgEditar_Click" />
                                                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/include/images/css/ELIMINAR.png" Width="30" Height="30" OnClick="imgEliminar_Click" />
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
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal35" runat="server" Text="<%$ Resources: titulos,_titCursos%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal36" runat="server" Text="<%$ Resources: titulos,_titAreaMejoraContinua%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea1" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea1" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea1_Click" />
                    <asp:Button ID="btnIrTodosArea1" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea1_Click" />
                    <asp:Button ID="btnVolverUnoArea1" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea1_Click" />
                    <asp:Button ID="btnVolverTodosArea1" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea1_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea1" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal37" runat="server" Text="<%$ Resources: titulos,_titAreaHabilidadesBlandas%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal45" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea2" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea2" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea2_Click" />
                    <asp:Button ID="btnIrTodosArea2" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea2_Click" />
                    <asp:Button ID="btnVolverUnoArea2" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea2_Click" />
                    <asp:Button ID="btnVolverTodosArea2" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea2_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal46" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea2" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal38" runat="server" Text="<%$ Resources: titulos,_titAreaComerciales%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal47" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea3" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea3" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea3_Click" />
                    <asp:Button ID="btnIrTodosArea3" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea3_Click" />
                    <asp:Button ID="btnVolverUnoArea3" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea3_Click" />
                    <asp:Button ID="btnVolverTodosArea3" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea3_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal48" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea3" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal39" runat="server" Text="<%$ Resources: titulos,_titAreaRelativasProduccion%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal49" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea4" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea4" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea4_Click" />
                    <asp:Button ID="btnIrTodosArea4" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea4_Click" />
                    <asp:Button ID="btnVolverUnoArea4" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea4_Click" />
                    <asp:Button ID="btnVolverTodosArea4" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea4_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal50" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea4" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal40" runat="server" Text="<%$ Resources: titulos,_titAreaAdministrativas%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal51" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea5" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea5" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea5_Click" />
                    <asp:Button ID="btnIrTodosArea5" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea5_Click" />
                    <asp:Button ID="btnVolverUnoArea5" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea5_Click" />
                    <asp:Button ID="btnVolverTodosArea5" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea5_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal52" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea5" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal41" runat="server" Text="<%$ Resources: titulos,_titAreaTiOfimatica%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal53" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea6" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea6" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea6_Click" />
                    <asp:Button ID="btnIrTodosArea6" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea6_Click" />
                    <asp:Button ID="btnVolverUnoArea6" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea6_Click" />
                    <asp:Button ID="btnVolverTodosArea6" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea6_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal54" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea6" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal42" runat="server" Text="<%$ Resources: titulos,_titAreaIdiomas%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal55" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea7" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea7" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea7_Click" />
                    <asp:Button ID="btnIrTodosArea7" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea7_Click" />
                    <asp:Button ID="btnVolverUnoArea7" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea7_Click" />
                    <asp:Button ID="btnVolverTodosArea7" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea7_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal56" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea7" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal43" runat="server" Text="<%$ Resources: titulos,_titAreaSeguridad%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal57" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea8" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea8" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea8_Click" />
                    <asp:Button ID="btnIrTodosArea8" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea8_Click" />
                    <asp:Button ID="btnVolverUnoArea8" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea8_Click" />
                    <asp:Button ID="btnVolverTodosArea8" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea8_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal58" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea8" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>

            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h2 class="text-left">
                        <asp:Literal ID="Literal44" runat="server" Text="<%$ Resources: titulos,_titAreaOtrasCapacitaciones%>" />
                    </h2>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;"> 
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal59" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                    <asp:ListBox ID="lstCurDispArea9" runat="server" Rows="4"></asp:ListBox>
                </div>
                <div class="cbp-mc-10column double10 text-center">
                    <asp:Button ID="btnIrUnoArea9" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUnoArea9_Click" />
                    <asp:Button ID="btnIrTodosArea9" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodosArea9_Click" />
                    <asp:Button ID="btnVolverUnoArea9" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUnoArea9_Click" />
                    <asp:Button ID="btnVolverTodosArea9" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodosArea9_Click" />
                </div>
                <div class="cbp-mc-10column cuadruple10">
                    <label>
                        <asp:Literal ID="Literal60" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                    <asp:ListBox ID="lstCurAsigArea9" runat="server" Rows="4"></asp:ListBox>
                </div> 
            </div>


            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
                </div>
            </div>

        </div>
    </div>


    <div id="modEditarPregunta" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titMantPregunta %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiTextoPregunta%>" /></label>
                            <asp:TextBox ID="txtPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionPregunta%>" /></label>
                            <asp:TextBox ID="txtDescripPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiAccionPregunta%>" /></label>
                            <asp:TextBox ID="txtAccionPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: etiquetas,_etiCompromisoPregunta%>" /></label>
                            <asp:TextBox ID="txtCompromisoPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources: etiquetas,_etiIndicadorPregunta%>" /></label>
                            <asp:TextBox ID="txtIndicadorPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnGuardarPregunta" runat="server" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardarPregunta_Click" />
                            <asp:Button ID="btnCerrarPregunta" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
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
                        <asp:Literal ID="Literal30" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" /></p>
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
                        <asp:Literal ID="Literal33" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                        <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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

