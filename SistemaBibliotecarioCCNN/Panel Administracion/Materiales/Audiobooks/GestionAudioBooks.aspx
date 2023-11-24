<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="GestionAudioBooks.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.GestionAudioBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function checkDelete(aElement,CantidadPrestado) {
            swal({

                title: "Desea eliminar este registro?",
                text: "Una vez eliminado, no podrá ser restaurado!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Si!',
                cancelButtonText: "No!",
                closeOnConfirm: false,
                closeOnCancel: false

            }).then(function (objConfirm) {

                if ((objConfirm.value) && CantidadPrestado == 0) {

                    $.ajax({
                        type: "POST",
                        url: "GestionAudioBooks.aspx/DeleteAudiobook",
                        data: JSON.stringify({ IdMaterial: aElement.attributes.title.value }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            window.location.reload();
                        }
                    });

                    swal("Hecho!", "El registro ha sido eliminado!", "success");

                } else {
                    if (objConfirm.value && CantidadPrestado > 0) {
                        swal("Error!", "Este registro de material se encuentra en prestamo, recepcione e intente nuevamente:)", "error");

                    } else {
                        swal("Cancelado", "El registro no se eliminó:)", "error");
                    }
                }

            });

            return false;
        }


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
                    <h2>Gestion de AudioBooks</h2></div>
              
           <div class="col-md-12" style="margin-left: 15px;">
               <asp:LinkButton ID="LnkBtnNuevo" OnClick="LnkBtnNuevo_Click" Text="<i class='fa fa-plus'></i> Nuevo" CssClass="btn btn-primary" runat="server"></asp:LinkButton>

               <div class="btn-group">
                   <asp:LinkButton ID="LnkBtnReportes" CssClass="btn btn-success dropdown-toggle" data-toggle="dropdown" runat="server">Reportes<span class="caret"></span></asp:LinkButton>
                   <ul class="dropdown-menu" role="menu">
                       <li><a href="WebFormRpt/RptLAu.aspx">Listar Todos</a></li>
                       <li><a href="WebFormRpt/RptListarAuDis.aspx">Listar Disponibles</a></li>
                        <li><a href="WebFormRpt/RptABxAu_Cla_Both.aspx">Listar por Autor, Clasificacion</a></li>

                      
                   </ul>
               </div>

           </div>

            
            
        </div>
         <div class="col-md-6" style="margin-left: 15px;">
                <br/>
                 <asp:Label ID="Label1" style="color:red;" Font-Bold="true" runat="server" Text="M: Modificar Registro."></asp:Label><br/>
                 <asp:Label ID="Label2" style="color:red;" Font-Bold="true" runat="server" Text="E: Eliminar Registro."></asp:Label><br/>
                 <asp:Label ID="Label3" style="color:red;" Font-Bold="true" runat="server" Text="I: Ver Imagen de Portada."></asp:Label>

               
            </div>  
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
                            <asp:BoundField DataField="Nombre_Autor" HeaderText="Autor" />
                            <asp:BoundField DataField="Origen" HeaderText="Origen"/>
                            <asp:BoundField DataField="Descrpcion" HeaderText="Descripcion"/>
                            <asp:BoundField DataField="Componentes" HeaderText="Componentes"/>
          <%--                  <asp:BoundField DataField="Fecha_Recep" HeaderText="Fecha Recepción"/>--%>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                            <asp:BoundField DataField="Prestado" HeaderText="Prestado"/>
                            <asp:BoundField DataField="Reservado" HeaderText="Reservado"/>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnModificar" runat="server" CommandArgument='<%#Eval("idAudioBook")%>' OnCommand="LnkBtnModificar_Command" CssClass="btn btn-success" Text="<i class='glyphicon glyphicon-pencil'></i>M"></asp:LinkButton>
                                    <asp:LinkButton ID="LnkBtnEliminar" OnClientClick='<%# "return checkDelete(this," +Eval("Prestado") + " );" %>' ToolTip='<%#Eval("idMaterial")%>' CssClass="btn btn-danger" Text="<i class='fa fa-trash'></i>E" runat="server"></asp:LinkButton>
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
                                <asp:Image ID="ImagenAB" ImageAlign="Middle" Width="750px" Height="500px"  class="img-fluid img-thumbnail" alt="Responsive image" runat="server" />
                             </div>
                        <div class="modal-footer">
                           
                        </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
