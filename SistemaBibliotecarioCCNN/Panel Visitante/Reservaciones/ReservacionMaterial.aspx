<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Visitante/Visitante.Master" AutoEventWireup="true" CodeBehind="ReservacionMaterial.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Visitante.Materiales.ReservacionMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br/>
<div class="container">
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h2>Reservación de Material</h2>
                </div>
              <div class="panel-body">  
            <div class="row">
                <div class="col-md-4">
                    <div class="input-group">
                        <label>Material:</label>
                        <asp:DropDownList ID="DdlMaterialAB" OnPreRender="DdlMaterialAB_PreRender" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label>Fecha de reservación</label>
                        <asp:TextBox ID="TxtFecha" AutoComplete="off" CssClass="form-control campofecha1 devolucion" runat="server"></asp:TextBox>

                    </div>
                    <asp:RequiredFieldValidator ID="ValidarFechaDevolucion" ControlToValidate="TxtFecha" ForeColor="Red"
                        Display="Dynamic" ValidationGroup="FormCreatePrestamoAB" runat="server"
                        ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                </div>

                 <div class="col-sm-2">
                            <div class="input-group">
                                <label>Cantidad:</label>
                                <asp:TextBox ID="TxtCantidadM" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="ValidarCantidad" ControlToValidate="TxtCantidadM" ForeColor="Red"
                                Display="Dynamic" ValidationGroup="FormCreatePrestamoAB" runat="server"
                                ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>

                <div class="col-sm-3">
                            <div class="form group">
                                <br />
                                <asp:Button ID="BtnGuardar" ValidationGroup="FormCreatePrestamoAB" OnClick="BtnGuardar_Click" CssClass="btn btn-info" runat="server" Text="Guardar" />
                                <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                            </div>
                            <asp:Label ID="LbFecha" runat="server" Visible="false" Text=""></asp:Label>
                        </div>

                </div>
            </div>
        </div>
        </div>
        <div class="col-md-1"></div>


    </div>
    </div>
</asp:Content>
