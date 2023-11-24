<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="cBibliotecario.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Administracion.cBibliotecario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container"> <!--CONTENEDOR PRINCIPAL QUE HACE QUE EL FORMULARIO ESTE EN EL CENTRO. POR SER EL CONTENDOR PRINCIPAL-->  
       <br/>  
       <div class="panel panel-primary " ><!--CONTENEDOR SECUNDARIO CON ESTILO FORMULARIO BOOTSTRAP-->
            <div class="panel-heading heightheadercAdmin"><h3>Registro de Bibliotecario</h3></div> <!--ENCABEZADO DE REGISTRO DE ADMINISTRADOR-->
           <div class="panel-body">
               <div class="row">
                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS PRIMER CAMPO NOMBRES-->
                       <div class="input-group">
                           <label for="Nom">Nombres:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-user"></i></span>
                           <asp:TextBox AutoComplete="off" ID="TxtNombres" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" CssClass="form-control" placeholder="Renan Alfredo" runat="server"></asp:TextBox>
                       </div>
                            <asp:RequiredFieldValidator ID="ValidarNombreBiblio" ControlToValidate="TxtNombres" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>


                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS SEGUNDO CAMPO APELLIIDOS-->
                       <div class="input-group">
                           <label for="Ape">Apellidos:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-user"></i></span>
                           <asp:TextBox ID="TxtApellidos" AutoComplete="off" onKeyPress=" ucwords(this) ;return ValidarLetra(event);" CssClass="form-control" placeholder="Rosales Gutierrez" runat="server"></asp:TextBox>
                       </div>
                            <asp:RequiredFieldValidator ID="ValidarApellidosBiblio" ControlToValidate="TxtApellidos" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS TERCER CAMPO CEDULA-->
                       <div class="input-group">
                           <label for="Ced">Cédula:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fas fa-address-card"></i></span>
                           <asp:TextBox ID="TxtCedula" MaxLength="14" AutoComplete="off"   onKeyPress="toUpper(this)" CssClass="form-control" placeholder="000-000000-0008C" runat="server"></asp:TextBox>
                       </div>
                         <asp:RegularExpressionValidator ID="RegEx" ForeColor="OrangeRed" ValidationGroup="FormCreateBiblio" runat="server" ErrorMessage="Formato de cédula incorrecto" ControlToValidate="TxtCedula" ValidationExpression="[0-9]{3}[0-9]{6}[0-9]{4}[A-Z]">
                           </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="ValidarCedulaBiblio" ControlToValidate="TxtCedula" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>
               </div>


               <div class="row">
                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS CUARTO CAMPO EDAD-->
                       <div class="input-group">
                           <br />
                           <label for="Edad">Edad:<label class="AstericoColorTamanio">*</label></label>
                       </div>

                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-child"></i></span>
                           <asp:TextBox ID="TxtEdad" MaxLength="2" pattern="[123456789]{1}[0-9]{1}" AutoComplete="off" CssClass="form-control" placeholder="20" runat="server"></asp:TextBox>
                       </div>
                             <asp:RequiredFieldValidator ID="ValidarEdadBiblio" ControlToValidate="TxtEdad" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS QUINTO CAMPO GENERO-->
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
                           <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                           <asp:TextBox ID="TxtDireccion" AutoComplete="off" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Mined 2c al Norte" runat="server" TextMode="MultiLine"></asp:TextBox>
                       </div>
                             <asp:RequiredFieldValidator ID="ValidarDireccionBiblio" ControlToValidate="TxtDireccion" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>
               </div>

               <div class="row">
                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS NOVENO CAMPO CORREO ELECTRONICO-->
                       <div class="input-group">
                           <br />
                           <label for="Correo">E-mail:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                           <asp:TextBox ID="TxtEmail" AutoComplete="off" CssClass="form-control" placeholder="renanrg9306@yahoo.es" runat="server"></asp:TextBox>

                       </div>
                             <asp:RegularExpressionValidator ID="RegErCorreo" ForeColor="OrangeRed" ValidationGroup="FormCreateBiblio" runat="server" ErrorMessage="Correo Invalido" ControlToValidate="TxtEmail" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$">
                           </asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="ValidarEmail" ControlToValidate="TxtEmail" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                   </div>

                   <div class="col-sm-4">
                       <!--INCIA LA DIVISION DEL SISTEMA DE REJILLAS SEPTIMO CAMPO NIVEL TELEFONO-->

                       <div class="input-group">
                           <br />
                           <label for="Telef">Teléfono:<label class="AstericoColorTamanio">*</label></label>
                       </div>
                       <div class="input-group">
                           <span class="input-group-addon"><i class="fa fa-mobile"></i></span>
                           <asp:TextBox ID="TxtTelefono" pattern="[12345678]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}[0-9]{1}" MaxLength="8" AutoComplete="off" CssClass="form-control" placeholder="58732329" runat="server"></asp:TextBox>

                       </div>
                             <asp:RequiredFieldValidator ID="ValidarTelefono" ControlToValidate="TxtTelefono" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="FormCreateBiblio" runat="server"
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
                   <div class="col-sm-9"><br/><asp:Label ID="Label2" CssClass="CamposObligatorios" runat="server"  Text="(*) Campos Obligatorios"></asp:Label></div>
                   <div class="col-sm-3">
                       <div class="form group">
                           <br />
                           <asp:Button ID="BtnGuardar" ValidationGroup="FormCreateBiblio" CssClass="btn btn-info" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                           <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                       </div>
                   </div>
               </div>

                   <asp:Label ID="LbFecha" Visible="false" runat="server" Text=""></asp:Label>

               </div>   
        </div> 
   </div>

   <%-- MODAL NIVEL ACADEMICO ATAJO INSERTAR--%>
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
                        <asp:TextBox ID="TxtNivelAca" onKeyPress=" ucwords(this) ;return ValidarLetra(event);"  AutoComplete="off"  runat="server" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ValidarNivelAca" ControlToValidate="TxtNivelAca" ForeColor="Red"
                           Display="Dynamic" ValidationGroup="ModalCreateNivelAcaBiblio" runat="server"
                           ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>
                    <asp:Label ID="Label1" Font-Bold="true" style="color:red;" runat="server" Text="(*) Campo Obligatorio"></asp:Label>
                                <label class="CamposObligatorios">(*) Campos Obligatorios</label>
                        <div class="modal-footer">
                            
                            <asp:Button ID="BtnGuardarNivelAcademicoAtajo" ValidationGroup="ModalCreateNivelAcaBiblio" OnClick="BtnGuardarNivelAcademicoAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
