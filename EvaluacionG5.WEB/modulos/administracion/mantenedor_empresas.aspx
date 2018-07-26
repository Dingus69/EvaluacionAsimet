<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="mantenedor_empresas.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.mantenedor_empresas" %>

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
            }
        }
    </script>
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-1column">
                    <h1>
                        <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources: titulos,_titAdmUsuarios%>" />
                    </h1>
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="cbp-mc-10column">
                    <label>
                        <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources: etiquetas,_etiRut%>" /></label>
                    <asp:TextBox ID="txtRutUsuario" runat="server" MaxLength="12"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column sextuple10">
                    <label>
                        <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" MaxLength="128"></asp:TextBox>
                </div>
                <div class="cbp-mc-10column triple10">
                    <asp:Button ID="btnConsultar" runat="server" Text="<%$ Resources: etiquetas,_etiConsultar%>" CssClass="btn btn-success" OnClick="btnConsultar_Click" />
                    <asp:Button ID="btnNuevo" runat="server" Text="<%$ Resources: etiquetas,_etiNuevo%>" CssClass="btn btn-success" OnClick="btnNuevo_Click" />
                </div>
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
            </div>
            <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                <div class="table-wrapper cbp-mc-1column">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabAccion%>">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditar" runat="server" data-toggle="tooltip" OnClick="lnkEditar_Click" title="<%$ Resources: etiquetas,_etiEditar%>"><span class="glyphicon glyphicon-edit" style="border-radius: 100%; width:23px; height: 23px; background-color: #fff; text-align: center; line-height: 2em; font-size: 12px !important; color: #4a4f60 !important;" ></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100" HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUTCOMPLETO") %>'></asp:Label>
                                    <asp:HiddenField ID="hdfEmail" runat="server" Value='<%# Bind("EMAIL") %>' />
                                    <asp:HiddenField ID="hdfPassword" runat="server" Value='<%# Bind("PASSWORD") %>' />
                                    <asp:HiddenField ID="hdfFlagActivo" runat="server" Value='<%# Bind("FLAGACTIVO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabNombre%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBREUSUARIO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApPaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("APELLIDOPATERNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: cabeceras,_cabApMaterno%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("APELLIDOMATERNO") %>'></asp:Label>
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
                        <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources: titulos,_titAdmUsuarios %>" />
                    </h2>
                </div>
                <div class="modal-body">
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiRut%>" /></label>
                            <asp:TextBox ID="txtRut" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column triple10">
                            <label>
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiNombre%>" /></label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="128"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources: etiquetas,_etiApPaterno%>" /></label>
                            <asp:TextBox ID="txtApPaterno" runat="server" MaxLength="128"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources: etiquetas,_etiApMaterno%>" /></label>
                            <asp:TextBox ID="txtApMaterno" runat="server" MaxLength="128"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column triple10">
                            <label>
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources: etiquetas,_etiEmail%>" /></label>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="128"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources: etiquetas,_etiPassword%>" /></label>
                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <label>
                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources: etiquetas,_etiRepetirPassword%>" /></label>
                            <asp:TextBox ID="txtRepPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="cbp-mc-10column double10">
                            <asp:CheckBox ID="chkActivo" runat="server" CssClass="chk" Text="<%$ Resources: etiquetas,_etiActivo%>" />
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column triple10 divfileUpload">
                            <div class="btn btn-default btn-file">
                                <asp:Label ID="Label1" runat="server" Text="Cargar Logo"></asp:Label>
                                <asp:FileUpload ID="fulLogo" runat="server" CssClass="upload" placeholder="Cargar Logo" />
                            </div> 
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-1column">
                            <h2>
                                <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources: titulos,_etiPerfiles%>" />
                            </h2>
                        </div>
                    </div>
                    <div class="cbp-mc-form" style="width: 95%; margin: 0 auto;">
                        <div class="cbp-mc-10column">
                        </div>
                        <div class="cbp-mc-10column triple10">
                            <label>
                                <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources: etiquetas,_etiDisponibles%>" /></label>
                            <asp:ListBox ID="lstDisponibles" runat="server"></asp:ListBox>
                        </div>
                        <div class="cbp-mc-10column double10 text-center">
                            <asp:Button ID="btnIrUno" runat="server" Text="<%$ Resources: etiquetas,_etiIrUno%>" CssClass="cbp-mc-submit" OnClick="btnIrUno_Click" />
                            <asp:Button ID="btnIrTodos" runat="server" Text="<%$ Resources: etiquetas,_etiIrTodos%>" CssClass="cbp-mc-submit" OnClick="btnIrTodos_Click" />
                            <asp:Button ID="btnVolverUno" runat="server" Text="<%$ Resources: etiquetas,_etiVolverUno%>" CssClass="cbp-mc-submit" OnClick="btnVolverUno_Click" />
                            <asp:Button ID="btnVolverTodos" runat="server" Text="<%$ Resources: etiquetas,_etiVolverTodos%>" CssClass="cbp-mc-submit" OnClick="btnVolverTodos_Click" />
                        </div>
                        <div class="cbp-mc-10column triple10">
                            <label>
                                <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources: etiquetas,_etiAsignados%>" /></label>
                            <asp:ListBox ID="lstAsignados" runat="server"></asp:ListBox>
                        </div>
                        <div class="cbp-mc-10column">
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
        </div>
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
        </div>
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
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>


