<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="reporte_detallado.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.gestion.reporte_detallado" %>
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
                        y: <%= litValorAsignadas.Text%>
                    }, {
                        name: "En borrador",
                        color: "#c21856",
                        y: <%= litValorEnBorrador.Text%>
                    }, {
                        name: "Evaluadas",
                        color: "#009551",
                        y: <%= litValorCerradas.Text%>
                    }]
                }],
            });
        });


		    $(function () {
		        $('#container2').highcharts({
		            chart: {
		                type: 'area'
		            },
		            title: {
		                text: 'Distribución por categorias'
		            }, 
		            xAxis: {		                
		                title: {
		                    text: 'Categorias'
		                }, 
		                categories: [<%= hdfCategorias.Value%>]
		            },
		            yAxis: {
		                title: {
		                    text: 'Asignaciones'
		                },
		                labels: {
		                    formatter: function () {
		                        return this.value; /*/ 1000 + 'k';*/
		                    }
		                }
		            },
		            tooltip: {
		                pointFormat: 'Asignaciones <br />{series.name}  {point.y:,.0f}'
		            },
		            plotOptions: {
		                area: {
		                    pointStart: 0,
		                    marker: {
		                        enabled: false,
		                        symbol: 'circle',
		                        radius: 2,
		                        states: {
		                            hover: {
		                                enabled: true
		                            }
		                        }
		                    }
		                }
		            },
		            series: [{
		                name: 'Ascendente',
		                data: [<%= hdfAscendetesValor.Value%>]
		            }, {
		                name: 'Descendente',
		                data: [<%= hdfDescendentesValor.Value%>]
		            }, {
		                name: 'Partners',
		                data: [<%= hdfPartnersValor.Value%>]
		            }]
		        });
		    });

		</script>
    <asp:Literal ID="litScriptGrafico" runat="server"></asp:Literal>
    <div class="container">
        <script src="<%= Page.ResolveUrl("~/include/chart/js/highcharts.js")%>" ></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/data.js")%>" ></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/drilldown.js")%>" ></script>
        <div class="main" style="width: 100% !important;">
            <div style="width: 100%; margin: 0px !important; padding: 0px !important;">

                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column quintuple10" >
                <div class="row" style="width: 100%; margin: 0px !important; padding: 10px !important;">
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;">
                        <label>
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiInstrumento%>" /></label>
                        <asp:DropDownList ID="ddlEvaluaciones" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divEmpresa" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiEmpresa%>" /></label>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divGerencia" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiGerencia%>" /></label>
                        <asp:DropDownList ID="ddlGerencia" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divCentroCosto" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiCentroCosto%>" /></label>
                        <asp:DropDownList ID="ddlCentroCosto" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divSucursal" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: etiquetas,_etiSucursal%>" /></label>
                        <asp:DropDownList ID="ddlSucursal" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divArea" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiArea%>" /></label>
                        <asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divCargo" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCargo%>" /></label>
                        <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divRol" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: etiquetas,_etiRol%>" /></label>
                        <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divClasificador1" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador1%>" /></label>
                        <asp:DropDownList ID="ddlClasificador1" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divClasificador2" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiClasificador2%>" /></label>
                        <asp:DropDownList ID="ddlClasificador2" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divEvaluador" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiEvaluador%>" /></label>
                        <asp:DropDownList ID="ddlEvaluador" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-xs-6" style="margin: 0px !important; padding: 0px !important;" id="divVisador" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: etiquetas,_etiVisador%>" /></label>
                        <asp:DropDownList ID="ddlVisador" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-lg-12 col-xs-12">

                       <asp:Button ID="btnConsultar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiConsultar%>" OnClick="btnConsultar_Click" />
                        <asp:Button ID="btnDescargarConsolidado" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiDescargarConsolidado%>" OnClick="btnDescargarConsolidado_Click" />
                        <asp:Button ID="btnDescargarDetalle" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiDescargarDetalle%>" OnClick="btnDescargarDetalle_Click" />
                    </div>
                </div>
                    </div>
                    <div class="cbp-mc-10column quintuple10" >
                        <div class="row" style="margin-top: 15px;">
                    <div class="col-lg-4 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h3>
                                    <asp:Literal ID="litValorAsignadas" runat="server" Text="0"></asp:Literal></h3>

                                <p>
                                    <asp:Literal ID="litAsignadas" runat="server" Text="<%$ Resources: etiquetas,_etiAsignadas%>" /></p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-bag"></i>
                            </div>
                            <asp:LinkButton ID="lnkVerAsignadas" runat="server" OnClick="lnkVerAsignadas_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-4 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-maroon">
                            <div class="inner">
                                <h3>
                                    <asp:Literal ID="litValorEnBorrador" runat="server" Text="0"></asp:Literal></h3>

                                <p>
                                    <asp:Literal ID="litEnBorrador" runat="server" Text="<%$ Resources: etiquetas,_etiEnBorrador%>" /></p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                            <asp:LinkButton ID="lnkVerEnBorrador" runat="server" OnClick="lnkVerEnBorrador_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                        </div>
                    </div>
                    
                    <div class="col-lg-4 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h3>
                                    <asp:Literal ID="litValorCerradas" runat="server" Text="0"></asp:Literal></h3>

                                <p>
                                    <asp:Literal ID="litCerradas" runat="server" Text="<%$ Resources: etiquetas,_etiCerradas%>" /></p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                            <asp:LinkButton ID="lnkVerCerradas" runat="server" OnClick="lnkVerCerradas_Click" CssClass="small-box-footer" Text="<%$ Resources: etiquetas,_etiVerDetalle%>"><i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                        </div>
                    </div>
                    
                </div>
                    </div>
                </div>

                <%--<div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-1column">
                     </div>
                </div>--%>
                
                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column quintuple10" >
                        <div id="container2" style="min-width: 310px; height: 300px; margin: 0 auto"></div>
                    </div>
                    <div class="cbp-mc-10column quintuple10" >
                        <div id="container" style="min-width: 310px; height: 300px; margin: 0 auto"></div>
                    </div>
                </div>
                
                
                
                
                <%--<div id="containerChart" style="min-width: 310px; height: 400px; margin: 0 auto"></div>--%>

                <div id="grillaEvaluaciones" runat="server" class="table-wrapper_1 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <asp:GridView ID="grdResultados" runat="server" Width="100%" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUT_EMPLEADO") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfCodInstrumentoEmpleado" runat="server" Value='<%# Bind("COD_INSTRUMENTO_EMPLEADO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRE_EMPLEADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabApPaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("APELLIDO_PATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabApMaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("APELLIDO_MATERNO") %>'></asp:Label>
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
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="<%$ Resources: cabeceras,_cabEvaluador%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblEvaluador" runat="server" Text='<%# Bind("EVALUADOR") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabEstado%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("NOMESTADOEVAL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabResultado%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("RESULTADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdfCategorias" runat="server" />
                    <asp:HiddenField ID="hdfAscendetesValor" runat="server" />
                    <asp:HiddenField ID="hdfDescendentesValor" runat="server" />
                    <asp:HiddenField ID="hdfPartnersValor" runat="server" />
                </div>
            </div>
            <%--<div style="width: 100%; margin: 0 auto;" id="divMisEvaluaciones" runat="server" visible="false">
                <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                    <div class="table-wrapper_7 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                        <asp:GridView ID="grdMisEvaluaciones" runat="server" Width="100%" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30%">
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
                                <asp:TemplateField ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("INICIO_EVALUACION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFin" runat="server" Text='<%# Bind("FIN_EVALUACION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvaluador" runat="server" Text='<%# Bind("EVALUADOR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("NOMESTADOEVAL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="6%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResultado" runat="server" Text='<%# Bind("RESULTADO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>

    <div class="modal modal-danger fade" id="modal-danger">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title"><asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" /> 
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>

