<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="ficha_colaborador.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.gestion.ficha_colaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="main" style="width: 100% !important;">
            <div style="width: 100%; margin: 0px !important; padding: 0px !important;">

                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;">
                        <label>
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: etiquetas,_etiInstrumento%>" /></label>
                        <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divEmpresa" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: etiquetas,_etiEmpresa%>" /></label>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </div>
                    <div class="cbp-mc-10column double10" style="margin: 0px !important; padding: 0px !important;" id="divEvaluador" runat="server" visible="false" >
                        <label>
                            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources: etiquetas,_etiEvaluador%>" /></label>
                        <asp:DropDownList ID="ddlJefatura" runat="server"></asp:DropDownList>
                    </div>                    
                </div>

                <div class="cbp-mc-form" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <div class="cbp-mc-1column">
                        <asp:Button ID="btnConsultar" runat="server" CssClass="cbp-mc-submit" Text="<%$ Resources: etiquetas,_etiConsultar%>" OnClick="btnConsultar_Click" />
                    </div>
                </div>

                <div class="table-wrapper_1 cbp-mc-1column" style="width: 100%; margin: 0px !important; padding: 0px !important;">
                    <asp:GridView ID="grdResultados" runat="server" Width="100%" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="<%$ Resources: cabeceras,_cabRut%>">
                                <ItemTemplate>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("RUT_EMPLEADO") %>'></asp:Label>
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
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
