<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesionVisitante.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Visitante.InicioSesionVisitante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/><br/><br/>
    <div class="container">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4>Inicio de Sesión - Visitante</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="container">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/IMG-20180831-WA0010.jpg" class="img-fluid img-thumbnail" alt="Responsive image" />
                                </div>
                            </div>


                            <div class="input-group" style="margin-top: 10px;">
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                <asp:TextBox ID="TextCodUsuario" CssClass="form-control" runat="server" Placeholder="CodUsuario"></asp:TextBox>
                            </div>
                            <br />


                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                <asp:TextBox type="password" ID="TextContra" CssClass="form-control" runat="server" Placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <a href="RecuperarClaveVisitante.aspx" class="Olvidarclave">¿Has olvidado los datos de tu cuenta?</a>
                            </div>
                        </div>
                    
                        <div class="row">
                            <div class="col-md-6 BotoneSesion"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="BtnLoginVistante" runat="server" OnClick="BtnLoginVistante_Click" Text="Acceder" CssClass="btn btn-primary" />
                                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                                </div>
                            </div>
                        </div>

                    <div class="col-md-2"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
