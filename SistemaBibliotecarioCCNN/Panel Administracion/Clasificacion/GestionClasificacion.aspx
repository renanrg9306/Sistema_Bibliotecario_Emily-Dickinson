<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="GestionClasificacion.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Clasificacion.GestionClasificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading heightheader">
                    <h3>Gestion de Clasificaciones</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            
                            <div class="table-responsive">
                                <asp:LinkButton ID="LinkBtnNnuevo" OnClick="LinkBtnNnuevo_Click" runat="server" Text="<i class='fa fa-user-plus'></i> Nuevo" CssClass="btn btn-primary"></asp:LinkButton>
                                <asp:GridView ID="GdvClasificacion" AllowPaging="true" OnPageIndexChanging="GdvClasificacion_PageIndexChanging" OnPreRender="GdvClasificacion_PreRender" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="10">
                                    <Columns>
                                        <asp:BoundField DataField="No" HeaderText="No" />
                                        <asp:BoundField DataField="idClasificacion" HeaderText="ID" Visible="False" />
                                        <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                                       <%-- <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />--%>
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkBtnActualizar" CommandArgument='<%#Eval("idClasificacion") %>' OnCommand="LnkBtnActualizar_Command" CssClass="btn btn-success" Text="<i class='glyphicon glyphicon-pencil'></i>Editar" runat="server"></asp:LinkButton>
                                                <asp:LinkButton ID="LnkBtnEliminar" CommandArgument='<%#Eval("idClasificacion") %>' OnCommand="LnkBtnEliminar_Command" CssClass="btn btn-danger" Text="<i class='fa fa-trash'></i>Eliminar" runat="server"></asp:LinkButton>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                            <asp:Label ID="LbIdClasificacion" runat="server" Text="" Visible="false"></asp:Label>
                        
                            </div>
                            
                        <div class="col-md-4">
                            <div class="input-group">
                                <h5>Buscar</h5>
                                <asp:TextBox ID="TxtBusquedaClasificacion" runat="server" AutoPostBack="false" CssClass="form-control" placeholder="Buscar Clasificación" Width="159px"></asp:TextBox>
                                <asp:LinkButton ID="LbtnBuscar" runat="server" CssClass="btn btn-info">
                                                <span class="glyphicon glyphicon-search"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-12">
                        </div>
                        <%--  <div class="col-md-3">
                          
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
   
</asp:Content>
