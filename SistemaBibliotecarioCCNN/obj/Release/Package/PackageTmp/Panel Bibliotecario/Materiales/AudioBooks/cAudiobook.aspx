<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="cAudiobook.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Materiales.AudioBooks.cAudiobook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-10">
                <div class="panel panel-primary">
                    <div class="panel-heading heightheader">
                        <h3>Registro de AudioBook</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Titulo Audiobook:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtMaterialNombre" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarNombreMaterial" ControlToValidate="TxtMaterialNombre" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateAB" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Registro de Entrada:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalRegEntrada"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlRegEntrada" OnPreRender="DdlRegEntrada_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="input-group">
                                     <label>Clasificación:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalClasificacion"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlClasificacion" OnPreRender="DdlClasificacion_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="input-group">
                                     <label>Autor:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalAutor"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlAutor" OnPreRender="DdlAutor_PreRender" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>


                        </div>
                        <br />
                        <div class="row">

                            <div class="col-sm-3">
                                <div class="input-group">
                                    <label>Condición:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:DropDownList ID="DdlCondicion" CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="Bueno">Bueno</asp:ListItem>
                                        <asp:ListItem Value="Dañado">Dañado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <div class="input-group">
                                    <label>Descripción:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtDescripcion" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarDescripcionAB" ControlToValidate="TxtDescripcion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateAB" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-sm-3">
                                <div class="input-group">
                                     <label>Componentes:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtComponentes" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarComponentes" ControlToValidate="TxtComponentes" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateAB" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-2">
                                <div class="input-group">
                                     <label>Cantidad:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarCantidadAB" ControlToValidate="TxtCantidad" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateAB" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-4">
                                 <div class="input-group">
                                     <label>Imagen:<label class="AstericoColorTamanio">*</label></label>
                                    <asp:FileUpload ID="ImgAudioBook" accept=".png,.jgp,.jpeg" runat="server" />
                                    <asp:RequiredFieldValidator ID="ValidarImagen" ControlToValidate="ImgAudioBook" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateAB" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>
                            </div>
                            <div class="col-sm-3 Botones" style="margin-left:10px;">
                                <asp:Button ID="BtnGuardar" ValidationGroup="FormCreateAB" OnClick="BtnGuardar_Click" CssClass="btn btn-info" runat="server" Text="Guardar" />
                                <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                <asp:Label ID="LbFecha" Visible="false" runat="server" Text=""></asp:Label>
                            </div>
                            <%--    <div class="col-md-2"></div>--%>
                            
                        </div>
                        <asp:Label ID="LbCampos" CssClass="CamposObligatorios"  runat="server"  Text="(*) Campos Obligatorios"></asp:Label>

                    </div>
                </div>



            </div>
            <div class="col-md-1"></div>
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
                        <asp:TextBox ID="TxtOrigen" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidarOrigen" ControlToValidate="TxtOrigen" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalOrigen" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator> 
                            </div>
                                <asp:Label ID="Label1" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarRegEntradaAtajo" ValidationGroup="ModalOrigen" OnClick="BtnGuardarRegEntradaAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                    <h4 class="modal-title" id="myModaClasificacionlLabel">Registro Edicion</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Clasificación:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtClasificacion" onKeyPress="toUpper(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidarClasificacion" ControlToValidate="TxtClasificacion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalClasificacion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>
                     <div class="form-group">
                         <label>Descripción</label>
                        <asp:TextBox ID="TxtDescripcionClasificacion" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                                <asp:Label ID="Label2" runat="server" style="color:red;" Font-Bold="true" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarClasificacionAtajo" ValidationGroup="ModalClasificacion" OnClick="BtnGuardarClasificacionAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                    <h4 class="modal-title" id="myModaAutorLabel">Registro de Entrada</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Nombre Autor:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtNombreAutor" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValidarAutorNombre" ControlToValidate="TxtNombreAutor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalAutor" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator> 
                            </div>

                    <div class="form-group">
                            <label>Apellido Autor:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtApellidoAutor" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValidarAutorApellido" ControlToValidate="TxtApellidoAutor" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalAutor" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator> 
                             </div>
                                    <asp:Label ID="Label3" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                           <%-- <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarAutorAtajo" ValidationGroup="ModalAutor" OnClick="BtnGuardarAutorAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
