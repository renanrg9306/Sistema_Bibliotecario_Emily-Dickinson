<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ReportePeliculasV.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Peliculas.WebFormRpt.ReportePeliculasV" %>

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
                                   <legend>Reporte por Protagonista</legend>
                                   <div class="panel panel-default">
                                       <div class="panel-body">
                                           <div class="row">
                                           <div class=" col-md-7">                                         
                                                <asp:DropDownList ID="DdlProtagonista" OnPreRender="DdlProtagonista_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>
                                                 <div class="col-md-5">
                                               <asp:Button ID="BtnCrearReportexProtagonista" OnClick="BtnCrearReportexProtagonista_Click" CssClass="btn btn-success" runat="server" Text="Reporte" />
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
                                   <legend>Reporte por Clasificación y Protagonista</legend>
                                   <div class="panel panel-default">
                                       <div class="panel-body">
                                           <div class="row">
                                           <div class="col-md-5">                                         
                                                <asp:DropDownList ID="DdlClasificacion2" OnPreRender="DdlClasificacion2_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>

                                            <div class="col-md-5">                                         
                                                <asp:DropDownList ID="DdlProtagonista2" OnPreRender="DdlProtagonista2_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>                                             
                                           </div>
                                                                       
                                                 <div class="col-md-2">
                                               <asp:Button ID="BtnClayPro" OnClick="BtnClayPro_Click" CssClass="btn btn-success" runat="server" Text="Reporte" />
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
    
            <div class="col-md-10" style="margin-left:200px;">
                <div class="table-responsive">
                    <asp:Button ID="BtnRegresar" OnClick="BtnRegresar_Click"  CssClass="btn btn-info" runat="server" Text="Regresar" Visible="false" />
                    <rsweb:ReportViewer ID="RptVReportesPelicuaV" runat="server"></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-md-1"></div>
            </div>
        
    </div>
         
</asp:Content>
