<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="RptPreRecepcionados.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala.RptPrestamo.RptPreRecepcionados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <fieldset class="col-md-4">
                <legend>Recepciones</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                            <asp:TextBox ID="TxtPrimeraFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="ValidaPrimeraFecha" ControlToValidate="TxtPrimeraFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptRangoFechaRepcecion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-4">
                            <asp:TextBox ID="TxtSegundaFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidarSegundaFecha" ControlToValidate="TxtSegundaFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptRangoFechaRepcecion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnRptRecepcionF" OnClick="BtnRptRecepcionF_Click" ValidationGroup="RptRangoFechaRepcecion" runat="server" CssClass="btn btn-success" Text="Reporte" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>   

            <fieldset class="col-md-3">
                <legend>Recepcionado por:</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-8">
                                <asp:DropDownList ID="DdlRecepcionadoPor" OnPreRender="DdlRecepcionadoPor_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValidarRecepcionadopor" ControlToValidate="DdlRecepcionadoPor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByBiblitecario" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnReporteRecepcionadoPor" OnClick="BtnReporteRecepcionadoPor_Click" ValidationGroup="RptByBiblitecario" runat="server" CssClass="btn btn-success" Text="Reporte" /> 
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>   

             <fieldset class="col-md-5">
                <legend>Recepcionado por y fecha:</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:DropDownList ID="DdlRecepcionado_por" OnPreRender="DdlRecepcionado_por_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="ValidarRecepcionado_por" ControlToValidate="DdlRecepcionado_por" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByRecepcionadoporFecha" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-4">
                                <asp:TextBox ID="TxtFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ValidarFecha" ControlToValidate="TxtFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByRecepcionadoporFecha" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                 </div>

                            <div class="col-md-2">
                                <asp:Button ID="BtnRecepcionado_Date" OnClick="BtnRecepcionado_Date_Click" ValidationGroup="RptByRecepcionadoporFecha" runat="server" CssClass="btn btn-success" Text="Reporte" />
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>   
        </div>
    </div>

     <div class="container-fluid">
        <div class="row">
       
            <div class="col-md-10">
                <div class="table-responsive">
                    <asp:Button ID="BtnRegresar"  CssClass="btn btn-info" runat="server" Text="Regresar" Visible="false" />
                    <rsweb:ReportViewer ID="RptMaRecepcionado" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>

    </div>
</asp:Content>
