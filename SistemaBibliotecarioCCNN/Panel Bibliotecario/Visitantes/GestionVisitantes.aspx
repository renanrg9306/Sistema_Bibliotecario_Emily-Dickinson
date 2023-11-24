<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="GestionVisitantes.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Visitantes.GestionVisitantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
     <div class="container-fluid">
            <div class="row">
                <div class="col-md-12" style="margin-left:15px;"><h2>Gestión de Visitantes</h2></div>
                <div class="col-md-12" style="margin-left:15px;">
                      <asp:LinkButton ID="LinkBtnNuevoVisitante" OnClick="LinkBtnNuevoVisitante_Click" runat="server" Text="<i class='fa fa-user-plus'></i> Nuevo" CssClass="btn btn-primary"></asp:LinkButton>
                    </div>
                <div class="col-md-12" style="margin-left: 15px;">
                 <br/>
                 <asp:Label ID="Label1" style="color:red;" Font-Bold="true" runat="server" Text="M: Modificar Registro."></asp:Label><br/>
                 <asp:Label ID="Label2" style="color:red;" Font-Bold="true" runat="server" Text="E: Eliminar Registro."></asp:Label>
             </div>    
                </div>
                    <br/>
                <div class="table-responsive col-md-12">
                    
                    <asp:GridView ID="GridVisitante" OnRowDataBound="GridVisitante_RowDataBound" OnPreRender="GridVisitante_PreRender" runat="server" CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No" />
                            <asp:BoundField DataField="iVisitante" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="Nombre Completo" HeaderText="Nombre Completo"/>                           
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion"/>
                            <asp:BoundField DataField="Program" HeaderText="Program"/>
                            <asp:BoundField DataField="Ocupacion" HeaderText="Ocupación"/>
                            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad"/>                 
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Teléfono"/>
                            <asp:BoundField DataField="Email" HeaderText="Correo" SortExpression="Correo"/>
                            <asp:BoundField DataField="CodUsuario" HeaderText="Codigo Usuario" SortExpression="CodigoU"/>
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" SortExpression="FechaI"/>
                             <asp:BoundField DataField="Prestado" HeaderText="Prestamos"/>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Acciones">
                                <ItemTemplate>                                 
                                    <asp:LinkButton ID="LBtnModifcar"  CommandArgument='<%#Eval("idVisitante")%>' OnCommand="LBtnModifcar_Command" runat="server" Text="<i class='glyphicon glyphicon-pencil'></i>M" CssClass="btn btn-success"></asp:LinkButton>
                                    <%--<asp:LinkButton ID="LBtnEliminar" OnClientClick="return checkDelete(this)" ToolTip='<%#Eval("idVisitante")%>'  runat="server" Text="<i class='fa fa-trash'></i> E" CssClass="btn btn-danger"></asp:LinkButton>--%>
                                    
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />

                        <PagerSettings FirstPageText="" PreviousPageText=""></PagerSettings>

                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <asp:Label ID="LbIdAdmin" runat="server" Visible="True" Text=""></asp:Label>
                     <asp:Label ID="LbIdEmpleado" runat="server" Visible="True" Text=""></asp:Label>
                </div>
           </div>
</asp:Content>
