<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="RptLiPrestamosRealizados.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Domicilio_y_Sala.WebFormRpt.RptLiPrestamosRealizados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <fieldset class="col-md-4">
                <legend>Rango de Fecha de Préstamos</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                            <asp:TextBox ID="TxtPrimeraFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="ValidaPrimeraFecha" ControlToValidate="TxtPrimeraFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptRangoFechaPrestamo" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-4">
                            <asp:TextBox ID="TxtSegundaFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidarSegundaFecha" ControlToValidate="TxtSegundaFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptRangoFechaPrestamo" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnReportexRangoFecha" OnClick="BtnReportexRangoFecha_Click" ValidationGroup="RptRangoFechaPrestamo" runat="server" CssClass="btn btn-success" Text="Reporte" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>   

            <fieldset class="col-md-3">
                <legend>Prestamo realizado por:</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-8">
                                <asp:DropDownList ID="DdlPrestadoPor" OnPreRender="DdlPrestadoPor_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValidarBibliotecario" ControlToValidate="DdlPrestadoPor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByBiblitecario" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnReportePrestadoPor" OnClick="BtnReportePrestadoPor_Click" ValidationGroup="RptByBiblitecario" runat="server" CssClass="btn btn-success" Text="Reporte" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>   

             <fieldset class="col-md-5">
                <legend>Prestamo realizado por y fecha:</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:DropDownList ID="DdlPrestado_por" OnPreRender="DdlPrestado_por_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="ValidarPrestado_por" ControlToValidate="DdlPrestado_por" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByBibliotecarioFecha" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-4">
                                <asp:TextBox ID="TxtFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ValidadFecha" ControlToValidate="TxtFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptByBibliotecarioFecha" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                 </div>

                            <div class="col-md-2">
                                <asp:Button ID="BtnEmpleado_Date" OnClick="BtnEmpleado_Date_Click" ValidationGroup="RptByBibliotecarioFecha" runat="server" CssClass="btn btn-success" Text="Reporte" />
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
                    <rsweb:ReportViewer ID="RptPrestamosRealizados" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>

    </div>

</asp:Content>
