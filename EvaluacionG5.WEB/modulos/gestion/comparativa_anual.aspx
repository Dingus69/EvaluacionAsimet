<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="comparativa_anual.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.gestion.comparativa_anual" %>

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
        $(function () {
            $('#barChart').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Comparativa Anual'
                },
                xAxis: {
                    categories: [
                        '2017',
                        '2016',
                        '2015'
                    ],
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Resultados Promedio'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    name: 'Gerencia de Productos',
                    data: [3, 4, 3]

                }, {
                    name: 'Gerencia Comercial',
                    data: [2, 5, 3]

                }, {
                    name: 'Gerencia de Recursos Humanos',
                    data: [4, 4, 2]

                }, {
                    name: 'Gerencia de Finanzas',
                    data: [5, 2, 4]

                }]
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#pieChart').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Resultado Compañia por Años'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.y}</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.y}',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: "Años",
                    colorByPoint: true,
                    data: [{
                        name: "2017",
                        y: 5
                    }, {
                        name: "2016",
                        y: 4,
                        sliced: true,
                        selected: true
                    }, {
                        name: "2015",
                        y: 2
                    }]
                }]
            });
        });
    </script>
    <div class="container">
        <script src="<%= Page.ResolveUrl("~/include/chart/js/highcharts.js")%>"></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/data.js")%>"></script>
        <script src="<%= Page.ResolveUrl("~/include/chart/js/modules/drilldown.js")%>"></script>
        <div class="main" style="width: 100% !important;">

            <div style="width: 100%; margin: 0px !important; padding: 0px !important;">
                

                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column sextuple10" style="margin: 0px !important; padding: 0px !important;">
                        <label>
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiInstrumento%>" /></label>
                        <asp:DropDownList ID="ddlEvaluaciones" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;">
                        <label>
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiTipoReporte%>" /></label>
                        <asp:DropDownList ID="ddlTipoReporte" runat="server"></asp:DropDownList>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;">
                        <asp:Button ID="btnConsultar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiConsultar%>" OnClick="btnConsultar_Click" />
                        <asp:Button ID="btnDescargar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiDescargar%>" OnClick="btnDescargar_Click" />
                    </div>
                </div> 
                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column quintuple10" style="margin: 0px !important; padding: 0px !important;">
                        <div id="pieChart" style="min-width: 310px; height: 250px; margin: 0 auto"></div>
                    </div>
                    <div class="cbp-mc-10column quintuple10" style="margin: 0px !important; padding: 0px !important;">
                        <div id="barChart" style="min-width: 310px; height: 250px; margin: 0 auto"></div>
                    </div>
                </div>
                <div id="grillaResultado" runat="server" class="table-wrapper_1 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <asp:GridView ID="grdResultados" runat="server" Width="100%" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="70%">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultadoAgno1" runat="server" Text='<%# Bind("RESULTADO_AGNO1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultadoAgno2" runat="server" Text='<%# Bind("RESULTADO_AGNO2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultadoAgno3" runat="server" Text='<%# Bind("RESULTADO_AGNO3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                        <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">
                        <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>

