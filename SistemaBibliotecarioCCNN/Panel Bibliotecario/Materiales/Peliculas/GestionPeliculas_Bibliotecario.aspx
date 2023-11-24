<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="GestionPeliculas_Bibliotecario.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Peliculas.GestionPeliculas_Bibliotecario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function MostrarModalImagen() {
             $('#ModalImagenMaterial').modal();
         }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="margin-left: 15px;">
                <h2>Gestión de Peliculas</h2>
            </div>
             <div class="col-md-6" style="margin-left: 15px;">
                <asp:LinkButton ID="LnkBtnNuevo" OnClick="LnkBtnNuevo_Click" Text="<i class='fa fa-user-plus'></i> Nuevo" CssClass="btn btn-primary" runat="server"></asp:LinkButton>
                 <div class="btn-group">
                   <asp:LinkButton ID="LnkBtnReportes" CssClass="btn btn-success dropdown-toggle" data-toggle="dropdown" runat="server">Reportes<span class="caret"></span></asp:LinkButton>
                   <ul class="dropdown-menu" role="menu">
                       <li><a href="WebFormRptPe/RptAllPeliculas.aspx">Listar Todos</a></li>
                       <li><a href="WebFormRptPe/RptPeliculasDis.aspx">Listar Disponibles</a></li>
                       <li><a href="WebFormRptPe/RptPeliculasV.aspx">Listar por Protagoninsta, Clasificación</a></li>
                       
                   </ul>
               </div>
            </div>
          
        </div>
          <br />
            <div class="table-responsive col-md-12">
              
                    <asp:GridView ID="GdvShowPeliculas" runat="server" OnRowDataBound="GdvShowPeliculas_RowDataBound" OnPreRender="GdvShowPeliculas_PreRender"  CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No"/>
                            <asp:BoundField DataField="idPelicula" HeaderText="IDAB"  Visible="false"/>
                            <asp:BoundField DataField="idMaterial" HeaderText="IDM" Visible="false"/>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                            <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                            <asp:BoundField DataField="Genero" HeaderText="Genero" />
                            <asp:BoundField DataField="Protagonista" HeaderText="Protagonista" />
                            <asp:BoundField DataField="Director" HeaderText="Director" />
                            <asp:BoundField DataField="Duracion" HeaderText="Duracion" />
                            <asp:BoundField DataField="Subtitulo" HeaderText="Subtitulos" />
                            <asp:BoundField DataField="Anio" HeaderText="Año" />                           
                            <asp:BoundField DataField="Origen" HeaderText="Origen"/>                    
                            <asp:BoundField DataField="Fecha_Recep" HeaderText="Fecha Recepción"/>                        
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                              <asp:BoundField DataField="Prestado" HeaderText="Prestado"/>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnModificar" OnCommand="LnkBtnModificar_Command"  CommandArgument='<%#Eval("idPelicula")%>' CssClass="btn btn-success" Text="<i class='glyphicon glyphicon-pencil'></i>M" runat="server"></asp:LinkButton>
                                     <asp:LinkButton ID="LnkBtnVerImg" CommandArgument='<%#Eval("idMaterial")%>' OnCommand="LnkBtnVerImg_Command" CssClass="btn btn-primary" runat="server" Text="<i class='glyphicon glyphicon-picture'></i>I"></asp:LinkButton>
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
          </div>

     <%--  MOSTRAR IMAGEN --%>
    <div class="modal fade in" role="dialog" id="ModalImagenMaterial" tabindex="-1" aria-labelledby="ModalVerImagenLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="ModalVerImagenlLabel">Portada</h4>
                    <asp:Label ID="LbMaterial" runat="server"></asp:Label>

                </div>
                <div class="modal-body">
                    <div class="container">
                        <asp:Image ID="ImagenAB" ImageAlign="Middle" Width="750px" Height="500px" class="img-fluid img-thumbnail" alt="Responsive image" runat="server" />
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
