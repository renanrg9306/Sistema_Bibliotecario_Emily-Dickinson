<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="GestionPrestamos.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Prestamos.Domicilio.GestionPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function checkRecepcionar(aElement) {
        swal({

            title: "Desea recepcionar este prestamo?",
            text: "Una vez recepcionado se actulizara la estado del material!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Si, Recepcionar!',
            cancelButtonText: "No, Cancelar!",
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function (objConfirm) {

            if (objConfirm.value) {

                $.ajax({
                    type: "POST",
                    url: "GestionPrestamos.aspx/RecepcionarPrestamo",
                    data: JSON.stringify({ IdEntrega_Prestamo: aElement.attributes.title.value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        window.location.reload();
                    }
                });

                swal("Hecho!", "El material fue recepcionado, verifique su estado!", "success");

            } else {
                swal("Cancelado", "El material no fue recepcionado:)", "error");

            }

        });

        return false;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="margin-left: 15px;">
                <h2>Gestión de Prestamos</h2>
            </div>
            <div class="col-md-12" style="margin-left: 15px;">
                <asp:LinkButton ID="LinkBtnNLibro" OnClick="LinkBtnNLibro_Click" runat="server" Text="<i></i> Libro" CssClass="btn btn-primary"></asp:LinkButton>
                <asp:LinkButton ID="LinkBtnNAB" OnClick="LinkBtnNAB_Click" runat="server" Text="<i></i> AudioBook" CssClass="btn btn-primary"></asp:LinkButton>
                <asp:LinkButton ID="LinkBtnNRevista" OnClick="LinkBtnNRevista_Click" runat="server" Text="<i></i> Revista" CssClass="btn btn-primary"></asp:LinkButton>
                <asp:LinkButton ID="LinkBtnNPelicula" OnClick="LinkBtnNPelicula_Click" runat="server" Text="<i></i> Pelicula" CssClass="btn btn-primary"></asp:LinkButton>
                
                 <div class="btn-group">
                   <asp:LinkButton ID="LnkBtnReportes" CssClass="btn btn-success dropdown-toggle" data-toggle="dropdown" runat="server">Reportes<span class="caret"></span></asp:LinkButton>
                   <ul class="dropdown-menu" role="menu">
                       <li><a href="WebFormRpt/RptLiPrestamosRealizados.aspx">Listar Prestamos Realizados</a></li>
                       <li><a href="WebFormRpt/RptListarPrestamosRecepcionados.aspx">Listar Prestamos Recepcionados</a></li>
                       <li><a href="WebFormRpt/RptListarHistorialMaterial.aspx">Listar Prestamos de un Material</a></li>
                       <li><a href="WebFormRpt/RptHistorialPrestamoVisitante.aspx">Listar Prestamos de un Visitante</a></li>
                       <li><a href="WebFormRpt/RptPreProrroga.aspx">Listar Prestamos con Prrorroga</a></li>

                       
                   </ul>
               </div>
            
            
            </div>
            <br />
            <div class="col-md-12" style="margin-left: 15px;">
                <asp:Label ID="Label1" style="color:red;" Font-Bold="true" runat="server" Text="R: Recepcionar Prestamo."></asp:Label><br />
                <asp:Label ID="Label2" style="color:red;" Font-Bold="true" runat="server" Text="P: Dar Prorroga."></asp:Label>
            </div>
        </div>

        <div class="table-responsive col-md-12">
            <asp:GridView ID="GridVPrestamos" runat="server" OnRowDataBound="GridVPrestamos_RowDataBound" CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" OnPreRender="GridVPrestamos_PreRender" BorderStyle="None" BorderWidth="1px" CellPadding="1" Font-Size="Small">

                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No" />
                    <asp:BoundField DataField="idPrestamo" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="idEntrega_Prestamo" HeaderText="IDE" Visible="false" />
                    <asp:BoundField DataField="Nombre_del_Material" HeaderText="Material" />
                    <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                    <asp:BoundField DataField="Nombre_Visitante" HeaderText="Visitante" />
                    <asp:BoundField DataField="Program" HeaderText="Program" />
                    <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
                    <asp:BoundField DataField="Prestado_por" HeaderText="Prestado por" />
                    <asp:BoundField DataField="Fecha_del_Prestamo" HeaderText="Fecha del Prestamo" />
                    <asp:BoundField DataField="Fecha_de_Devolucion" HeaderText="Fecha Devolucion" />
                    <asp:BoundField DataField="Primera_Prorroga" HeaderText="Prorroga1" />
                    <asp:BoundField DataField="Segunda_Prorroga" HeaderText="Prorroga2" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Prestada" />
                    <asp:BoundField DataField="TipoPrestamo" HeaderText="Tipo" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton ID="LBtRecepcionar" OnClientClick="return checkRecepcionar(this)" ToolTip='<%#Eval("idEntrega_Prestamo")%>' runat="server" Text="R" CssClass="btn btn-primary confirmbutton"></asp:LinkButton>
                            <asp:LinkButton ID="LBtnProrroga" CommandArgument='<%#Eval("idEntrega_Prestamo")%>' OnCommand="LBtnProrroga_Command" runat="server" Text="P" CssClass="btn btn-success"></asp:LinkButton>

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
            <asp:Label ID="LbIdPrestamo" runat="server" Visible="True" Text=""></asp:Label>
            <asp:Label ID="LbIdEntrega_Prestamo" runat="server" Visible="True" Text=""></asp:Label>
            <asp:Label ID="ConfirmMaRecep" runat="server" Text=""></asp:Label>
        </div>
        <asp:Label ID="LbUser" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
