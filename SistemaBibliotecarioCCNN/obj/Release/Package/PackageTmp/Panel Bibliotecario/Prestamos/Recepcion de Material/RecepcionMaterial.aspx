<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="RecepcionMaterial.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Prestamos.Recepcion_de_Material.RecepcionMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div class="container-fluid">
            <div class="row">
                <div class="col-md-8" style="margin-left:15px;"><h2>Materiales Recepcionados</h2></div>
                <div class="col-md-3" style="margin-left:95px;">
                 
                </div>
                </div>
              <br/>
                <div class="table-responsive col-md-12">
                  <%--  <asp:LinkButton ID="LinkBtnNLibro" OnClick="LinkBtnNLibro_Click"  runat="server" Text="<i class='fa fa-plus'></i> Libro" CssClass="btn btn-primary"></asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnNAB" OnClick="LinkBtnNAB_Click"  runat="server" Text="<i class='fa fa-plus'></i> AudioBook" CssClass="btn btn-primary"></asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnNRevista" OnClick="LinkBtnNRevista_Click"  runat="server" Text="<i class='fa fa-plus'></i> Revista" CssClass="btn btn-primary"></asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnNPelicula" OnClick="LinkBtnNPelicula_Click"  runat="server" Text="<i class='fa fa-plus'></i> Pelicula" CssClass="btn btn-primary"></asp:LinkButton>
  --%>
                    <asp:GridView ID="GridVPrestamosRecepcionados" OnRowDataBound="GridVPrestamosRecepcionados_RowDataBound" OnPreRender="GridVPrestamosRecepcionados_PreRender" runat="server" CssClass="table-condensed table-bordered gvdatatable" Class="search-table" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" Font-Size="Small">
                        
                       <Columns>
                            <asp:BoundField DataField="No" HeaderText="No" />
                         <%--   <asp:BoundField DataField="idPrestamo" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="idEntrega_Prestamo" HeaderText="IDE" Visible="false" />--%>
                            <asp:BoundField DataField="Nombre del Material" HeaderText="Material" />
                            <%--<asp:BoundField DataField="Descripcion Material" HeaderText="Descripcion" />--%>
                            <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación"/> 
                            <asp:BoundField DataField="Nombre Visitante" HeaderText="Visitante"/> 
                            <asp:BoundField DataField="Program" HeaderText="Program"/> 
                           <%-- <asp:BoundField DataField="Contacto" HeaderText="Contacto"/> --%>
                            <asp:BoundField DataField="Prestado por" HeaderText="Prestado por" />
                            <asp:BoundField DataField="Fecha del Prestamo" HeaderText="Fecha del Prestamo"/>
                            <asp:BoundField DataField="Fecha de Devolucion" HeaderText="Fecha Devolucion"/> 
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Prestada"/>  
                            <asp:BoundField DataField="TipoPrestamo" HeaderText="Tipo"/> 
                            <asp:BoundField DataField="Fecha_Recepcion" HeaderText="Fecha Recepción"/>  
                           <asp:BoundField DataField="Recepcionado_Por" HeaderText="Recepcionado Por"/>
                          <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Acciones">--%>
                          <%--      <ItemTemplate>                                 
                                    <asp:LinkButton ID="LBtRecepcionar"  CommandArgument='<%#Eval("idEntrega_Prestamo")%>' OnCommand="LBtRecepcionar_Command" runat="server" Text="R" CssClass="btn btn-primary"></asp:LinkButton>
                                    <asp:LinkButton ID="LBtnProrroga" CommandArgument='<%#Eval("idPrestamo")%>' runat="server" Text= "P" CssClass="btn btn-success"></asp:LinkButton>
                                    
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>--%>
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
                    
                </div>
           </div>
</asp:Content>
