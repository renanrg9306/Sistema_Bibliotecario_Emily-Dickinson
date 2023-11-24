<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cPelicula.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.Materiales.Peliculas.cPelicula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br/>
    <div class="container">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel panel-primary">
                    <div class="panel-heading heightheader">
                        <h3>Registro de Peliculas</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="input-group">
                                    <label>Titulo Pelicula:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtMaterialNombre" AutoComplete="off" onKeyPress="ucwords(this)" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarNombrePelicula" ControlToValidate="TxtMaterialNombre" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Registro de Entrada:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalRegEntrada"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlRegEntrada" OnPreRender="DdlRegEntrada_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Clasificación:<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalClasificacion"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlClasificacion" OnPreRender="DdlClasificacion_PreRender" CssClass="form-control Selector" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <label>Subtitulada*<label class="AstericoColorTamanio">*</label></label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:DropDownList ID="DdlSubtitulo" CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="True">Si</asp:ListItem>
                                        <asp:ListItem Value="False">No</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <br />

                        <div class="row">

                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Protagonista</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalProtagonista"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlProtagonista" OnPreRender="DdlProtagonista_PreRender" runat="server" CssClass="form-control Selector"></asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Director</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalDirector"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlDirector" OnPreRender="DdlDirector_PreRender" runat="server" CssClass="form-control Selector"></asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Genero</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalGenero"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlGenero" OnPreRender="DdlGenero_PreRender" runat="server" CssClass="form-control Selector"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <label>Condición</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:DropDownList ID="DdlCondicion" CssClass="form-control" runat="server">
                                        <asp:ListItem Selected="True" Value="Bueno">Bueno</asp:ListItem>
                                        <asp:ListItem Value="Dañado">Dañado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <br />
                        <div class="row">

                            <div class="col-md-4">
                                <div class="input-group">
                                    <label>Sinopsis</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtSinopsis" AutoComplete="off" onKeyPress="ucwords(this)" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-2">
                                <div class="input-group">
                                    <label>Descripcion:*</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtDescripcion" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarDescripcion" ControlToValidate="TxtDescripcion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>



                            <div class="col-md-2">
                                <div class="input-group">
                                    <label>Duracion:*</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtDuracion" TextMode="Time" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarDuracion" ControlToValidate="TxtDuracion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <div class="input-group">
                                    <label>Año:*</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtAnio" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarAnio" ControlToValidate="TxtAnio" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>


                            <div class="col-md-2">
                                <div class="input-group">
                                    <label>Cantidad:*</label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"></span>
                                    <asp:TextBox ID="TxtCantidad" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarCantidad" ControlToValidate="TxtCantidad" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                 <div class="input-group">
                                     <label>Imagen:<label class="AstericoColorTamanio">*</label></label>
                                    <asp:FileUpload ID="ImgPelicula" accept=".png,.jgp,.jpeg" runat="server" />
                                    <asp:RequiredFieldValidator ID="ValidarImagen" ControlToValidate="ImgPelicula" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreatePelicula" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>       
                            </div>
                            <div class="col-md-3 Botones"style="margin-left:10px;">
                                <asp:Button ID="BtnGuardarPelicula" ValidationGroup="FormCreatePelicula" OnClick="BtnGuardarPelicula_Click" CssClass="btn btn-info" runat="server" Text="Guardar" />
                                <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                <asp:Label ID="LbFecha" Visible="false" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                 <asp:Label ID="Label1" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </div>

     <%--   ATAJO PARA REGISTRO ENTRADA --%>
    <div class="modal fade in" role="dialog" id="myModalRegEntrada" tabindex="-1" aria-labelledby="myModalRegEntradaLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaRegEntradalLabel">Registro de Entrada</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Origen:<label class="AstericoColorTamanio"></label>*</label>
                        <asp:TextBox ID="TxtOrigen" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarOrigen" ControlToValidate="TxtOrigen" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalOrigen" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>
                                <asp:Label ID="Label2" CssClass="AstericoColorTamanio" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarRegEntradaAtajo" ValidationGroup="ModalOrigen" OnClick="BtnGuardarRegEntradaAtajo_Click"  CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

     <%-- ATAJO PARA LA CLASIFICACION --%>
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
                                    <asp:Label ID="Label3" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                                
                        <div class="modal-footer">
                          <%--  <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarClasificacionAtajo" ValidationGroup="ModalClasificacion" OnClick="BtnGuardarClasificacionAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

     <%--ATAJO PARA LA PROTAGONISTA --%>
    <div class="modal fade in" role="dialog" id="myModalProtagonista" tabindex="-1" aria-labelledby="myModalProtagonistaLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaProtagonistaLabel">Registro Protagonista</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Nombre Protagonista:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtNombreProtagnista" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ValidarNombreProtagonista" ControlToValidate="TxtNombreProtagnista" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalProtagonista" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>
                     <div class="form-group">
                         <label>Apellido Protagonista:<label class="AstericoColorTamanio"></label></label>
                        <asp:TextBox ID="TxtApellidoProtagonista" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ValidarApellidoProtagonista" ControlToValidate="TxtApellidoProtagonista" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalProtagonista" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>            
                     </div>

                                    <asp:Label ID="Label4" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarProtagnistaAtajo" ValidationGroup="ModalProtagonista" OnClick="BtnGuardarProtagnistaAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

      <%--ATAJO PARA LA DIRECTOR --%>
    <div class="modal fade in" role="dialog" id="myModalDirector" tabindex="-1" aria-labelledby="myModalDirectorLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalDirectorLabel">Registro Director</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Nombre Director:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtNombreDirector" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ValidarNombreDirector" ControlToValidate="TxtNombreDirector" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalDirector" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>      
                            </div>
                     <div class="form-group">
                         <label>Apellido Director:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtApellidoDirector" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="ValidarApellidoDirector" ControlToValidate="TxtApellidoDirector" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalDirector" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>             
                     </div>
                            <asp:Label ID="Label5" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardaDirectorAtajo" ValidationGroup="ModalDirector" OnClick="BtnGuardaDirectorAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

      <%--ATAJO PARA LA GENERO --%>
    <div class="modal fade in" role="dialog" id="myModalGenero" tabindex="-1" aria-labelledby="myModalGeneroLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalGeneroLabel">Registro de Genero</h4>
                </div>
                <div class="modal-body">
                        <div class="form-group">
                            <label>Genero:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtGenero" AutoComplete="off" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="ValidarGenero" ControlToValidate="TxtGenero" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalGenero" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>           
                        </div>
                                <asp:Label ID="Label6" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                           <%-- <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>--%>
                            <asp:Button ID="BtnGuardarGeneroAtajo" ValidationGroup="ModalGenero" OnClick="BtnGuardarGeneroAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
