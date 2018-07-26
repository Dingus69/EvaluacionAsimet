<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.evaluacion.dashboard" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

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
                    $('#modBitacora').modal('show');
                    break;
                case "6":
                    $('#modNotificacion').modal('show');
                    break;
                case "7":
                    $('#modFicha').modal('show');
                    break;
                case "8":
                    $('#modInformeEvaluacion').modal('show');
                    break;
                case "9":
                    $('#modHojaDeVida').modal('show');
                    break;
                case "10":
                    $('#modPlanDesarrollo').modal('show');
                    break;
                case "11":
                    $('#modDetalleHistorial').modal('show');
                    break;
            }
        }
    </script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {$('#container').highcharts({chart: {type: 'column'},
            title: {text: 'Distibución de asignaciones por estado.'},
            xAxis: { categories: [ 'Asignadas', 'En borrador', 'Evaluadas' ], crosshair: true },
            yAxis: {title: {text: 'Cantidad'}},
            legend: {enabled: false},
            plotOptions: {series: {borderWidth: 0,dataLabels: {enabled: true,format: '{point.y:.0f}'}}},
            tooltip: {headerFormat: '<span style="font-size:11px">{series.name}</span><br>',pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>'},
    
            series: [{name: "Estado",colorByPoint: true,data: 
                [{
                    name: "Asignadas",
                    color: "#00add7",
                    y: <%= hdfAsignadas.Value%>
                    }, {
                        name: "En proceso",
                        color: "#c21856",
                        y: <%= hdfEnCurso.Value%>
                        }, {
                            name: "Finalizadas",
                            color: "#009551",
                            y: <%= hdfFinalizada.Value%>
                            }, {
                                name: "En Feedback",
                                color: "#0073b7",
                                y: <%= hdfEnFeedback.Value%>
                                }]
            }],
        });
        });


                        $(function () {$('#containerFicha').highcharts({chart: {type: 'line'},
                            title: {text: '<%= hdfNombreFormulario.Value%>'},
                            xAxis: { categories: [ <%= hdfResumenTextoGraf01.Value%> ], crosshair: true },
                            yAxis: {title: {text: 'Resultado'}},
                            legend: {
                                layout: 'vertical',
                                align: 'right',
                                verticalAlign: 'middle'
                            },
                            plotOptions: {series: {borderWidth: 0,dataLabels: {enabled: true,format: '{point.y:.0f}'}}},
                            tooltip: {headerFormat: '<span style="font-size:11px">{series.name}</span><br>',pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>'},
    
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

                    $(function () {$('#containerFichaPares').highcharts({chart: {type: 'line'},
                        title: {text: '<%= hdfNombreFormulario.Value%> - Colaboradores'},
                        xAxis: { categories: [<%= hdfResumenTextoGraf02.Value%>], crosshair: true },
                        yAxis: {title: {text: 'Resultado'}},
                        legend: {enabled: false},
                        plotOptions: {series: {borderWidth: 0,dataLabels: {enabled: true,format: '{point.y:.0f}'}}},
                        tooltip: {headerFormat: '<span style="font-size:11px">{series.name}</span><br>',pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>'},
    
                        series: [<%= hdfResumenDataGraf02.Value%>],
                    });
                    });

                    $(function () {$('#containerFichaColaboradores').highcharts({chart: {type: 'line'},
                        title: {text: '<%= hdfNombreFormulario.Value%> - Pares'},
                        xAxis: { categories: [<%= hdfResumenTextoGraf03.Value%>], crosshair: true },
                        yAxis: {title: {text: 'Resultado'}},
                        legend: {enabled: false},
                        plotOptions: {series: {borderWidth: 0,dataLabels: {enabled: true,format: '{point.y:.0f}'}}},
                        tooltip: {headerFormat: '<span style="font-size:11px">{series.name}</span><br>',pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.0f}</b><br/>'},
    
                        series: [<%= hdfResumenDataGraf03.Value%>],
                    });
                    });


    </script>
    <div class="container">
        <script src="<%= Page.ResolveUrl("~/include/chart/js/highcharts.js")%>"></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/data.js")%>"></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/drilldown.js")%>"></script>

        <ul class="nav nav-tabs" style="background-color: transparent; color: #4a4f60;">
            <li id="liMisColaboradores" runat="server" class="active">
                <asp:LinkButton ID="lnlMisColaboradores" runat="server" OnClick="lnlMisColaboradores_Click" Text="<%$ Resources: etiquetas,_etiMisColaboradores%>"></asp:LinkButton>
            </li>
            <li id="liMisEvaluaciones" runat="server">
                <asp:LinkButton ID="misEvaluaciones" runat="server" OnClick="misEvaluaciones_Click" Text="<%$ Resources: etiquetas,_etiMisEvaluaciones%>"></asp:LinkButton>
            </li>
            <li id="liKPI" runat="server">
                <asp:LinkButton ID="lnkKPI" runat="server" OnClick="lnkKPI_Click" Text="<%$ Resources: etiquetas,_etiKPI%>"></asp:LinkButton>
            </li>
            <li id="liMiEquipo" runat="server">
                <asp:LinkButton ID="lnkMiEquipo" runat="server" OnClick="lnkMiEquipo_Click" Text="<%$ Resources: etiquetas,_etiMiEquipo%>"></asp:LinkButton>
            </li>
            <li id="liMisVisaciones" runat="server" visible="false">
                <asp:LinkButton ID="misVisaciones" runat="server" OnClick="misVisaciones_Click" Text="<%$ Resources: etiquetas,_etiMisVisaciones%>"></asp:LinkButton>
            </li>
        </ul>
        <asp:HiddenField ID="hdfNombreFormulario" runat="server" />

        <div class="main" style="width: 100% !important;">
            <div style="width: 100%; margin: 0px !important; padding: 0px !important;" id="divMisColaboradores" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;">
                        <label>
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiInstrumento%>" /></label>
                        <asp:DropDownList ID="ddlEvaluaciones" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divEmpresa" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiEmpresa%>" /></label>
                        <asp:DropDownList ID="ddlEmpresa" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divGerencia" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiGerencia%>" /></label>
                        <asp:DropDownList ID="ddlGerencia" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divCentroCosto" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiCentroCosto%>" /></label>
                        <asp:DropDownList ID="ddlCentroCosto" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divSucursal" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: etiquetas,_etiSucursal%>" /></label>
                        <asp:DropDownList ID="ddlSucursal" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divArea" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiArea%>" /></label>
                        <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divCargo" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCargo%>" /></label>
                        <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divRol" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiRol%>" /></label>
                        <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divClasificador1" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador1%>" /></label>
                        <asp:DropDownList ID="ddlClasificador1" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important; display: none;" id="divClasificador2" runat="server" visible="false">
                        <label>
                            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador2%>" /></label>
                        <asp:DropDownList ID="ddlClasificador2" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column">
                        <asp:Button ID="btnConsultar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiConsultar%>" OnClick="btnConsultar_Click" />
                    </div>
                </div>

                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column quintuple10">

                        <div class="row" style="margin-top: 15px;">
                            <div class="col-lg-3 col-xs-6">
                                <div class="small-box bg-aqua">
                                    <div class="inner">
                                        <h3>
                                            <asp:Literal ID="litValorAutoevaluaciones" runat="server" Text="0"></asp:Literal></h3>

                                        <p>
                                            <asp:Literal ID="litAutoevaluaciones" runat="server" Text="<%$ Resources: etiquetas,_etiAutoevaluacion%>" />
                                        </p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-bag"></i>
                                    </div>
                                    <asp:LinkButton ID="lnkVerAutoevaluaciones" runat="server" OnClick="lnkVerAutoevaluaciones_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-lg-3 col-xs-6">
                                <div class="small-box bg-maroon">
                                    <div class="inner">
                                        <h3>
                                            <asp:Literal ID="litValorColaboradores" runat="server" Text="0"></asp:Literal></h3>

                                        <p>
                                            <asp:Literal ID="litColaboradores" runat="server" Text="<%$ Resources: etiquetas,_etiColaboradores%>" />
                                        </p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                    <asp:LinkButton ID="lnkVerColaboradores" runat="server" OnClick="lnkVerColaboradores_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-lg-3 col-xs-6">
                                <div class="small-box bg-green">
                                    <div class="inner">
                                        <h3>
                                            <asp:Literal ID="litValorJefaturas" runat="server" Text="0"></asp:Literal></h3>

                                        <p>
                                            <asp:Literal ID="litJefaturas" runat="server" Text="<%$ Resources: etiquetas,_etiJefaturas%>" />
                                        </p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                    <asp:LinkButton ID="lnkVerJefaturas" runat="server" OnClick="lnkVerJefaturas_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-lg-3 col-xs-6">
                                <div class="small-box bg-blue">
                                    <div class="inner">
                                        <h3>
                                            <asp:Literal ID="litValorPares" runat="server" Text="0"></asp:Literal></h3>

                                        <p>
                                            <asp:Literal ID="litPares" runat="server" Text="<%$ Resources: etiquetas,_etiPares%>" />
                                        </p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                    <asp:LinkButton ID="lnkVerPares" runat="server" OnClick="lnkVerPares_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>
                            </div>


                        </div>
                    </div>





                    <div class="cbp-mc-10column quintuple10">
                        <div id="container" style="min-width: 310px; height: 162px; margin: 0 auto"></div>
                    </div>
                    <asp:HiddenField ID="hdfAsignadas" runat="server" Value="0" />
                    <asp:HiddenField ID="hdfEnCurso" runat="server" Value="0" />
                    <asp:HiddenField ID="hdfFinalizada" runat="server" Value="0" />
                    <asp:HiddenField ID="hdfEnFeedback" runat="server" Value="0" />
                </div>

                <div id="grillaEvaluaciones" runat="server" class="table-wrapper_1 cbp-mc-1column sin_bordes" style="width: 100%; margin: 0px !important; padding: 0px !important; overflow: hidden">
                    <asp:Repeater ID="repEvaluaciones" runat="server">
                        <ItemTemplate>
                            <table class="TableEvaluaciones">
                                <tr>
                                    <td class="tdAvatar">
                                        <asp:Image ID="Image1" runat="server" />
                                        <img src="../../include/images/avatar-usuario-generico.png" width="70" height="70" alt="" /></td>
                                    <td class="tdDatos1">
                                        <%--<asp:Label ID="Label2" runat="server" Text="Rut" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RUT_EMPLEADO") %>'></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Nombre" CssClass="Dato"></asp:Label>:
                                        <br />--%>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("NOMBRE_EMPLEADO") %>' CssClass="DatoResaltado"></asp:Label>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("APELLIDO_PATERNO") %>' CssClass="DatoResaltado"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("APELLIDO_MATERNO") %>' CssClass="DatoResaltado"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label7" runat="server" Text="Gerencia" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("NOMBRE_GERENCIA") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label9" runat="server" Text="Cargo" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("NOMBRE_CARGO") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label11" runat="server" Text="Relacion" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="lblRelacion" runat="server" Text='<%# Bind("RELACION") %>'></asp:Label>
                                    </td>
                                    <td class="tdDatos2">
                                        <asp:Label ID="Label12" runat="server" Text="Inicio" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label14" runat="server" Text="Fin" CssClass="Dato"></asp:Label>:
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                    </td>
                                    <td class="tdAcciones">
                                        <asp:LinkButton ID="lnkEvaluar" runat="server" data-toggle="tooltip" OnClick="lnkEvaluar_Click" title="<%$ Resources: etiquetas,_etiEvaluar%>"><span class="glyphicon glyphicon-list-alt bg-green" style="border-radius: 100%; width:50px; height: 50px; background-color: #fff; text-align: center; line-height: 2em; font-size: 24px !important; color: #fff !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkEditar" runat="server" data-toggle="tooltip" OnClick="lnkEditar_Click" Visible="false" title="<%$ Resources: etiquetas,_etiEditar%>"><span class="glyphicon glyphicon-edit" style="border-radius: 100%; width:50px; height: 50px; background-color: #fff; text-align: center; line-height: 2em; font-size: 24px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkVerBitacora" runat="server" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" Visible="false" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:50px; height: 50px; background-color: #fff; text-align: center; line-height: 2em; font-size: 24px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkNotificaciones" runat="server" data-toggle="tooltip" OnClick="lnkNotificaciones_Click" Visible="false" title="<%$ Resources: etiquetas,_etiNotificar%>"><span class="glyphicon glyphicon-envelope" style="border-radius: 100%; width:50px; height: 50px; background-color: #fff; text-align: center; line-height: 2em; font-size: 24px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="hdfCodInstrumentoEmpleado" runat="server" Value='<%# Bind("COD_INSTRUMENTO_EMPLEADO") %>' />
                            <asp:HiddenField ID="hdfCodEstado" runat="server" Value='<%# Bind("CODESTADOEVAL") %>' />
                            <asp:HiddenField ID="hdfFlagAgregarPregunta" runat="server" Value='<%# Bind("FLAG_AGREGAR_PREGUNTA") %>' />
                            <asp:HiddenField ID="hdfVisacion" runat="server" Value='<%# Bind("FLAG_VISACION") %>' />
                            <asp:HiddenField ID="hdfApelacion" runat="server" Value='<%# Bind("FLAG_APELACION") %>' />
                            <asp:HiddenField ID="hdfAutoEvaluacion" runat="server" Value='<%# Bind("FLAG_AUTOEVALUACION") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:GridView ID="grdResultados" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grdResultados_RowDataBound" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div style="width: 100%; margin: 0 auto;" id="divMisEvaluaciones" runat="server" visible="false">
                <ul class="nav nav-tabs" style="background-color: transparent; color: #4a4f60;">
                    <li id="liMiDesempeno" runat="server" class="active">
                        <asp:LinkButton ID="lnkMiDesempeno" runat="server" OnClick="lnkMiDesempeno_Click" Text="<%$ Resources: etiquetas,_etiMiDesempeno%>"></asp:LinkButton>
                    </li>
                    <li id="liMisKPI" runat="server">
                        <asp:LinkButton ID="lnkMisKPI" runat="server" OnClick="lnkMisKPI_Click" Text="<%$ Resources: etiquetas,_etiMisKPI%>"></asp:LinkButton>
                    </li>
                </ul>
                <asp:MultiView ID="mtvHistorial" runat="server">
                    <asp:View ID="viewMiDesempeño" runat="server">
                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="table-wrapper_7 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                                <asp:GridView ID="grdMisEvaluaciones" runat="server" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVer2_Click" title="<%$ Resources: etiquetas,_etiVerDetalle%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                <%--<asp:LinkButton ID="lnkVerBitacora" runat="server" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>--%>
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
                                        <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabNotaJefes%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResultadoJefe" runat="server" Text='<%# Bind("NOTA_JEFE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabNotaColab%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResultadoColab" runat="server" Text='<%# Bind("NOTA_COLAB") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabNotaPar%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResultadoPares" runat="server" Text='<%# Bind("NOTAL_PARES") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" HeaderText="<%$ Resources: cabeceras,_cabNotaAutoeval%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResultadoAuto" runat="server" Text='<%# Bind("NOTA_AUTOEV") %>'></asp:Label>
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
                    <asp:View ID="viewMisKPI" runat="server">
                        <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                            <div class="table-wrapper_8 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                                <asp:GridView ID="grdMisKPI" runat="server" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVerMisEvaluaciones_Click" title="<%$ Resources: etiquetas,_etiVerEvaluacion%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                                <asp:LinkButton ID="lnkVerBitacora" runat="server" Visible="false" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
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
            </div>
            <div style="width: 100%; margin: 0 auto;" id="divVIsar" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="table-wrapper_8 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                        <asp:GridView ID="grdVisar" runat="server" Width="100%" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVisar" runat="server" OnClick="lnkVisar_Click" ToolTip="<%$ Resources: etiquetas,_etiVisarEvaluacion%>"><span class="glyphicon glyphicon-check" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkVerBitacora" runat="server" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="19%" HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreEmpleado" runat="server" Text='<%# Bind("EMPLEADO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabRelacion%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelacion" runat="server" Text='<%# Bind("RELACION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabEvaluacion%>">
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
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabInicio%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabFin%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="18%" HeaderText="<%$ Resources: cabeceras,_cabEvaluador%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvaluador" runat="server" Text='<%# Bind("EVALUADOR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabEstado%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("NOMESTADOEVAL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="7%" HeaderText="<%$ Resources: cabeceras,_cabResultado%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("RESULTADO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div style="width: 100%; margin: 0 auto;" id="divKPI" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="table-wrapper_8 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                        <asp:GridView ID="grdMisKPIVigente" runat="server" Width="100%" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVerMisEvaluaciones_Click" title="<%$ Resources: etiquetas,_etiVerEvaluacion%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkVerBitacora" runat="server" Visible="false" data-toggle="tooltip" OnClick="lnkVerBitacora_Click" title="<%$ Resources: etiquetas,_etiBitacora%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
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
            </div>
            <div style="width: 100%; margin: 0 auto;" id="divMiEquipo" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="table-wrapper_8 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                        <asp:GridView ID="grdMiEquipo" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="grdMiEquipo_RowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVerFicha" runat="server" data-toggle="tooltip" OnClick="lnkVerFicha_Click" title="<%$ Resources: cabeceras,_cabFicha%>"><span class="glyphicon glyphicon-eye-open" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkVerHojaDeVida" runat="server" data-toggle="tooltip" OnClick="lnkVerHojaDeVida_Click" title="<%$ Resources: etiquetas,_etiHojaDeVida%>"><span class="glyphicon glyphicon-list" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkKIPVigente" runat="server" data-toggle="tooltip" OnClick="lnkKIPVigente_Click" title="<%$ Resources: etiquetas,_etiKPIVigente%>"><span class="glyphicon glyphicon-stats" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                        <asp:LinkButton ID="lnkPlanDesarrollo" runat="server" data-toggle="tooltip" OnClick="lnkPlanDesarrollo_Click" title="<%$ Resources: etiquetas,_etiPlanDesarrollo%>"><span class="glyphicon glyphicon-education" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="19%" HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRECOMPLETO") %>'></asp:Label>
                                        <asp:HiddenField ID="hdfRutEmpleado" runat="server" Value='<%# Bind("RUTEMPLEADO") %>' />
                                        <asp:HiddenField ID="hdfFechaIngreso" runat="server" Value='<%# Bind("FECHAINGRESO") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabSucursal%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSucursal" runat="server" Text='<%# Bind("NOMBRE_SUCURSAL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabArea%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%# Bind("NOMBRE_AREA") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabCargo%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCargo" runat="server" Text='<%# Bind("NOMBRE_CARGO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>



    <div id="modBitacora" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titBitacora %>" /></h2>
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

                    <ul id="ulFicha" runat="server" class="nav nav-tabs" style="background-color: transparent; color: #4a4f60;">
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
                                                    <asp:LinkButton ID="lnkVerMisEvaluaciones" runat="server" data-toggle="tooltip" OnClick="lnkVerMisEvaluaciones_Click" title="<%$ Resources: etiquetas,_etiVerKPI%>"><span class="glyphicon glyphicon-list-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
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

    <div id="modHojaDeVida" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal33" runat="server" Text="<%$ Resources: etiquetas,_etiHojaDeVida %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>Agregar cometario</label>
                            <asp:TextBox ID="txtAgregarComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnAgregarHojaVida" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnAgregarHojaVida_Click" />
                            <asp:Button ID="btnCerrarHojaVida" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />

                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="table-wrapper cbp-mc-1column">
                            <asp:GridView ID="grdHojaDeVida" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabFecha %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FECHAINGRESO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabInicio %>">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComentario" runat="server" Text='<%# Bind("OBSERVACION") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modPlanDesarrollo" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default btnCerrarModal"><span aria-hidden="true">×</span></asp:LinkButton>--%>
                    <h2>
                        <asp:Literal ID="Literal34" runat="server" Text="<%$ Resources: titulos,_titPlanDesarrollo %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="container" style="padding-left: 20px; padding-right: 20px;">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtPlanDesarrolloMant" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                            <div class="cbp-mc-1column">
                                <asp:Button ID="btnGuardarPlan" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardarPlan_Click" />
                                <asp:Button ID="Button5" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                            </div>
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
                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: titulos,_titNotificaciones %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <label>
                                <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiAsunto %>"></asp:Literal></label>
                            <asp:DropDownList ID="ddlAsuntoCorreo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAsuntoCorreo_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="cbp-mc-1column TextoEnriquecido">
                            <label>
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiCuerpoCorreo %>"></asp:Literal></label>
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

    <div id="modDetalleHistorial" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document" style="width: 80%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close" class="btn btn-default" data-dismiss="modal"
                        data-backdrop="false">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h2>
                        <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources: titulos,_titVerDetalles %>" /></h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="table-wrapper_7 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                            <asp:GridView ID="grdDetalleHistorial" runat="server" Width="100%" AutoGenerateColumns="false" ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:GridView ID="grdDetalleHistorialInterna" runat="server" DataSource='<%# Bind("SECCIONES") %>' AutoGenerateColumns="true">
                                            </asp:GridView>
                                            <asp:TextBox ID="txtComentarioFeedback" runat="server" TextMode="MultiLine" Rows="3" CssClass="full-width-chart" Text='<%# Bind("COMENTARIO_FEEDBACK") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 100%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <asp:Button ID="btnCerrarDetalleHistorial" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCerrar%>" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                        <asp:Literal ID="litSinKPI" runat="server" Text="<%$ Resources: titulos,_alertSinKPI%>" Visible="false" />
                        <asp:Literal ID="litSinAcceso" runat="server" Text="<%$ Resources: titulos,_alertSinAcceso%>" Visible="false" />
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
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

    <div class="modal modal-success fade" id="modal-success">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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

