<%@ Page Title="" Language="C#" MasterPageFile="~/Panel Bibliotecario/Bibliotecario.Master" AutoEventWireup="true" CodeBehind="cVisitante.aspx.cs" Inherits="SistemaBibliotecarioCCNN.Panel_Bibliotecario.Visitantes.cVisitante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
    <div class="container">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel panel-primary">
                    <div class="panel-heading heightheader"><h3>Registro de Visitante</h3></div>
                    <div class="panel-body">

                        <div class="row">

                            <div class="col-sm-4">
                                <label>Nombres:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <asp:TextBox type="text" ID="TxtNombresVisitante" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Renan Alfredo" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ValidarNombresVisit" ControlToValidate="TxtNombresVisitante" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4">
                                <label for="Apellido">Apellidos:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <asp:TextBox type="text" ID="TxtApellidosVisitante" onKeyPress="ucwords(this)" CssClass="form-control" placeholder="Rosales Gutierrez" runat="server"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarApellidosVisit" ControlToValidate="TxtApellidosVisitante" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4">
                                <label for="Dire">Dirección:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                                    <asp:TextBox type="text" ID="TxtDireccionVisitante" onKeyPress="ucwords(this)" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarDireccion" ControlToValidate="TxtDireccionVisitante" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <br/>
                        <div class="row">
                            <div class="col-sm-3">
                                <label for="Cedula">Cédula:</label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fas fa-address-card"></i></span>
                                    <asp:TextBox type="text" ID="TxtCedulaVisitante" onKeyPress="ucwords(this)" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-sm-2">
                                <label for="Edad">Edad:*</label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-child"></i></span>
                                    <asp:TextBox type="text" ID="TxtEdadVisitante" onKeyPress="ucwords(this)" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarEdadVisit" ControlToValidate="TxtEdadVisitante" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4">          
                                <label for="Opc">Genero:</label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-venus-mars"></i></span>
                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                             <div class="col-sm-3">
                                <label for="Ocu">Ocupacion:</label>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalOcupacion"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlOcupacion" OnPreRender="DdlOcupacion_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                                
                                </div>
                            </div>
                        </div>
                        <br/>
                        <div class="row">
                            <div class="col-sm-3">
                                <label for="Tel">Teléfono:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
                                    <asp:TextBox type="text" ID="TxtNumero" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarTelefonoVisit" ControlToValidate="TxtNumero" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                             <div class="col-sm-3">
                                <label for="Tel">Correo:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class=""></i></span>
                                    <asp:TextBox type="text" ID="TxtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                    <asp:RequiredFieldValidator ID="ValidarCorreo" ControlToValidate="TxtCorreo" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="FormCreateVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>
                            </div>

                             <div class="col-sm-3">
                                <label for="Tel">Program:<label class="AstericoColorTamanio">*</label></label>
                                <div class="input-group">
                                    <span class="input-group-addon"><a data-toggle="modal" href="#myModalProgram"><i class="fa fa-plus"></i></a></span>
                                    <asp:DropDownList ID="DdlProgram" OnPreRender="DdlProgram_PreRender" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>


                             <div class="col-sm-3 Botones">
                                <div class="form-group">
                                    <asp:Button ID="BtnGuardar" ValidationGroup="FormCreateVisit" OnClick="BtnGuardar_Click" CssClass="btn btn-info"  runat="server" Text="Guardar" />
                                    <asp:Button ID="BtnCancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-danger"  runat="server" Text="Cancelar" />
                                </div>
                            </div>
                            <asp:Label ID="LbFecha" runat="server" Text="" Visible="false"></asp:Label>
                            

                        </div>

                        <asp:Label ID="Label1" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
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
                                <asp:RequiredFieldValidator ID="ValidarModalProgram" ControlToValidate="TxtProgram" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalProgramVisit" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>     
                        </div>
                                     <asp:Label ID="Label2" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                            <asp:Button ID="BtnGuardarProgramAtajo" ValidationGroup="ModalProgramVisit" OnClick="BtnGuardarProgramAtajo_Click1" CssClass="btn btn-primary" runat="server" Text="Guardar" />
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
                                  <asp:RequiredFieldValidator ID="ValidarOcupacion" ControlToValidate="TxtOcupacion" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ModalOcupacion" runat="server"
                                    ErrorMessage="Campo Obligatorio (*)"></asp:RequiredFieldValidator>         
                        </div>
                                 <asp:Label ID="Label3" runat="server" CssClass="CamposObligatorios" Text="(*) Campos Obligatorios"></asp:Label>
                        <div class="modal-footer">
                           
                            <asp:Button ID="BtnGuardarOcupacionAtajo" ValidationGroup="ModalOcupacion" OnClick="BtnGuardarOcupacionAtajo_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                        </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
