<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cRegistroEntrada.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Registro_Entrada.cRegistroEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">

                         <div class="panel panel-primary">
                        <div class="panel-heading heightheader">
                            <h3>Registro Entrada</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-6">
                                <div class="input-group">
                                    <label>Origen</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-graduation-cap"></i></span>
                                    <asp:TextBox ID="TxtOrigen" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        

                            <div class="col-md-4">
                                <div class="form-group" style="margin-top: 25px;">
                                    <asp:Button ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-info" runat="server" Text="Guardar" />
                                    <asp:Button ID="BntCancelar" CssClass="btn btn-danger"  runat="server" Text="Cancelar" />
                                </div>
                            </div>
                        </div>
                    </div>


                    </div>
                    <div class="col-md-2"></div>

                </div>
                   
           
               
                </div>
          
</asp:Content>
