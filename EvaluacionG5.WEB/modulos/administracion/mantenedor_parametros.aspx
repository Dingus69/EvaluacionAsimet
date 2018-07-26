<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="mantenedor_parametros.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.mantenedor_parametros" %>
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
            }
        }
    </script>
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdmParametros%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column double10">
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiDominio%>" /></label>
                    <asp:TextBox ID="txtDominio" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiSMPT%>" /></label>
                    <asp:TextBox ID="txtSMTP" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiPuerto%>" /></label>
                    <asp:TextBox ID="txtPuerto" runat="server" MaxLength="4"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column double10">
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiUsuario%>" /></label>
                    <asp:TextBox ID="txtUsuario" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiPassword%>" /></label>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column double10">
                    <label><asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiUrlPlataforma%>" /></label>
                    <asp:TextBox ID="txtUrlPlataforma" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column" style="display: none;">
                    <label><asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiNombreClasificador1%>" /></label>
                    <asp:TextBox ID="txtNombreClasificador1" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column" style="display: none;">
                    <label><asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiNombreClasificador2%>" /></label>
                    <asp:TextBox ID="txtNombreClasificador2" runat="server" MaxLength="128"></asp:TextBox>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column text-right">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="<%$ Resources: etiquetas,_etiGuardar%>" OnClick="btnGuardar_Click" />
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
                    <h4 class="modal-title"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: titulos,_titAdvertencia%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal6" runat="server" Text="<%$ Resources: etiquetas,_etiAdvertencia%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                    <h4 class="modal-title"><asp:Literal ID="Literal9" runat="server" Text="<%$ Resources: titulos,_titExito%>" /></h4>
                </div>
                <div class="modal-body">
                    <p><asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiExito%>" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal11" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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
                    <h4 class="modal-title"><asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: titulos,_titError%>" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Literal ID="litError" runat="server" Text="<%$ Resources: etiquetas,_etiError%>" Visible="false" />
                        <asp:Literal ID="litCatchError" runat="server" Text="<%$ Resources: etiquetas,_etiCatchError%>" Visible="false" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline pull-left" data-dismiss="modal"><asp:Literal ID="Literal13" runat="server" Text="<%$ Resources: etiquetas,_etiCerrar%>" /></button>
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

