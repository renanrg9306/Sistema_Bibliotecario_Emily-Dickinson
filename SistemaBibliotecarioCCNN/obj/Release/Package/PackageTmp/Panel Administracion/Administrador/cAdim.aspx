<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cAdim.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.cAdim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
    
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container"> <br/>  
       <div class="panel panel-primary " >
            <div class="panel-heading heightheadercAdmin"><h3>Registro de Administrador</h3></div> 
           <div class="panel-body">
               <div class="row">
                   <div class="col-sm-4">
                       <div class="input-group">
                           <label for="Nom">Nombres:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-user"></i></span>
                           <asp:TextBox type="text" ID="TxtNombres" AutoComplete="off" onKeyPress=" ucwords(this) ;return ValidarLetra(event);"  CssClass="form-control" placeholder="Renan Alfredo" runat="server"></asp:TextBox>
                       </div>
                       <asp:RequiredFieldValidator ID="ValidarNombreAdmin" ControlToValidate="TxtNombres" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>


                   <div class="col-sm-4">
                       <div class="input-group">
                           <label for="Ape">Apellidos:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-user"></i></span>
                           <asp:TextBox ID="TxtApellidos" AutoComplete="off" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" CssClass="form-control" placeholder="Rosales Gutierrez" runat="server"></asp:TextBox>
                       </div>
                       <asp:RequiredFieldValidator ID="ValidadorApellidosAdmin" ControlToValidate="TxtApellidos" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <div class="input-group">
                           <label for="Ced">Cédula:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fas fa-address-card"></i></span>
                           <asp:TextBox ID="TxtCedula" MaxLength="14" pattern="[0-9]{3}[0-9]{6}[0-9]{4}[A-Z]" AutoComplete="off" CssClass="form-control" onKeyPress="toUpper(this)" placeholder="20206010930008C" runat="server"></asp:TextBox>
                       </div>
                        <asp:RegularExpressionValidator ID="RegEx" ForeColor="OrangeRed" ValidationGroup="FromCreateAdmin" runat="server" ErrorMessage="Formato de cédula incorrecto" ControlToValidate="TxtCedula" ValidationExpression="[0-9]{3}[0-9]{6}[0-9]{4}[A-Z]">
                           </asp:RegularExpressionValidator>
                       <asp:RequiredFieldValidator ID="ValidadorCedulaAdmin" ControlToValidate="TxtCedula" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>
               </div>


               <div class="row">
                   <div class="col-sm-4">
                       <div class="input-group">
                           <br />
                           <label for="Edad">Edad:<label class="AstericoColorTamanio">*</label></label>
                       </div>

                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-child"></i></span>
                           <asp:TextBox ID="TxtEdad" AutoComplete="off" pattern="[0-9][0-9]" CssClass="form-control" MaxLength="2" placeholder="20" runat="server"></asp:TextBox>

                       </div>
                       <asp:RequiredFieldValidator ID="ValidadorEdadAdmin" ControlToValidate="TxtEdad" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <div class="input-group">
                           <br />
                           <label for="Opc">Genero:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-venus-mars"></i></span>
                           <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                               <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                               <asp:ListItem Value="F">Femenino</asp:ListItem>
                           </asp:DropDownList>
                       </div>
                   </div>

                   <div class="col-sm-4">
                       <div class="input-group">
                           <br />
                           <label for="Direc">Dirección:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-address-book">*</i></span>
                           <asp:TextBox ID="TxtDireccion" AutoComplete="off" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Mined 2c al Norte" runat="server" TextMode="MultiLine"></asp:TextBox>
                       </div>
                       <asp:RequiredFieldValidator ID="ValidadorDireccionAdmin" ControlToValidate="TxtDireccion" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>
               </div>

               <div class="row">
                   <div class="col-sm-4">
                       <div class="input-group">
                           <br />
                           <label for="Correo">E-mail:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                           <asp:TextBox ID="TxtEmail" AutoComplete="off" CssClass="form-control" placeholder="renanrg9306@yahoo.es" runat="server"></asp:TextBox>
                          
                            </div>
                        <asp:RegularExpressionValidator ID="RegErCorreo" ForeColor="OrangeRed" ValidationGroup="FromCreateAdmin" runat="server" ErrorMessage="Correo Invalido" ControlToValidate="TxtEmail" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$">
                           </asp:RegularExpressionValidator>
                       <asp:RequiredFieldValidator ID="ValidadorCorreoAdmin" ControlToValidate="TxtEmail" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <div class="input-group">
                           <br />
                           <label for="Telef">Telefono:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-mobile"></i></span>
                           <asp:TextBox ID="TxtTelefono" onkeypress="return ValidarNumero(event);" MaxLength="8" AutoComplete="off" CssClass="form-control validar" placeholder="58732329" runat="server"></asp:TextBox>

                       </div>
                       <asp:RegularExpressionValidator ID="RegErSoloNumeroTelefono" runat="server" ErrorMessage="Numero Incorrecto" ControlToValidate="TxtTelefono" ValidationGroup="FromCreateAdmin" ValidationExpression="^[0-9,$]*$"></asp:RegularExpressionValidator>
                       <asp:RequiredFieldValidator ID="ValidadorTelefonoAdmin" ControlToValidate="TxtTelefono" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FromCreateAdmin" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-3">

                       <div class="input-group">
                           <br />
                           <label for="NivelA">Formación:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><a data-toggle="modal" href="#myModalNivelAcademico"><i class="fa fa-graduation-cap"></i></a></span>
                           <asp:DropDownList ID="DdlistShowNivelAca" OnPreRender="DdlistShowNivelAca_PreRender" CssClass="form-control ResetMargin Selector" runat="server">
                           </asp:DropDownList>
                       </div>

                   </div>
              </div>
               <div class="row">
                   
                   <div class="col-sm-9"> <br/><label class="CamposObligatorios">(*) Campos Obligatorios</label></div>
                   <div class="col-sm-3">
                       <div class="form group">
                           <br />
                           <asp:Button ID="BtnGuardar" ValidationGroup="FromCreateAdmin" CssClass="btn btn-info" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                           <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                       </div>
                   </div>
               </div>

                   <asp:Label ID="LbFecha" Visible="false" runat="server" Text=""></asp:Label>
             

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
                        <asp:TextBox ID="TxtNivelAca" AutoComplete="off" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtNivelAca" ForeColor="Red"
                            Display="Dynamic" ValidationGroup="FormModalNivelAca" runat="server"
                            ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                    </div>
                            <asp:Label ID="Label1" style="color:red;" Font-Bold="true" runat="server" Text="(*) Campo Obligatorio"></asp:Label>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGuardarNivelAcademicoAtajo" ValidationGroup="FormModalNivelAca" OnClick="BtnGuardarNivelAcademicoAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                    </div>
                </div>
        </div>
    </div>
</div>
</asp:Content>
