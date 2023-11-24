<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="RptHistorialPreMaterial.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala.RptPrestamo.RptHistorialPreMaterial" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-1"></div>
            <fieldset class="col-md-8">
                <legend>Historial de un material</legend>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">

                             <div class="col-md-6">
                                <asp:DropDownList ID="DdlMaterial" OnPreRender="DdlMaterial_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValidarMaterial" ControlToValidate="DdlMaterial" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptHistorialPrestamoMaterial" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                            <asp:TextBox ID="TxtPrimeraFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="ValidaPrimeraFecha" ControlToValidate="TxtPrimeraFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptHistorialPrestamoMaterial" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                            <asp:TextBox ID="TxtSegundaFecha" AutoComplete="off" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidarSegundaFecha" ControlToValidate="TxtSegundaFecha" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="RptHistorialPrestamoMaterial" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="BtnRptHisPrestamoMaterial" OnClick="BtnRptHisPrestamoMaterial_Click"   ValidationGroup="RptHistorialPrestamoMaterial" runat="server" CssClass="btn btn-success" Text="Reporte" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>  
       </div>
      </div> 

     <div class="container-fluid">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="table-responsive">
                    <asp:Button ID="BtnRegresar"  CssClass="btn btn-info" runat="server" Text="Regresar" Visible="false" />
                    <rsweb:ReportViewer ID="RptHistorialMaterial" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>

    </div>
</asp:Content>
