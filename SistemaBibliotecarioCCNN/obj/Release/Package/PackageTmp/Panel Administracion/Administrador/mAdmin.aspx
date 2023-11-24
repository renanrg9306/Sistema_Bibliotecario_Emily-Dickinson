<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="mAdmin.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.mAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <%--PANEL PRINCIPAL--%>
        <div class="panel panel-primary ">
            <div class="panel-heading heightheader">
                <h3>Actualizar Datos Administrador</h3>
            </div>
            <div class="panel-body">
                <%--PRIMER PANEL DE ACTUALIZAR DATOS PERSONALES ADMINISTRADOR--%>
                <div class="panel panel-default">
                    <div class="panel-heading heightheader">
                        <h3>Actualizar Datos Personales</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Nombres:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtNombres" Enabled="false" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label>Apellidos:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtApellidos" Enabled="false" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-sm-3">
                                <label>Cédula:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtCedula" MaxLength="16" AutoComplete="off" onKeyPress="toUpper(this)" CssClass="form-control" runat="server"></asp:TextBox>
                                  <asp:RegularExpressionValidator ID="RegEx" ForeColor="OrangeRed" ValidationGroup="FromUpdateAdmin" runat="server" ErrorMessage="Formato de cédula incorrecto" ControlToValidate="TxtCedula" ValidationExpression="[0-9][0-9][0-9][-][0-9][0-9][0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9][A-Z]">
                           </asp:RegularExpressionValidator>
                                
                                <asp:RequiredFieldValidator ID="ValidarUpdateCedula" ControlToValidate="TxtCedula" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateAdmin" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-1">
                                <label>Edad:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtEdad" MaxLength="2" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidarUpdateEdad" ControlToValidate="TxtEdad" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateAdmin" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-2">
                               <label>Teléfono:<label class="AstericoColorTamanio" >*</label></label>
                                <asp:TextBox ID="TxtTelefono" MaxLength="8" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidadorUpdateTelefono" ControlToValidate="TxtTelefono" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateAdmin" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <br />
                        <div class="row">

                            <div class="col-sm-3">
                                <label>Dirección:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtDireccion" AutoComplete="off" onKeyPress="ucwords(this)" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidadorUpdateDireccion" ControlToValidate="TxtDireccion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateAdmin" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-3">
                                <label>Correo:<label class="AstericoColorTamanio">*</label></label>
                                <asp:TextBox ID="TxtCorreo" AutoComplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegErCorreo" ForeColor="OrangeRed" ValidationGroup="FormUpdateAdmin" runat="server" ErrorMessage="Correo Invalido" ControlToValidate="TxtCorreo" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$">
                                 </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="ValidadorUpdateCorreo" ControlToValidate="TxtCorreo" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormUpdateAdmin" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-3">
                                <label>Formación:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalNivelAcademico"><i class="fa fa-graduation-cap"></i></a></span>
                                    <asp:DropDownList ID="DdlNivelAca" runat="server" CssClass="form-control Selector" OnPreRender="DdlNivelAca_PreRender">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-sm-3" style="margin-top: 30px;">
                                <div class="form-group">
                                    <asp:Button ID="BtnActualizar" ValidationGroup="FormUpdateAdmin" CssClass="btn btn-info" OnClick="BtnActualizar_Click" runat="server" Text="Actualizar" />
                                    <asp:Button ID="BtnCancelar" CssClass="btn btn-danger" OnClick="BtnCancelar_Click" runat="server" Text="Cancelar" />
                                </div>
                            </div>

                        </div>

                        <br />

                        <div class="row">
                        </div>

                        <div class="row">
                            <div class="col-xs-9">
                                <asp:Label ID="LbId" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LbIdEmpleado" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LbIdUsuario" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LbIdNivelAca" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LbLeyenda" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>

                <%--SEGUNDO PANEL ACTUALIZAR DATOS DE CUENTA --%>
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading heightheader">
                            <div class="row">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <h3>Actualizar Datos de Acceso</h3>
                                </div>
                                <div class="col-md-3"></div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Codigo de Acceso:<label class="AstericoColorTamanio">*</label></label>
                                    <asp:TextBox ID="TxtCodUsuario" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                   <label>Password:<label class="AstericoColorTamanio">*</label></label>
                                    <asp:TextBox ID="TxtPassword" Type="password" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValidadorUpdateClaveAdmin" ControlToValidate="TxtPassword" ForeColor="Red"
                                        Display="Dynamic" ValidationGroup="FormUpdatePasswordAdmin" runat="server"
                                        ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-4 Botones">
                                    
                                    <asp:Button ID="BtnActualizaClaveAcesso" ValidationGroup="FormUpdatePasswordAdmin" OnClick="BtnActualizaClaveAcesso_Click" CssClass="btn btn-info" runat="server" Text="Actualizar" />
                                </div>

                            </div>
                            <br />
                            <asp:Label ID="Label3" CssClass="CamposObligatorios"  runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </div>

      <%--MODAL ATAJO PARA NIVEL ACADEMICO --%>  
    <div class="modal fade in" role="dialog" id="myModalNivelAcademico" tabindex="-1" aria-labelledby="myModalNivelAcademicoLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModaNivelAcademicoLabel">Registro de Nivel Académico</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Formación:<label class="AstericoColorTamanio">*</label></label>
                        <asp:TextBox ID="TxtNivelAca" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="ValidarNivelAca" ControlToValidate="TxtNivelAca" ForeColor="Red"
                                                       Display="Dynamic" ValidationGroup="ModalNivelAca" runat="server" 
                                                       ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="Label2" CssClass="CamposObligatorios" runat="server" Text="(*) Campos Obligatorios"></asp:Label>
                    <div class="modal-footer">

                        <asp:Button ID="BtnGuardarNivelAcademicoAtajo" ValidationGroup="ModalNivelAca" OnClick="BtnGuardarNivelAcademicoAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
