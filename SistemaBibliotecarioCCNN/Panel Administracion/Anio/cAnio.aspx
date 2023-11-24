<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cAnio.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Anio.cAnio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h3>Registro de Año de Edicion</h3>
                </div>
                <div class="panel-body">

                    <div class="col-sm-6">
                        <div class="input-group">
                            <label for="Anio">Anio:</label>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon"></span>
                            <asp:TextBox type="text" ID="TxtAnio" CssClass="form-control" placeholder="2000" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="input-group">
                            <label for="Accion">Acciones</label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-info" runat="server"  Text="Guardar" />
                            <asp:Button ID="BtnCancelar" CssClass="btn btn-danger"  runat="server" Text="Cancelar" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
