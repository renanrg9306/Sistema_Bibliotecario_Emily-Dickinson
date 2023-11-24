<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="Prorroga.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Prorroga.Prorroga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
    <div class="container">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <div class="panel panel-primary">
                    <div class="panel-heading heightheader">
                        <h3>Prórroga de Material</h3>
                    </div>

                    

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Fecha Devolución:</label>
                                       <asp:TextBox ID="TxtFechaDevolucion" AutoComplete="off" Enabled="false" CssClass="form-control devolucion" runat="server"></asp:TextBox>
                                   
                                </div>
                            </div>


                            <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Primera Prórroga:</label>
                                        <asp:TextBox ID="TxtDatePickerProrroga1" AutoComplete="off" CssClass="form-control campofecha" runat="server"></asp:TextBox>
                                   
                                </div>
                            </div>

                             <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Segunda Prórroga:</label>
                                    <asp:TextBox ID="TxtDatePickerProrroga2" AutoComplete="off"  CssClass="form-control campofechaSegundaProrroga" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-sm-3" style="margin-top: 5px;">
                                <div class="form group">
                                    <br />
                                    <asp:Button ID="BtnDarProrroga" OnClick="BtnDarProrroga_Click" CssClass="btn btn-info" runat="server" Text="P" />
                                    <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" OnClick="BtnCancelar_Click" runat="server" Text="Cancelar" />
                                </div>
                                
                            </div>

                        </div>
                    </div>
                </div>

            </div>
            <div class="col-sm-2"></div>

        </div>
                
        </div>
</asp:Content>
