<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cClasificacion.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Clasificacion.cClasificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="container">
        <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h3>Clasificación de Materiales</h3>
                </div>
            <div class="panel-body">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <%-- PRIMER PANEL DE REGISTRO DE CLASIFICACION--%>
                    <div class="panel panel-default">
                        <div class="panel-heading heightheader">
                            <h3>Registro de Clasificación</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-4">
                                <div class="input-group">
                                    <label>Clasificación</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-graduation-cap"></i></span>
                                    <asp:TextBox ID="TxtClasificacion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                              <div class="col-md-4">
                                <div class="input-group">
                                    <label>Descripcion</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-graduation-cap"></i></span>
                                    <asp:TextBox ID="TxtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group" style="margin-top: 25px;">
                                    <asp:Button ID="BtnGuardar" CssClass="btn btn-info" OnClick="BtnGuardar_Click" runat="server" Text="Guardar" />
                                    <asp:Button ID="BntCancelar" CssClass="btn btn-danger" OnClick="BntCancelar_Click" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--SEGUNDO PANEL DE BUSQUEDA , ELIMINACION Y EDICION.--%>
               
                </div>
            </div>
        </div>
    </div>

</asp:Content>
