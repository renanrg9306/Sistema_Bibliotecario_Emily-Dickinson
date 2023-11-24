<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="mClasificacion.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Clasificacion.mClasificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
       <div class="row">
           <div class="col-md-2"></div>
           <div class="col-md-8">
      <div class="panel panel-primary ">
          <div class="panel-heading heightheader">
              <h3>Actualizar Datos Clasificación</h3>
          </div>
          <div class="panel-body">
              <div class="row">
                  <%--<div class="col-sm-2"></div>--%>
                  <div class="col-sm-4">
                      <asp:Label ID="LlbClasificacion" Font-Bold="true" runat="server" Text="Clasificación:"></asp:Label>
                      <asp:TextBox ID="TxtClasificacion" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                   <div class="col-sm-4">
                      <asp:Label ID="LblDescripcion" Font-Bold="true" runat="server" Text="Descripcion:"></asp:Label>
                      <asp:TextBox ID="TxtDescripcion" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>

                  <div class="col-sm-4">
                      <div class="form group">
                          <br/>
                          <asp:Button ID="BtnActualizar" OnClick="BtnActualizar_Click" CssClass="btn btn-info" runat="server" Text="Actualizar" />
                          <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                      </div>
                  </div>
                  <%--<div class="col-sm-2"></div>--%>
              </div>
              <br/>
            
              <div class="row">
                  <div class="col-xs-9">
                      <asp:Label ID="LbIdClasificacion" runat="server" Visible="False"></asp:Label>
                  </div>
                  
              </div>
          </div>
      </div>
    </div>
            <div class="col-md-2"></div>
     </div>
   </div>
</asp:Content>
