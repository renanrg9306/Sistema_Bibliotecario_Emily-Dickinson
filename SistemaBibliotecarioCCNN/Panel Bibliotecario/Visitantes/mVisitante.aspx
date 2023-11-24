<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="mVisitante.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Visitantes.mVisitante" %>
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
                        <h3>Actualizar Datos de  Visitante</h3>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-heading heightheader">
                                <h3>Datos Personales de Visitante</h3>
                            </div>
                            <div class="panel-body">

                                <div class="row">
                                    <div class="col-sm-3">
                                        <label>Nombres:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtNombresV" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <label>Apellidos:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtApellidosV" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-3">
                                        <label>Cédula:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtCedulaV" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-sm-1">
                                        <label>Edad:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtEdadV" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValidarEdadVisit" ControlToValidate="TxtEdadV" ForeColor="Red"
                                            Display="Dynamic" ValidationGroup="FormUpdateVisit" runat="server"
                                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-sm-2">
                                        <label>Teléfono:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtTelefonoV" pattern="[12345678]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValidarTelefono" ControlToValidate="TxtTelefonoV" ForeColor="Red"
                                            Display="Dynamic" ValidationGroup="FormUpdateVisit" runat="server"
                                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <label>Dirección:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtDireccionV" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValidarDireccionV" ControlToValidate="TxtDireccionV" ForeColor="Red"
                                            Display="Dynamic" ValidationGroup="FormUpdateVisit" runat="server"
                                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-sm-3">
                                        <label>Ocupación:<label class="AstericoColorTamanio">*</label></label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><a data-toggle="modal" href="#myModalOcupacion"><i class="fa fa-plus"></i></a></span>
                                            <asp:DropDownList ID="DdlOcupacion" OnPreRender="DdlOcupacion_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                       <label>E-mail:<label class="AstericoColorTamanio">*</label></label>
                                        <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValidarCorreo" ControlToValidate="TxtEmail" ForeColor="Red"
                                            Display="Dynamic" ValidationGroup="FormUpdateVisit" runat="server"
                                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-sm-3">
                                        <label>Program:<label class="AstericoColorTamanio">*</label></label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><a data-toggle="modal" href="#myModalProgram"><i class="fa fa-plus"></i></a></span>
                                            <asp:DropDownList ID="DdlProgram" OnPreRender="DdlProgram_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-9">
                                        <br />
                                        <asp:Label ID="LbCampos" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label></div>
                                    <div class="col-md-3">
                                        <br />
                                        <asp:Button ID="BtnActualizarV" ValidationGroup="FormUpdateVisit" OnClick="BtnActualizarV_Click" CssClass="btn btn-primary" runat="server" Text="Actualizar" />
                                        <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                    </div>
                                </div>
                                <asp:Label ID="LbIdVisitante" runat="server" Visible="false" Text=""></asp:Label>
                                <asp:Label ID="LbIdUsuario" runat="server" Visible="false" Text=""></asp:Label>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-8">
                                <div class="panel panel-default">
                                    <div class="panel-heading heightheader">
                                        <h3>Datos de Acceso</h3>
                                    </div>
                                    <div class="panel-body">


                                        <div class="row">
                                            <div class="col-sm-4">
                                                <label>Código de Usuario:<label class="AstericoColorTamanio">*</label></label>
                                                <asp:TextBox ID="TxtCodUsuario" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4">
                                                <label>Password:<label class="AstericoColorTamanio">*</label></label>
                                                <asp:TextBox ID="TxtPassword" Type="password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ValidarPassword" ControlToValidate="TxtPassword" ForeColor="Red"
                                                    Display="Dynamic" ValidationGroup="FormUpdatePasswordVisit" runat="server"
                                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-sm-4 Botones">
                                                <asp:Button ID="BtnActualizaClaveAcessoV" ValidationGroup="FormUpdatePasswordVisit" OnClick="BtnActualizaClaveAcessoV_Click" CssClass="btn btn-primary" runat="server" Text="Actualizar" />

                                            </div>
                                        </div>
                                        <br />
                                        <asp:Label ID="Label2" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-1"></div>
        </div>
    </div>
   
        <%--   TERCER ATAJO PROGRAM --%>
    <div class="modal fade in" role="dialog" id="myModalProgram" tabindex="-1" aria-labelledby="myModalProgramLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalProgramLabel">Registro de Programa de Estudio</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Origen</label>
                        <asp:TextBox ID="TxtProgram" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidarProgram" ControlToValidate="TxtProgram" ForeColor="Red"
                            Display="Dynamic" ValidationGroup="ModalProgram" runat="server"
                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>

                    </div>
                            <asp:Label ID="Label4" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGuardarProgramAtajo" ValidationGroup="ModalProgram" OnClick="BtnGuardarProgramAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                    </div>
                </div>
            </div>
        </div>
    </div>

      <%-- ATAJO GUARDAR OCUPACION --%>
    <div class="modal fade in" role="dialog" id="myModalOcupacion" tabindex="-1" aria-labelledby="myModalOcupacionLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalOcupacionLabel">Registro de Ocupación</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Ocupación</label>
                        <asp:TextBox ID="TxtOcupacion" onKeyPress="ucwords(this)" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidarModalProgram" ControlToValidate="TxtOcupacion" ForeColor="Red"
                            Display="Dynamic" ValidationGroup="ModalOcupacionVisit" runat="server"
                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                    </div>
                            <asp:Label ID="Label5" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                    <div class="modal-footer">

                        <asp:Button ID="BtnGuardarOcupacionAtajo" ValidationGroup="ModalOcupacionVisit" OnClick="BtnGuardarOcupacionAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
