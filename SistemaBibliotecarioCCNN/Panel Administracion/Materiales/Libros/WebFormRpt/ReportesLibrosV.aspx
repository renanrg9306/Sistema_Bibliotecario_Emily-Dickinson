<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ReportesLibrosV.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros.WebFormRpt.ReportesLibrosV" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="container-fluid" style="margin-right:20px;">
        <div class="row">
            <div class="col-md-12" style="margin-left:10px;">
      
                            <div class="row">
                               <fieldset class="col-md-4">
                                   <legend>Reporte por Autor</legend>
                                   <div class="panel panel-default">
                                       <div class="panel-body">
                                           <div class="row">
                                           <div class=" col-md-7">                                         
                                                <asp:DropDownList ID="DdlAutor" OnPreRender="DdlAutor_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>
                                                 <div class="col-md-5">
                                               <asp:Button ID="BtnCrearReportexAutor" OnClick="BtnCrearReportexAutor_Click" CssClass="btn btn-success" runat="server" Text="Reporte" />
                                               </div>                                                                                                                                   
                                           </div>
                                        </div>
                                   </div>
                                   </fieldset>  
                                
                                  <fieldset class="col-md-3">
                                   <legend>Reporte por Clasificación</legend>
                                   <div class="panel panel-default">
                                       <div class="panel-body">
                                           <div class="row">
                                           <div class="col-md-8">                                         
                                                <asp:DropDownList ID="DdlClasificacion" OnPreRender="DdlClasificacion_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>
                                                 <div class="col-md-4">
                                               <asp:Button ID="BtnReportexClasificacion" OnClick="BtnReportexClasificacion_Click" CssClass="btn btn-success" runat="server" Text="Reporte" />
                                               </div>                                                                                                                                   
                                           </div>
                                        </div>
                                   </div>
                                   </fieldset>       
                                
                                  <fieldset class="col-md-5">
                                   <legend>Reporte por Clasificación y Autor</legend>
                                   <div class="panel panel-default">
                                       <div class="panel-body">
                                           <div class="row">
                                           <div class="col-md-4">                                         
                                                <asp:DropDownList ID="DdlClasificacion2" OnPreRender="DdlClasificacion2_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>

                                            <div class="col-md-5">                                         
                                                <asp:DropDownList ID="DdlAutor2" OnPreRender="DdlAutor2_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>
                                                                       
                                                 <div class="col-md-3">
                                               <asp:Button ID="BtnClayAu" OnClick="BtnClayAu_Click" CssClass="btn btn-success" runat="server" Text="Reporte" />
                                               </div>                                                                                                                                   
                                           </div>
                                        </div>
                                   </div>
                                   </fieldset>                               
                               </div>
                            </div>                  
                        </div>
        
                </div>



     <br/>
    <div class="container-fluid">
        <div class="row">
          <%--  <div class="col-md-1"></div>--%>
            <div class="col-md-10" style="margin-left:220px;">
                <div class="table-responsive">
                    <asp:Button ID="BtnRegresar"  CssClass="btn btn-info" runat="server" Text="Regresar" Visible="false" />
                    <rsweb:ReportViewer ID="RptLibroVarios" PageCountMode="Actual" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>

    </div>
           <%-- <div class="col-md-1"></div>--%>

     <%--   </div>
        </div>--%>
</asp:Content>
