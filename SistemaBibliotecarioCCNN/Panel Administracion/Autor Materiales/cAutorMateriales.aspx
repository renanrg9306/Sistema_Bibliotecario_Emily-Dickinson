<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cAutorMateriales.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Autor_Materiales.cAutorMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br/>
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading heightheader">
                <h3>Registro de Autor</h3>
            </div>
            <div class="panel-body">
                <div class="col-sm-4">
                    <div class="input-group">
                        <label for="Descripcion">Nombre de Autor:</label>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon"></span>
                        <asp:TextBox type="text" ID="TxtNombreAutor" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Deniss" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="input-group">
                        <label for="Descripcion">Apellido Autor:</label>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon"></span>
                        <asp:TextBox type="text" ID="TxtApellidoAutor" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Zill" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="form-group">
                        <asp:Button ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-info" runat="server" Text="Guardar" />
                        <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                    </div>
                </div>
            </div>
            <div class="col-sm-1">
            </div>
        </div>
    </div>
</asp:Content>
