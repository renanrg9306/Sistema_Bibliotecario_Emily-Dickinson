<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarClaveBibliotecario.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.RecuperarClaveBibliotecario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br/><br/><br/><br/>
    <div class="container">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h2>Recuperar cuenta de Bibliotecario</h2>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Image ID="Image1" ImageUrl="~/Img/Trusted-User (1).png" class="img-fluid img-thumbnail" alt="Responsive image" runat="server" />
                            </div>
                            <div class="col-md-9">
                                <label class="TextoRecuperarCuenta">Ingrese el correo electronico que fue utilizado al momento del registro</label>
                                <asp:TextBox ID="TxtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidarCorreoCuenta" ControlToValidate="TxtCorreo" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormRecoverAcount" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-9">
                                 <label class="TextoRecuperarCuenta">Ingrese el codigo de usuario</label>
                                <asp:TextBox ID="TxtCodUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidarCodUsuario" ControlToValidate="TxtCodUsuario" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormRecoverAcount" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-9"></div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnEnviarClave" OnClick="BtnEnviarClave_Click" CssClass="form-control btn btn-info" ValidationGroup="FormRecoverAcount" runat="server" Text="Enviar" />
                            </div>                         
                        </div>                                          
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
   
</asp:Content>
