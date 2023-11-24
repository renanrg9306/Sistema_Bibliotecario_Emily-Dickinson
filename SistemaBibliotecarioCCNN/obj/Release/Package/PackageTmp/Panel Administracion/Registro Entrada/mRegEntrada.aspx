<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="mRegEntrada.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Registro_Entrada.mRegEntrada" %>
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
              <h3>Actualizar Datos de Origen</h3>
          </div>
          <div class="panel-body">
              <div class="row">
                  <div class="col-md-1"></div>
                  <div class="col-md-6">
                      <asp:Label ID="LlbOrigen" Font-Bold="true" runat="server" Text="Origen:"></asp:Label>
                      <asp:TextBox ID="TxtOrigen" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="col-md-4">
                      <div class="form group">
                          <br/>
                          <asp:Button ID="BtnActualizar" OnClick="BtnActualizar_Click"  CssClass="btn btn-info" runat="server" Text="Actualizar" />
                          <asp:Button ID="BtnCancelar"  CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                      </div>
                  </div>
                  <div class="col-md-1"></div>
              </div>
              <br/>
            
              <div class="row">
                  <div class="col-md-9">
                      <asp:Label ID="LbIdRegEntrada" runat="server" Visible="False"></asp:Label>
                  </div>
                  
              </div>
          </div>
      </div>
    </div>
            <div class="col-md-1"></div>
     </div>
   </div>
</asp:Content>
