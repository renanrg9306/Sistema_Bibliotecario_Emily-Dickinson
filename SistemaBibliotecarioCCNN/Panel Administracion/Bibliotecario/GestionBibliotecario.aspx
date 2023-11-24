<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="GestionBibliotecario.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.GestionBibliotecario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function checkDelete(aElement,CantidadPrestamos) {
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

            if ((objConfirm.value) && CantidadPrestamos ==0) {

                $.ajax({
                    type: "POST",
                    url: "GestionBibliotecario.aspx/DeleteBibliotecario",
                    data: JSON.stringify({ IdEmpleado: aElement.attributes.title.value }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        window.location.reload();
                    }
                });

                swal("Hecho!", "El registro ha sido eliminado!", "success");

            } else if (objConfirm.value && CantidadPrestamos > 0)
                {
                swal("Error!", "Este usuario no puede ser eliminado!,ha realizado prestamos,recepcione los prestamos e intente nuevamente:)", "error");
                }
            else {
                swal("Cancelado", "El registro no se eliminó:)", "error");
            }
        });

        return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="margin-left:15px;">
                <h2>Gestión de Bibliotecarios</h2>
            </div>

             <div class="col-md-6" style="margin-left:15px;">
                <asp:LinkButton ID="LinkBtnNnuevo" runat="server" Text="<i class='fa fa-user-plus'></i> Nuevo" CssClass="btn btn-primary" OnClick="LinkBtnNnuevo_Click"></asp:LinkButton>
            </div>
            
            <div class="col-md-6" style="margin-left: 15px;">
                <br/>
                 <asp:Label ID="Label1" style="color:red;" Font-Bold="true" runat="server" Text="M: Modificar Registro."></asp:Label><br/>
                 <asp:Label ID="Label2" style="color:red;" Font-Bold="true" runat="server" Text="E: Eliminar Registro."></asp:Label>
               
            </div>  
        </div>

        
         <br/>
                <div class="table-responsive col-md-12" >
                    <asp:GridView ID="GridVBibliotecario" OnRowDataBound="GridVBibliotecario_RowDataBound" OnPreRender="GridVBibliotecario_PreRender" runat="server" CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="No" HeaderText="No" />
                            <asp:BoundField DataField="idBibiotecario" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="idEmpleado" HeaderText="IDE" Visible="false" />
                            <asp:BoundField DataField="Nombre Completo" HeaderText="Nombre Completo" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Cédula" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono"/>
                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                            <asp:BoundField DataField="CodUsuario" HeaderText="Codigo Usuario" ReadOnly="True" SortExpression="Estado" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" SortExpression="Fecha" />
                            <asp:BoundField DataField="CantidadPrestamosRealizados" HeaderText="Prestamos" SortExpression="FechaI"/>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Acciones">
                                <ItemTemplate>


                                    <asp:LinkButton ID="LnkBtnActualizar" CommandArgument='<%#Eval("idBibiotecario")%>' OnCommand="LnkBtnActualizar_Command" runat="server" Text="<i class='glyphicon glyphicon-pencil'></i>M" CssClass="btn btn-success"></asp:LinkButton>
                                    <asp:LinkButton ID="LnkBtnEliminar" OnClientClick='<%# "return checkDelete(this," +Eval("CantidadPrestamosRealizados") + " );" %>' ToolTip='<%#Eval("idEmpleado")%>'  runat="server" Text="<i class='fa fa-trash'></i> E" CssClass="btn btn-danger"></asp:LinkButton>


                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
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
                    <asp:Label ID="LbIdBibliotecario" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LbIdEmpleado" runat="server" Text=""></asp:Label>
                </div> 
        </div>
     <%--   </div>--%>
</asp:Content>
