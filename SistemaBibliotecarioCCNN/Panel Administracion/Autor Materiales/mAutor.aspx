<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="mAutor.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Autor_Materiales.mAutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Content/Validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h3>Editar Autor</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                      
                        <div class="col-md-10">
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
                        <asp:Button ID="BtnActualizar" OnClick="BtnActualizar_Click" CssClass="btn btn-info" runat="server" Text="Actualizar" />
                        <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                    </div>
                </div>
                           
                            <asp:Label ID="LbIdClasificacion" runat="server" Text="" Visible="false"></asp:Label>
                        
                            </div>
                            
                       
                        </div>
                      
                    </div>
                </div>
            </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
