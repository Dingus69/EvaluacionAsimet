<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="carga_nomina.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.carga_nomina" %>
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
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titCargaNomina%>" />
                    </h1>
                </div>
            </div>
            
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column triple10">
                    <label></label>
                    
                </div>
                <div class="cbp-mc-10column triple10 divfileUpload"> 
                    <div class="btn btn-default btn-file">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources: etiquetas,_etiSeccionesXLSFUL%>"></asp:Label>
                        <asp:FileUpload ID="fulUsuarios" runat="server" CssClass="upload" placeholder="<%$ Resources: etiquetas,_etiUsuariosXLSFUL%>" />
                    </div>
                    <asp:HyperLink ID="hplDescargarFormato" runat="server" data-toggle="tooltip" NavigateUrl="~/include/plantillas/formato_carga_empleados.xls" Target="_blank" title="<%$ Resources: etiquetas,_etiDescargarFormato%>"><span class="glyphicon glyphicon-download-alt" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:HyperLink>
                </div>
                <div class="cbp-mc-10column triple10">
                    <label></label>
                    <asp:Button ID="btnCargarUsuarios" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiCargar%>" OnClick="btnCargarUsuarios_Click" />
                    <asp:Button ID="btnVolver" runat="server" CssClass="cbp-mc-submit" Text="Volver" OnClick="btnVolver_Click" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper" style="width: 98% !important; margin-right: auto; margin-left: auto;">
                    <asp:GridView ID="grdResultados" runat="server" OnPageIndexChanging="grdResultados_PageIndexChanging">
                    </asp:GridView>
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
                    <h4 class="modal-title"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" /></p>
                    <div id="divErrores" runat="server" visible="false">
                        <p>
                            El siguiente es el detalle de los registros que no fueron ingresados al sistema.
                        </p>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="table-wrapper cbp-mc-1column">
                            <asp:GridView ID="grdDetalleErrores" runat="server" AutoGenerateColumns="false">
                                <Columns> 
                                    <asp:TemplateField HeaderText="Rut">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRut" runat="server" Text='<%# Bind("Rut") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetalle" runat="server" Text='<%# Bind("Error") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    </div>
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
    <script>
        $(document).ready(function(){
            $('[data-toggle="tooltip"]').tooltip();   
        });
    </script>
</asp:Content>
