<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="evaluacion.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.evaluacion.evaluacion" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://use.fontawesome.com/b2e020ee86.js"></script>
    <link rel="stylesheet" href="../../include/font-awesome/css/font-awesome.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/include/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function CheckAcuerdo() {
            document.getElementById("checkAcuerdo").removeAttribute("class");
            document.getElementById("checkAcuerdo").className = "checkAcuerdoCheck";
        }
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
            /*__doPostBack("CalculaNota", "");*/
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
                case "5":
                    $('#modAgregarComentario').modal('show');
                    break;
                case "6":
                    $('#modVisarEvaluacion').modal('show');
                    break;
                case "7":
                    $('#modApelar').modal('show');
                    break;
                case "8":
                    $('#modAgregarComentarioEvaluacion').modal('show');
                    break;
                case "9":
                    $('#modVerBitacora').modal('show');
                    break;
                case "10":
                    $('#modNotificacion').modal('show');
                    break;
                case "11":
                    $('#modTomarConocimiento').modal('show');
                    break;
                case "12":
                    $('#modFicha').modal('show');
                    break;
                case "13":
                    $('#modInformeEvaluacion').modal('show');
                    break;
            }
        }

        $(document).ready(function () {
            if ($(window).scrollTop() > 250) {
                $("#column-left").addClass("fix");
            } else {
                $("#column-left").removeClass("fix");
            }
        });

        $(function () {
            $(window).scroll(function () {
                if ($(window).scrollTop() > 250) {
                    //$("#column-left").fadeIn();//.fadeOut();
                    $("#column-left").addClass("fix");
                } else {
                    //$("#column-left").fadeOut();//.fadeIn();
                    $("#column-left").removeClass("fix");
                }
            });
        });
    </script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#containerFicha').highcharts({
                chart: { type: 'line' },
                title: { text: '<%= hdfNombreFormulario.Value%>' },
                xAxis: { categories: [ <%= hdfResumenTextoGraf01.Value%>], crosshair: true },
                yAxis: { title: { text: 'Resultado' } },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                plotOptions: { series: { borderWidth: 0, dataLabels: { enabled: true, format: '{point.y:.0f}' } } },
                tooltip: { headerFormat: '<span style="font-size:11px">{series.name}</span><br>', pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>' },

                series: [{
                    name: 'Jefatura',
                    data: [<%= hdfResumenJefatGraf01.Value%>]
                }, {
                    name: 'Colaboradores',
                    data: [<%= hdfResumenColabGraf01.Value%>]
                }, {
                    name: 'Pares',
                    data: [<%= hdfResumenParesGraf01.Value%>]
                }, {
                    name: 'Auto evaluación',
                    data: [<%= hdfResumenAutoevGraf01.Value%>]
                }],
            });
        });

        $(function () {
            $('#containerFichaPares').highcharts({
                chart: { type: 'line' },
                title: { text: '<%= hdfNombreFormulario.Value%> - Colaboradores' },
                xAxis: { categories: [<%= hdfResumenTextoGraf02.Value%>], crosshair: true },
                yAxis: { title: { text: 'Resultado' } },
                legend: { enabled: false },
                plotOptions: { series: { borderWidth: 0, dataLabels: { enabled: true, format: '{point.y:.0f}' } } },
                tooltip: { headerFormat: '<span style="font-size:11px">{series.name}</span><br>', pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>' },

                series: [<%= hdfResumenDataGraf02.Value%>],
            });
        });

        $(function () {
            $('#containerFichaColaboradores').highcharts({
                chart: { type: 'line' },
                title: { text: '<%= hdfNombreFormulario.Value%> - Pares' },
                xAxis: { categories: [<%= hdfResumenTextoGraf03.Value%>], crosshair: true },
                yAxis: { title: { text: 'Resultado' } },
                legend: { enabled: false },
                plotOptions: { series: { borderWidth: 0, dataLabels: { enabled: true, format: '{point.y:.0f}' } } },
                tooltip: { headerFormat: '<span style="font-size:11px">{series.name}</span><br>', pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>' },

                series: [<%= hdfResumenDataGraf03.Value%>],
            });
        });
    </script>




    <style type="text/css">
        .bs-example {
            margin: 20px;
        }

        .panel-title .glyphicon {
            font-size: 14px;
        }
    </style>
    <script>
        $(document).ready(function () {
            // Add minus icon for collapse element which is open by default
            $(".collapse.in").each(function () {
                $(this).siblings(".panel-heading").find(".glyphicon").addClass("glyphicon-minus").removeClass("glyphicon-plus");
            });

            // Toggle plus minus icon on show hide of collapse element
            $(".collapse").on('show.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hide.bs.collapse', function () {
                $(this).parent().find(".glyphicon").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        });
    </script>



    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnVerFicha" />
        </Triggers>
        <ContentTemplate>
            <div class="container" style="max-width: 1024px">
                <script src="<%= Page.ResolveUrl("~/include/chart/js/highcharts.js")%>"></script>
                <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/data.js")%>"></script>
                <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/drilldown.js")%>"></script>
                <div class="main" style="width: 100% !important;">

                    <section id="secCabecera">
                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" visible="false">
                            <div class="cbp-mc-1column">
                                <h2>
                                    <asp:Label ID="lblNombreFormulario" runat="server" Text="Label"></asp:Label>
                                    <asp:HiddenField ID="hdfNombreFormulario" runat="server" />
                                </h2>
                            </div>
                        </div>

                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" visible="false">
                            <table class="TableEvaluacionesInterna">
                                <tbody>
                                    <tr>
                                        <td class="tdAvatar">
                                            <asp:Image ID="imgAvatar" runat="server" Width="70" Height="70" ImageUrl="~/include/avatars/avatar-usuario-generico.png"></asp:Image>
                                        </td>
                                        <td class="tdDatos1">
                                            <span class="Dato DatoResaltado">Nombre</span>: 
                                	    <asp:Label ID="txtNombreUsuario" runat="server" Text="" CssClass="DatoResaltado"></asp:Label>
                                            <br>
                                            <span class="Dato">Rut</span>: 
                                	    <asp:Label ID="txtRut" runat="server" Text="Label"></asp:Label>
                                            <br>
                                            <span class="Dato">Gerencia</span>:
                                	    <asp:Label ID="txtGerencia" runat="server" Text="Label"></asp:Label>
                                            <br>
                                            <span class="Dato">Cargo</span>:
                                	    <asp:Label ID="txtCargo" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="tdDatos2">
                                            <span class="Dato">Relacion</span>:
                                	<asp:Label ID="txtRelacion" runat="server" Text="Label"></asp:Label>
                                            <br>
                                            <span class="Dato">Inicio</span>:
                                        <span id="ctl00_ContentPlaceHolder1_repEvaluaciones_ctl00_Label13">21/11/2017</span>
                                            <br>
                                            <span class="Dato">Fin</span>:
                                        <span id="ctl00_ContentPlaceHolder1_repEvaluaciones_ctl00_Label15">31/12/2017</span>
                                        </td>
                                        <td class="tdResultado">
                                            <div class="cbp-mc-10column">
                                                <label style="display: none;">
                                                    Resultado</label>
                                                <asp:Label ID="txtResultado" runat="server" Text="" Visible="false"></asp:Label>
                                                <div id="column-left_" class="column-left">
                                                    <span>Resultado</span>
                                                    <p>
                                                        <asp:Literal ID="litNotaCalculada" runat="server"></asp:Literal>
                                                    </p>
                                                </div>
                                                <%--</div>--%>
                                        </td>
                                        <td class="tdAcciones">
                                            <asp:Button ID="btnVerFicha" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiVerFicha%>" OnClick="btnVerFicha_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" id="divDescripcionObservacion" runat="server" visible="false">
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
                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" id="divInstrucciones" runat="server" visible="false">
                            <div class="cbp-mc-1column">
                                <h2>
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources: etiquetas,_etiInstrucciones%>"></asp:Label></h2>
                                <asp:Label ID="lblInstrucciones" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </section>

                </div>

                <div class="panel-group" id="accordion">
                    <div class="panel panel-default" id="pnlObjetivosActuales" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" id="lnkPnlOne" runat="server" data-parent="#accordion" href="#collapseOne"><span id="iconoPnlOne" runat="server" class="glyphicon glyphicon-plus"></span>
                                    <asp:Literal ID="Literal57" runat="server" Text="<%$ Resources: titulos,_titObjetivosActuales%>" /></a>
                            </h4>
                        </div>
                        <div id="collapseOne" runat="server" class="panel-collapse collapse in">
                            <div class="panel-body">
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="pnlFormularioEvaluacion" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" id="lnkPnlTwo" runat="server" data-parent="#accordion" href="#collapseTwo"><span id="iconoPnlTwo" runat="server" class="glyphicon glyphicon-plus"></span>
                                    <asp:Literal ID="Literal58" runat="server" Text="<%$ Resources: titulos,_titFormularioEvaluacion%>" /></a>
                            </h4>
                        </div>
                        <div id="collapseTwo" runat="server" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-1column">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Validar" DisplayMode="List" />
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="table-wrapper_0 cbp-mc-1column">
                                        <asp:GridView ID="grdSecciones" runat="server" ShowHeader="false" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                            <div class="cbp-mc-10column octuple10">
                                                                <div>
                                                                    <asp:Label ID="lblNombreSeccion" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                                                </div>
                                                                <asp:HiddenField ID="hdfPreguntasNuevas" runat="server" />
                                                                <asp:HiddenField ID="hdfCodSeccion" runat="server" Value='<%# Bind("CODSECCIONINSTRUMENTO") %>' />
                                                            </div>
                                                            <div class="cbp-mc-10column double10">
                                                                <div style="text-align: center;">
                                                                    <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiResultado%>" />
                                                                    <asp:Label ID="lblResultadoSeccion" runat="server" Text='0'></asp:Label>%
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" id="divDescripcionSeccion" runat="server" visible="false">
                                                            <div class="cbp-mc-10column nonuple10">
                                                                <div>
                                                                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionSeccion%>" />
                                                                </div>
                                                                <div>
                                                                    <asp:Literal ID="litDescripcionSeccion" runat="server" Text='<%# Bind("DESCRIPCION") %>' />
                                                                </div>
                                                            </div>
                                                            <div class="cbp-mc-10column">
                                                                <div class="ponderacion">
                                                                    <asp:Label ID="lblPonderacionSeccion" runat="server" Text='<%# Bind("PONDERACION") %>' Visible="false"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;" id="divAgregarPregunta" runat="server" visible="false">
                                                            <div class="cbp-mc-1column">
                                                                <h2>
                                                                    <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: titulos,_titAdmInstrumentosSeccionPreguntas%>" />
                                                                </h2>
                                                            </div>
                                                        </div>
                                                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                            <div class="table-wrapper_0 cbp-mc-1column">
                                                                <asp:GridView ID="grdPreguntas" runat="server" AutoGenerateColumns="false" CssClass="GridAnidado" DataSource='<%# Bind("PREGUNTAS") %>'>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabPregunta%>" HeaderStyle-Width="80%" >
                                                                            <ItemTemplate>
                                                                                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column">--%>
                                                                                <asp:LinkButton ID="lnkVerDetalles" runat="server" data-toggle="tooltip" OnClick="lnkVerDetalles_Click" title="<%$ Resources: etiquetas,_etiVerDetalle%>" Visible="false"><span class="glyphicon glyphicon-eye-open" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                                                <asp:Label ID="lblPregunta" runat="server" Text='<%# Bind("TEXTO") %>'></asp:Label>
                                                                                <asp:HiddenField ID="hdfCodPregunta" runat="server" Value='<%# Bind("CODPREGUNTAEMPLEADO") %>' />
                                                                                <asp:HiddenField ID="hdfDescripcion" runat="server" Value='<%# Bind("DESCRIPCION") %>' />
                                                                                <asp:HiddenField ID="hdfAccion" runat="server" Value='<%# Bind("ACCION") %>' />
                                                                                <asp:HiddenField ID="hdfCompromiso" runat="server" Value='<%# Bind("COMPROMISO") %>' />
                                                                                <asp:HiddenField ID="hdfIndicador" runat="server" Value='<%# Bind("INDICADOR") %>' />
                                                                                <asp:HiddenField ID="hdfComentario" runat="server" Value='<%# Bind("COMENTARIO") %>' />
                                                                                <%--</div>
                                                                                </div>
                                                                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column DescrpcionPregunta">--%>
                                                                                         
                                                                                    <%--</div>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabPonderacion%>" HeaderStyle-Width="10%" Visible="false">
                                                                            <ItemTemplate>
                                                                                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column">--%>
                                                                                        <asp:Label ID="lblPonderacion" runat="server" Text='<%# Bind("PONDERACION") %>'></asp:Label><span>%</span>
                                                                                    <%--</div>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabComentario%>" HeaderStyle-Width="10%" >
                                                                            <ItemTemplate>
                                                                                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column imgBotton text-center">--%>
                                                                                        <asp:LinkButton ID="lnkAgregarComentario" runat="server" data-toggle="tooltip" OnClick="lnkAgregarComentario_Click" title="<%$ Resources: etiquetas,_etiAgregarComentario%>"><span class="glyphicon glyphicon-comment" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                                                        <%--<asp:ImageButton ID="imgVerDetalles" runat="server" ImageUrl="~/include/images/css/EDITAR.png" Width="30" Height="30" OnClick="imgVerDetalles_Click" />--%>
                                                                                    <%--</div>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabCalificar%>" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column">--%>
                                                                                        <asp:TextBox ID="txtResultado" runat="server" onkeypress="return numbersonly(event);" CssClass="TextCalificar" Text='<%# Bind("RESULTADO") %>' OnTextChanged="txtResultado_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                        <asp:RangeValidator ID="rvEscala" runat="server" ControlToValidate="txtResultado" Text="*" ErrorMessage="El valor ingresado no se encuentra dentro del rango aceptado." ValidationGroup="Validar" MinimumValue="0" MaximumValue="100" Type="Double" CssClass="RangValidatorCalificar"></asp:RangeValidator>
                                                                                    <%--</div>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabCalificar%>" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                                                                    <div class="cbp-mc-1column">--%>
                                                                                        <asp:RadioButtonList ID="rdlRangos" runat="server" CssClass="radioAlternativas" RepeatDirection="Horizontal" BorderWidth="0" TextAlign="Left" OnSelectedIndexChanged="rdlRangos_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList>
                                                                                    <%--</div>
                                                                                </div>--%>
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
                                <asp:HiddenField ID="hdfFlagRangos" runat="server" Value="0" />
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="pnlCapacitaciones" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><span class="glyphicon glyphicon-plus"></span>
                                    <asp:Literal ID="Literal59" runat="server" Text="<%$ Resources: titulos,_titCapacitaciones%>" /></a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="table-wrapper_0 cbp-mc-1column">
                                        <asp:GridView ID="grdCursos" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Selec.">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSeleccionar" runat="server" Checked='<%# Bind("ASIGNADO") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Área">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArea" runat="server" Text='<%# Bind("NOMAREACURSO") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("CODCURSO") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Curso">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCurso" runat="server" Text='<%# Bind("NOMBRECURSO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-1column">
                                        <label>Comentarios</label>
                                        <asp:TextBox ID="txtComentariosCursos" runat="server" TextMode="MultiLine" Rows="3" MaxLength="4000"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="pnlObjetivosProximos" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour"><span class="glyphicon glyphicon-plus"></span>
                                    <asp:Literal ID="Literal60" runat="server" Text="<%$ Resources: titulos,_titObjetivosProximos%>" /></a>
                            </h4>
                        </div>
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-10column octuple10">
                                        <label>Objetivo</label>
                                        <asp:TextBox ID="txtObjetivoProximo" runat="server" MaxLength="256"></asp:TextBox>
                                    </div>
                                    <div class="cbp-mc-10column">
                                        <label>Ponderación</label>
                                        <asp:TextBox ID="txtPondObjProx" runat="server" MaxLength="3"></asp:TextBox>
                                    </div>
                                    <div class="cbp-mc-10column">
                                        <asp:Button ID="btnAgregarObjetivo" runat="server" CssClass="btn btn-primary" Text="Agregar" />
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="table-wrapper_0 cbp-mc-1column">
                                        <asp:GridView ID="grdObjetivosProximos" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Área">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblObjetivo" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ponderación">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtpondObjProx" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="pnlObservacionesFinales" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive"><span class="glyphicon glyphicon-plus"></span>
                                    <asp:Literal ID="Literal61" runat="server" Text="<%$ Resources: titulos,_titObservacionesFinales%>" /></a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-1column">
                                        <label>Observaciones detectadas en su desempeño y plan de mejoras para el próximo periodo</label>
                                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="3" MaxLength="4000"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-1column">
                                        <label>Plan resultante para el próximo periodo</label>
                                        <asp:TextBox ID="txtPlan" runat="server" TextMode="MultiLine" Rows="3" MaxLength="4000"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                    <div class="cbp-mc-1column">
                                        <label>Observaciones y compromisos trabajador evaluado</label>
                                        <asp:TextBox ID="txtObservacionesCompromisos" runat="server" TextMode="MultiLine" Rows="3" MaxLength="4000"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                    <div class="cbp-mc-10column septuple10 text-left">
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiVolver%>" OnClick="btnVolver_Click" />
                        <asp:Button ID="btnVerBitacora" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiBitacora%>" OnClick="btnVerBitacora_Click" />
                        <asp:Button ID="btnComentario" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiAgregarComentario%>" OnClick="btnComentario_Click" />
                        <asp:Button ID="btnBorrador" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiBorrador%>" OnClick="btnBorrador_Click" ValidationGroup="Validar" />
                        <asp:Button ID="btnInformar" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiNotificar%>" OnClick="btnInformar_Click" />
                        <asp:Button ID="btnTomarConocimiento" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiTomarConocimiento%>" OnClick="btnTomarConocimiento_Click" Visible="false" />
                    </div>
                    <div class="cbp-mc-10column triple10 text-right">
                        <asp:Button ID="btnVisar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiVisar%>" OnClick="btnVisar_Click" />
                        <asp:Button ID="btnApelar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiApelar%>" OnClick="btnApelar_Click" />
                        <asp:Button ID="btnGuardarEvaluacion" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiCerrarEvaluacion%>" OnClick="btnGuardarEvaluacion_Click" ValidationGroup="Validar" />
                    </div>
                </div>

            </div>


            <div id="modVerBitacora" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document" style="width: 95%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal33" runat="server" Text="<%$ Resources: titulos,_titBitacora %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="table-wrapper cbp-mc-1column">
                                    <asp:GridView ID="grdBitacora" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabEvaluacion %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluacion" runat="server" Text='<%# Bind("NOM_INSTRUMENTO_EMPLEADO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabInicio %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabFin %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabFechaBitacora %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FECHA_BITACORA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabDescripcion %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modNotificacion" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document" style="width: 50%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal34" runat="server" Text="<%$ Resources: titulos,_titNotificaciones %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal35" runat="server" Text="<%$ Resources: etiquetas,_etiAsunto %>"></asp:Literal></label>
                                    <asp:DropDownList ID="ddlAsuntoCorreo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAsuntoCorreo_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="cbp-mc-1column TextoEnriquecido">
                                    <label>
                                        <asp:Literal ID="Literal36" runat="server" Text="<%$ Resources: etiquetas,_etiCuerpoCorreo %>"></asp:Literal></label>
                                    <FTB:FreeTextBox ID="txtCuerpoCorreo" runat="Server" Width="100%" Height="100%" />
                                    <asp:HiddenField ID="hdfEmailEmpleado" runat="server" Value="" />
                                    <asp:HiddenField ID="hdfNombreEmpleado" runat="server" Value="" />
                                    <asp:HiddenField ID="hdfURL" runat="server" Value="" />
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarNotificacion" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                    <asp:Button ID="btnEnviarNotificacion" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiEnviar%>" OnClick="btnEnviarNotificacion_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modEditarPregunta" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document" style="width: 85%;">
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
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiTextoPregunta%>" /></label>
                                    <asp:TextBox ID="txtPreguntaMant" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-10column quintuple10">
                                    <label>
                                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiDescripcionPregunta%>" /></label>
                                    <asp:TextBox ID="txtDescripPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" ReadOnly="true" Rows="3"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column quintuple10">
                                    <label>
                                        <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: etiquetas,_etiAccionPregunta%>" /></label>
                                    <asp:TextBox ID="txtAccionPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" ReadOnly="true" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-10column quintuple10">
                                    <label>
                                        <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources: etiquetas,_etiCompromisoPregunta%>" /></label>
                                    <asp:TextBox ID="txtCompromisoPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" ReadOnly="true" Rows="3"></asp:TextBox>
                                </div>
                                <div class="cbp-mc-10column quintuple10">
                                    <label>
                                        <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources: etiquetas,_etiIndicadorPregunta%>" /></label>
                                    <asp:TextBox ID="txtIndicadorPreguntaMant" runat="server" MaxLength="4000" TextMode="MultiLine" ReadOnly="true" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarPregunta" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modAgregarComentario" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarComentario %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarComentario%>" /></label>
                                    <asp:TextBox ID="txtComentario" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    <asp:HiddenField ID="hdfCodPreguntaEditar" runat="server" />
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarComentarios" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                    <asp:Button ID="btnAgregarComentario" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiAgregarComentario%>" OnClick="btnAgregarComentario_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modAgregarComentarioEvaluacion" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal31" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarComentario %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal32" runat="server" Text="<%$ Resources: etiquetas,_etiAgregarComentario%>" /></label>
                                    <asp:TextBox ID="txtComentarioEvaluacion" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarComentarioEvaluacion" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                    <asp:Button ID="btnAgregarComentarioEvaluacion" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiAgregarComentario%>" OnClick="btnAgregarComentarioEvaluacion_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modApelar" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources: titulos,_titApelar %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal28" runat="server" Text="<%$ Resources: etiquetas,_etiMotivo%>" /></label>
                                    <asp:TextBox ID="txtMotivoApelacion" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarApelacion" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                    <asp:Button ID="btnApelarEvaluacion" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiApelar%>" OnClick="btnApelarEvaluacion_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="modVisarEvaluacion" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                                data-backdrop="false">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h2>
                                <asp:Literal ID="Literal29" runat="server" Text="<%$ Resources: titulos,_titVisar %>" /></h2>
                        </div>
                        <div class="modal-body">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <label>
                                        <asp:Literal ID="Literal30" runat="server" Text="<%$ Resources: etiquetas,_etiDetalleApelacion%>" /></label>
                                    <asp:TextBox ID="txtDetalleApelacion" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column">
                                    <asp:Button ID="btnCerrarVisacion" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                                    <asp:Button ID="btnVisarEvaluacion" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiVisarEvaluacion%>" OnClick="btnVisarEvaluacion_Click" />
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
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" />
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                            <asp:Button ID="btnContinuarBorrador" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarBorrador_Click" />
                            <asp:Button ID="btnContinuarCerrarEvaluacion" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarCerrarEvaluacion_Click" />
                            <asp:Button ID="btnContinuarVisar" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarVisar_Click" />
                            <asp:Button ID="btnContinuarApelar" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarApelar_Click" />
                            <asp:Button ID="btnContinuarInformar" runat="server" CssClass="btn btn-outline" Text="<%$ Resources: etiquetas,_etiContinuar%>" OnClick="btnContinuarInformar_Click" />
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
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" />
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                                <asp:Literal ID="litErrorVacios" runat="server" Text="<%$ Resources: etiquetas,_etiErrorVacios%>" Visible="false" />
                                <asp:Literal ID="litErrorRango" runat="server" Text="<%$ Resources: etiquetas,_etiErrorRango%>" Visible="false" />
                                <asp:Literal ID="litSinComentario" runat="server" Text="<%$ Resources: etiquetas,_etiErrorSinComentario%>" Visible="false" />
                                <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
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

        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="modFicha" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal42" runat="server" Text="<%$ Resources: titulos,_titFicha %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-2">
                            <label for="txtFichaRut">
                                <asp:Literal ID="Literal43" runat="server" Text="<%$ Resources: etiquetas,_etiRut %>" /></label>
                            <asp:TextBox ID="txtFichaRut" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label for="txtFichaNombres">
                                <asp:Literal ID="Literal44" runat="server" Text="<%$ Resources: etiquetas,_etiNombre %>" /></label>
                            <asp:TextBox ID="txtFichaNombres" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaApPaterno">
                                <asp:Literal ID="Literal45" runat="server" Text="<%$ Resources: etiquetas,_etiApPaterno %>" /></label>
                            <asp:TextBox ID="txtFichaApPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaApMaterno">
                                <asp:Literal ID="Literal46" runat="server" Text="<%$ Resources: etiquetas,_etiApMaterno %>" /></label>
                            <asp:TextBox ID="txtFichaApMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label for="txtFichaEmail">
                                <asp:Literal ID="Literal47" runat="server" Text="<%$ Resources: etiquetas,_etiEmail %>" /></label>
                            <asp:TextBox ID="txtFichaEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-2">
                            <label for="txtFichaSucursal">
                                <asp:Literal ID="Literal48" runat="server" Text="<%$ Resources: etiquetas,_etiSucursal %>" /></label>
                            <asp:TextBox ID="txtFichaSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaGerencia">
                                <asp:Literal ID="Literal49" runat="server" Text="<%$ Resources: etiquetas,_etiGerencia %>" /></label>
                            <asp:TextBox ID="txtFichaGerencia" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaArea">
                                <asp:Literal ID="Literal50" runat="server" Text="<%$ Resources: etiquetas,_etiArea %>" /></label>
                            <asp:TextBox ID="txtFichaArea" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaCentroCosto">
                                <asp:Literal ID="Literal51" runat="server" Text="<%$ Resources: etiquetas,_etiCentroCosto %>" /></label>
                            <asp:TextBox ID="txtFichaCentroCosto" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaRol">
                                <asp:Literal ID="Literal52" runat="server" Text="<%$ Resources: etiquetas,_etiRol %>" /></label>
                            <asp:TextBox ID="txtFichaRol" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label for="txtFichaCargo">
                                <asp:Literal ID="Literal53" runat="server" Text="<%$ Resources: etiquetas,_etiCargo %>" /></label>
                            <asp:TextBox ID="txtFichaCargo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <ul class="nav nav-tabs" style="background-color: transparent; color: #4a4f60;">
                        <li id="liDesempenoFicha" runat="server" class="active">
                            <asp:LinkButton ID="lnkDesempenoFicha" runat="server" OnClick="lnkDesempenoFicha_Click" Text="<%$ Resources: etiquetas,_etiDesempeno%>"></asp:LinkButton>
                        </li>
                        <li id="liKPIFicha" runat="server">
                            <asp:LinkButton ID="lnkKPIFicha" runat="server" OnClick="lnkKPIFicha_Click" Text="<%$ Resources: etiquetas,_etiKPI%>"></asp:LinkButton>
                        </li>
                    </ul>
                    <asp:MultiView ID="mtvFicha" runat="server">
                        <asp:View ID="viewDesempeno" runat="server">
                            <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="table-wrapper cbp-mc-1column">
                                    <asp:GridView ID="grdEvaluacionesFicha" runat="server" Width="100%" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkVer" runat="server" data-toggle="tooltip" OnClick="lnkVer_Click" title="<%$ Resources: etiquetas,_etiVerDetalle%>"><span class="glyphicon glyphicon-eye-open" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVerMisEvaluaciones_Click" title="<%$ Resources: etiquetas,_etiVerEvaluacion%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkVerBitacora" runat="server" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="<%$ Resources: cabeceras,_cabEvaluacion%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreInstrumento" runat="server" Text='<%# Bind("NOM_INSTRUMENTO_EMPLEADO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="12%" HeaderText="<%$ Resources: cabeceras,_cabInicio%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="12%" HeaderText="<%$ Resources: cabeceras,_cabFin%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabNotaFinal%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("NOTA_FINAL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="viewKPI" runat="server">
                            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                                <div class="table-wrapper_8 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                                    <asp:GridView ID="grdKPI" runat="server" Width="100%" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVerMisEvaluaciones_Click1" title="<%$ Resources: etiquetas,_etiVerKPI%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="<%$ Resources: cabeceras,_cabEvaluacion%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreInstrumento" runat="server" Text='<%# Bind("NOM_INSTRUMENTO_EMPLEADO") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdfCodInstrumentoEmpleado" runat="server" Value='<%# Bind("COD_INSTRUMENTO_EMPLEADO") %>' />
                                                    <asp:HiddenField ID="hdfCodInstrumento" runat="server" Value='<%# Bind("COD_INSTRUMENTO") %>' />
                                                    <asp:HiddenField ID="hdfRutEmpleado" runat="server" Value='<%# Bind("RUT_EMPLEADO") %>' />
                                                    <asp:HiddenField ID="hdfRutEvaluador" runat="server" Value='<%# Bind("RUT_EVALUADOR") %>' />
                                                    <asp:HiddenField ID="hdfRutVisador" runat="server" Value='<%# Bind("RUT_VISADOR") %>' />
                                                    <asp:HiddenField ID="hdfCodEstado" runat="server" Value='<%# Bind("CODESTADOEVAL") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="12%" HeaderText="<%$ Resources: cabeceras,_cabInicio%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="12%" HeaderText="<%$ Resources: cabeceras,_cabFin%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="<%$ Resources: cabeceras,_cabEvaluador%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluador" runat="server" Text='<%# Bind("EVALUADOR") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="13%" HeaderText="<%$ Resources: cabeceras,_cabRelacion%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRelacion" runat="server" Text='<%# Bind("RELACION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabEstado%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("NOMESTADOEVAL") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabResultado%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("RESULTADO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="Button3" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modInformeEvaluacion" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal54" runat="server" Text="<%$ Resources: titulos,_titInformeEvaluacion %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="container" style="padding-left: 20px; padding-right: 20px;">
                        <div class="row">
                            <h1>
                                <asp:Literal ID="litNombreEvaluacion" runat="server"></asp:Literal></h1>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="row">
                                    <h2>Resultado final -
                                        <asp:Literal ID="litResultadoFinal" runat="server"></asp:Literal></h2>
                                </div>
                                <div class="row">
                                    <div id="containerFicha"></div>
                                    <asp:HiddenField ID="hdfResumenTextoGraf01" runat="server" />
                                    <asp:HiddenField ID="hdfResumenColabGraf01" runat="server" />
                                    <asp:HiddenField ID="hdfResumenJefatGraf01" runat="server" />
                                    <asp:HiddenField ID="hdfResumenParesGraf01" runat="server" />
                                    <asp:HiddenField ID="hdfResumenAutoevGraf01" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="row">
                                    <h2>Pares</h2>
                                </div>
                                <div class="row">
                                    <div id="containerFichaPares"></div>
                                    <asp:HiddenField ID="hdfResumenTextoGraf02" runat="server" />
                                    <asp:HiddenField ID="hdfResumenDataGraf02" runat="server" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <h2>Colaboradores</h2>
                                </div>
                                <div class="row">
                                    <div id="containerFichaColaboradores"></div>
                                    <asp:HiddenField ID="hdfResumenTextoGraf03" runat="server" />
                                    <asp:HiddenField ID="hdfResumenDataGraf03" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <h2>Comentarios</h2>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtFichaComentarios" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <h2>Plan de desarrollo</h2>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtFichaPlanDesarrollo" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                            <div class="cbp-mc-1column">
                                <asp:Button ID="Button4" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modTomarConocimiento" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal37" runat="server" Text="<%$ Resources: titulos,_titTomaConocimiento %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <p>
                                <asp:CheckBox ID="chkAcuerdo" runat="server" CssClass="chkAcuerdo" />
                                <asp:Literal ID="Literal38" runat="server" Text="<%$ Resources: etiquetas,_etiDeclaracion%>" />
                            </p>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal39" runat="server" Text="<%$ Resources: etiquetas,_etiComentarioFeedback%>" /></label>
                            <asp:TextBox ID="txtComentarioFeedback" runat="server" MaxLength="4000" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                    <%--<div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                                <div class="cbp-mc-1column text-center divAcuerdo">
                                    <span id="checkAcuerdo" class="checkAcuerdo" onclick="CheckAcuerdo();"></span>
                                    <div class="TextAcuerdo">
                                        <asp:Label ID="lblAcuerdo" runat="server" Text="<%$ Resources: etiquetas,_etiAcuerdo%>" />
                                    </div>
                                </div>
                            </div>--%>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <%--<asp:Button ID="btnCerrarFeeback" runat="server" CssClass="btn btn-primary" Text="<%$ Resources: etiquetas,_etiCerrar%>" />--%>
                            <asp:Button ID="btnGuardarFeedback" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiAceptar%>" OnClick="btnGuardarFeedback_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
