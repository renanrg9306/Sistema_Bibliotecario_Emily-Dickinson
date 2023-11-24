<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Visitante/Visitante.Master" AutoEventWireup="true" CodeBehind="AudioBooks.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Visitante.Materiales.AudioBooks" %>
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
                <div class="col-md-12" style="margin-left:15px;">
                    <h2>AudioBooks Disponibles</h2></div>
         </div>
        <br/>
            <div class="table-responsive col-md-12">
                    <asp:GridView ID="GdvShowAB" runat="server" OnRowDataBound="GdvShowAB_RowDataBound" CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False" OnPreRender="GdvShowAB_PreRender" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No"/>
                            <asp:BoundField DataField="idAudioBook" HeaderText="IDAB"  Visible="false"/>
                            <asp:BoundField DataField="idMaterial" HeaderText="IDM" Visible="false"/>
                            <asp:BoundField DataField="Nombre" HeaderText="Titulo AudioBook"/>
                            <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                            <asp:BoundField DataField="Nombre_Autor" HeaderText="Nombre Autor" />   
                            <asp:BoundField DataField="Descrpcion" HeaderText="Descripcion"/>
                            <asp:BoundField DataField="Componentes" HeaderText="Componentes"/>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                            <asp:BoundField DataField="Prestado" HeaderText="Prestado"/>
                            <asp:BoundField DataField="Reservado" HeaderText="Reservado"/>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkReservar" runat="server" CommandArgument='<%#Eval("idMaterial")%>'  OnCommand="LnkReservar_Command" CssClass="btn btn-success" Text="<i class='glyphicon glyphicon-pencil'></i>R"></asp:LinkButton>
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
          
 <%--    </div>--%>

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
                                <asp:Image ID="ImagenAB" ImageAlign="Middle" Width="750px" Height="500px"  class="img-fluid img-thumbnail" alt="Responsive image" runat="server" />
                             </div>
                        <div class="modal-footer">
                           
                        </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
