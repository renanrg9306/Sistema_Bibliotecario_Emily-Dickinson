<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="RptListarLibros.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros.WebFormRpt.RptListarLibros" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container-fluid">
        <div class="row">
       <%-- <div class="col-md-1"></div>--%>
            <div class="col-md-10">
                <div class="table-responsive">
                    <rsweb:ReportViewer ID="RptListarLibro" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>

    </div>
</asp:Content>
