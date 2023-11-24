<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Visitante/Visitante.Master" AutoEventWireup="true" CodeBehind="PrestamosEntregados.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Visitante.Materiales.PrestamosEntregados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="margin-left: 15px;">
                <h2>Prestamos Entregados</h2>
            </div>
        </div>
        <br />
        <div class="table-responsive col-md-12">
            <asp:GridView ID="GdvPrestamosEntregados" runat="server" OnRowDataBound="GdvPrestamosEntregados_RowDataBound" OnPreRender="GdvPrestamosEntregados_PreRender" CssClass="table-condensed table-bordered gvdatatable" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Small">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Material"/>
                   
                    <asp:BoundField DataField="Descrpcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Visitante" HeaderText="Visitante" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"  />
                    <asp:BoundField DataField="Fecha Devolucion" HeaderText="Fecha Devolucion" />
                    <asp:BoundField DataField="Primera Prorroga" HeaderText="Primera Prorroga" />
                    <asp:BoundField DataField="Segunda Prorroga" HeaderText="Segundo Prorroga" />
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
</asp:Content>
