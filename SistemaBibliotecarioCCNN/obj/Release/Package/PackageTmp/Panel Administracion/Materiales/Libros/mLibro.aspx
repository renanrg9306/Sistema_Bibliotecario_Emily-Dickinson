<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="mLibro.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Libros.mLibro" %>
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
                            <label>Tittulo del Libro:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtNombreMaterial" Enabled="false" onKeyPress="ucwords(this)"  CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                  
                           </div>

                        <div class="col-md-3">
                            <label>Descripción:<label class="AstericoColorTamanio">*</label></label>
                            <asp:TextBox ID="TxtDescripcion" onKeyPress="ucwords(this)" CssClass="form-control" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="ValidarDescripcion" ControlToValidate="TxtDescripcion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateLibro" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-2">
                            <label>Condición:<label class="AstericoColorTamanio">*</label></label>
                            <asp:DropDownList ID="DdlCondicion"  CssClass="form-control" runat="server">
                                    <asp:ListItem  Value="Bueno">Bueno</asp:ListItem>
                                    <asp:ListItem Value="Dañado">Dañado</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-3">
                            <label>Clasificación:<label class="AstericoColorTamanio">*</label></label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalClasificacion"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlClasificacion" OnPreRender="DdlClasificacion_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                        <br />
                    <div class="row">

                        <div class="col-md-4">
                            <label>Registro Entrada:<label class="AstericoColorTamanio">*</label></label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalRegEntrada"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlRegEntrada" OnPreRender="DdlRegEntrada_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <label>Autor:<label class="AstericoColorTamanio">*</label></label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalAutor"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlAutor" OnPreRender="DdlAutor_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-1">
                            <label>CD:<label class="AstericoColorTamanio">*</label></label>
                             <asp:DropDownList ID="DdlCD" OnPreRender="DdlCD_PreRender"  CssClass="form-control" runat="server">
                                 <asp:ListItem  Value="True">Si</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                             </asp:DropDownList>

                        </div>
                          <div class="col-md-2">
                            <label>ISBN:<label class="AstericoColorTamanio">*</label></label>
                            <asp:TextBox ID="TxtISBN" onKeyPress="toUpper(this)" CssClass="form-control" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarISBN" ControlToValidate="TxtISBN" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateLibro" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-2">
                            <label>Edición:<label class="AstericoColorTamanio">*</label></label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModal"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlEdicion" OnPreRender="DdlEdicion_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        
                    </div>
                    <br/>
                    <div class="row">                 
                        <div class="col-md-3">
                             <label>Editorial:<label class="AstericoColorTamanio">*</label></label>
                            <div class="input-group">
                                <span class="input-group-addon"><a data-toggle="modal" href="#myModalEditorial"><i class="fa fa-plus"></i></a></span>
                                <asp:DropDownList ID="DdlEditorial" OnPreRender="DdlEditorial_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                       

                         <div class="col-md-2">
                              <label>Cantidad:<label class="AstericoColorTamanio">*</label></label>
                            <asp:TextBox ID="TxtCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarCantidad" ControlToValidate="TxtCantidad" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateLibro" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                        </div>

                         <div class="col-sm-4">
                                <div class="input-group">
                                     <label>Imagen:<label class="AstericoColorTamanio">*</label></label>
                                    <asp:FileUpload ID="ImgLibro" accept=".png,.jgp,.jpeg" runat="server" />
                                    </div>       
                            </div>

                         <div class="col-md-3 Botones">
                     
                            <asp:Button ID="BtnActializarLibro" ValidationGroup="FormUpdateLibro" OnClick="BtnActializarLibro_Click"  CssClass="btn btn-info" runat="server" Text="Actualizar" />
                            <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click"  CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                        </div>
                               
                        </div>
                    
                    <asp:Label ID="LbIdMateiral" runat="server" Visible="false" Text=""></asp:Label>
                    <br/>
                     <label class="CamposObligatorios">(*) Campos Obligatorios</label>
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
                            <label>Edición:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtEdicion" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ValidarEdicion" ControlToValidate="TxtEdicion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalEdicion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                             </div>
                     <div class="form-group">
                         <label>Año:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtAnio" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ValidarAnioEdicion" ControlToValidate="TxtAnio" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalEdicion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                                    <asp:Label ID="LbCampos" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label></div>
                                
                        <div class="modal-footer">
                            <asp:Button ID="btnGuardarEdicionAtajo" ValidationGroup="ModalEdicion" OnClick="btnGuardarEdicionAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                            <label>Clasificación:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtClasificacion" AutoComplete="off" onKeyPress="toUpper(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarClasificacion" ControlToValidate="TxtClasificacion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalClasificacion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                             </div>
                     <div class="form-group">
                         <label>Descripción:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtDescripcionClasificacion" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                                    <asp:Label ID="Label2" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label></div>
                                
                        <div class="modal-footer">
                            <asp:Button ID="BtnGuardarClasificacionAtajo" ValidationGroup="ModalClasificacion" OnClick="BtnGuardarClasificacionAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                            <label>Origen:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtOrigen" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarOrigen" ControlToValidate="TxtOrigen" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalOrigen" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                             </div>
                                <asp:Label ID="Label3" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label></div>
                     
                        <div class="modal-footer">
                            
                            <asp:Button ID="BtnGuardarRegEntradaAtajo" ValidationGroup="ModalOrigen" OnClick="BtnGuardarRegEntradaAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                            <label>Nombre Autor:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtNombreAutor" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarNombreAutor" ControlToValidate="TxtNombreAutor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalAutor" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>

                    <div class="form-group">
                            <label>Apellido Autor:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtApellidoAutor" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValidarApellidoAutor" ControlToValidate="TxtApellidoAutor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalAutor" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>              
                    </div>
                                 <asp:Label ID="Label4" runat="server" CssClass="AstericoColorTamanio" Text="(*) Campos Obligatorios"></asp:Label></div>
                        <div class="modal-footer">
                      <%--      <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarAutorAtajo" ValidationGroup="ModalAutor" OnClick="BtnGuardarAutorAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                            <label>Editorial:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtEditorial" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarEditorial" ControlToValidate="TxtEditorial" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalEditorial" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>          
                        </div>
                             <asp:Label ID="Label5" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label></div>
                        <div class="modal-footer">
                           <%-- <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarEditorialAtajo" ValidationGroup="ModalEditorial" OnClick="BtnGuardarEditorialAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>

</asp:Content>
