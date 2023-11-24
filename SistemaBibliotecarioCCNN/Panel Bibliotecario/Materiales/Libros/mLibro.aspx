<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="mLibro.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.Libros.mLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading heightheader"><h3>Actualizar Datos Libro</h3></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="LlbNombreMaterial" Enabled="false" Font-Bold="true" runat="server" Text="Nombre del Material:"></asp:Label>
                                <asp:TextBox ID="TxtNombreMaterial" onKeyPress="ucwords(this)"  CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <asp:Label ID="LblDescripcion" AutoComplete="off" Font-Bold="true" runat="server" Text="Descripcion:"></asp:Label>
                            <asp:TextBox ID="TxtDescripcion" onKeyPress="ucwords(this)" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="LblCondicion" Font-Bold="true" runat="server" Text="Condicion:"></asp:Label>
                            <asp:DropDownList ID="DdlCondicion"  CssClass="form-control" runat="server">
                                    <asp:ListItem  Value="Bueno">Bueno</asp:ListItem>
                                    <asp:ListItem Value="Dañado">Dañado</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-3">
                            <asp:Label ID="Clasificacion" Font-Bold="true" runat="server" Text="Clasificacion:"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalClasificacion"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlClasificacion" OnPreRender="DdlClasificacion_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                        <br />
                    <div class="row">

                        <div class="col-md-4">
                            <asp:Label ID="LbRegEntrada" Font-Bold="true" runat="server" Text="Registro Entrada:"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalRegEntrada"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlRegEntrada" OnPreRender="DdlRegEntrada_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <asp:Label ID="LbAutor" Font-Bold="true" runat="server" Text="Autor:"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalAutor"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlAutor" OnPreRender="DdlAutor_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="LbCD" Font-Bold="true" runat="server" Text="CD:"></asp:Label>
                             <asp:DropDownList ID="DdlCD" OnPreRender="DdlCD_PreRender"  CssClass="form-control" runat="server">
                                 <asp:ListItem  Value="True">Si</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                             </asp:DropDownList>

                        </div>
                          <div class="col-md-2">
                            <asp:Label ID="LbISBN" Font-Bold="true" runat="server" Text="ISBN:"></asp:Label>
                            <asp:TextBox ID="TxtISBN" onKeyPress="toUpper(this)" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Edición:"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModal"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlEdicion" OnPreRender="DdlEdicion_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        
                    </div>
                    <br/>
                    <div class="row">                 
                        <div class="col-md-3">
                            <asp:Label ID="LbEditorial" Font-Bold="true" runat="server" Text="Editorial:"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalEditorial"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlEditorial" OnPreRender="DdlEditorial_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                       

                         <div class="col-md-1">
                            <asp:Label ID="LbCantidad" Font-Bold="true" runat="server" Text="Cantidad:"></asp:Label>
                            <asp:TextBox ID="TxtCantidad" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                         <div class="col-sm-4">
                                <div class="input-group">
                                     <label>Imagen:<label class="AstericoColorTamanio"></label></label>
                                    <asp:FileUpload ID="ImgLibro" accept=".png,.jgp,.jpeg" runat="server" />
                                    </div>       
                            </div>

                         <div class="col-md-3">
                             <br/>
                            <asp:Button ID="BtnActializarLibro" OnClick="BtnActializarLibro_Click"  CssClass="btn btn-info" runat="server" Text="Actualizar" />
                            <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click"  CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                        </div>

                        </div>
                    
                    <asp:Label ID="LbIdMateiral" runat="server" Visible="false" Text=""></asp:Label>

                </div>
            </div>
        </div>


     <%--PRIMER ATAJO PARA LA EDICION MODAL --%>

    <div class="modal fade in" role="dialog" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel">Registro Edición</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Edición</label>
                        <asp:TextBox ID="TxtEdicion" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                     <div class="form-group">
                         <label>Año</label>
                        <asp:TextBox ID="TxtAnio" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnGuardarEdicionAtajo" OnClick="btnGuardarEdicionAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

 <%--   SEGUNDA ATAJO PARA LA CLASIFICACION --%>
    <div class="modal fade in" role="dialog" id="myModalClasificacion" tabindex="-1" aria-labelledby="myModalClasificacionLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaClasificacionlLabel">Registro Clasificación</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Clasificación</label>
                        <asp:TextBox ID="TxtClasificacion" AutoComplete="off" onKeyPress="toUpper(this)" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                     <div class="form-group">
                         <label>Descripción</label>
                        <asp:TextBox ID="TxtDescripcionClasificacion" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <asp:Button ID="BtnGuardarClasificacionAtajo" OnClick="BtnGuardarClasificacionAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>


     <%--   TERCER ATAJO PARA REGISTRO ENTRADA --%>
    <div class="modal fade in" role="dialog" id="myModalRegEntrada" tabindex="-1" aria-labelledby="myModalRegEntradaLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaRegEntradalLabel">Registro de Entrada</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Origen</label>
                        <asp:TextBox ID="TxtOrigen" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                     
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <asp:Button ID="BtnGuardarRegEntradaAtajo" OnClick="BtnGuardarRegEntradaAtajo_Click"   CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>
      <%--   TERCER ATAJO PARA REGISTRO AUTOR --%>
     <div class="modal fade in" role="dialog" id="myModalAutor" tabindex="-1" aria-labelledby="myModalAutorLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaAutorLabel">Registro de Autor</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Nombre Autor</label>
                        <asp:TextBox ID="TxtNombreAutor" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>

                    <div class="form-group">
                            <label>Apellido Autor</label>
                        <asp:TextBox ID="TxtApellidoAutor" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                     
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <asp:Button ID="BtnGuardarAutorAtajo" OnClick="BtnGuardarAutorAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>
      <%--   TERCER ATAJO PARA REGISTRO EDITORIAL --%>
    <div class="modal fade in" role="dialog" id="myModalEditorial" tabindex="-1" aria-labelledby="myModalEditorialLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaEditorialLabel">Registro de Editorial</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Editorial</label>
                        <asp:TextBox ID="TxtEditorial" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>
                     
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <asp:Button ID="BtnGuardarEditorialAtajo" OnClick="BtnGuardarEditorialAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
