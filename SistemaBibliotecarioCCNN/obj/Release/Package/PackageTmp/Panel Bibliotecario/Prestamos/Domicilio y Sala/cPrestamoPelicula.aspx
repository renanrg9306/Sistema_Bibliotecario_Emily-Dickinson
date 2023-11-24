<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="cPrestamoPelicula.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Domicilio_y_Sala.cPrestamoPelicula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
    <div class="container">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h3>Préstamo de Peliculas</h3>
                    </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="input-group">
                                 <label>Pelicula:<label class="AstericoColorTamanio">*</label></label>
                                <asp:DropDownList ID="DdlMaterialPelicula" OnPreRender="DdlMaterialPelicula_PreRender"  CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-2">
                            <div class="input-group">
                                <label>Tipo Préstamo:<label class="AstericoColorTamanio">*</label></label>
                                <asp:DropDownList ID="DdlTipoPrestamo" OnPreRender="DdlTipoPrestamo_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                          <div class="col-sm-3">
                        <div class="input-group">
                             <label>Visitante:<label class="AstericoColorTamanio">*</label></label>
                            <asp:DropDownList ID="DdlVisitante" OnPreRender="DdlVisitante_PreRender" CssClass="form-control Selector" runat="server">
                              
                            </asp:DropDownList>
                        </div>
                    </div>
                   
                </div>
                <br />
                  
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label>Fecha Devolución:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtFecha" AutoComplete="off" CssClass="form-control campofecha1 devolucion" runat="server"></asp:TextBox>
                            </div>
                                <asp:RequiredFieldValidator ID="ValidarFechaDevolucion" ControlToValidate="TxtFecha" ForeColor="Red"
                            Display="Dynamic" ValidationGroup="FormCreatePrestamoPelicula" runat="server"
                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>
                         <div class="col-sm-2">
                            <div class="input-group">
                                 <label>Cantidad:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtCantidadM" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                 <asp:RequiredFieldValidator ID="ValidarCantidad" ControlToValidate="TxtCantidadM" ForeColor="Red"
                            Display="Dynamic" ValidationGroup="FormCreatePrestamoPelicula" runat="server"
                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-sm-3" style="margin-top:15px;">
                            <div class="form group">
                                <br />
                                <asp:Button ID="BtnGuardar" ValidationGroup="FormCreatePrestamoPelicula" OnClick="BtnGuardar_Click"  CssClass="btn btn-info" runat="server" Text="Guardar" />
                                <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                            </div>
                            <asp:Label ID="LbFecha" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                        

                    </div>
                        <br/>
                    <asp:Label ID="Label1" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
                 </div>
            </div>
        </div>

    </div>
</asp:Content>
