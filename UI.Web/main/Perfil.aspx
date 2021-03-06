﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="UI.Web.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <!-- Modal para cambiar pass -->    
    <div class="modal fade" id="ModalPass" tabindex="-1" role="dialog" >
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">                
            <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
            <ContentTemplate>                
                <div class="modal-header">
                    <h5 class="modal-title"><asp:Label ID="modalHeader" runat="server" Text="Cambiar Contraseña"></asp:Label></h5>                    
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtNuevaPass1" class="form-text font-weight-bold">Nueva Contraseña</label>
                        <asp:TextBox ID="txtNuevaPass1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtNuevaPass2" class="form-text font-weight-bold">Reingresar Contraseña</label>
                        <asp:TextBox ID="txtNuevaPass2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="form-group">
                        <label for="txtViejaPass" class="form-text font-weight-bold">Contraseña actual</label>
                        <asp:TextBox ID="txtViejaPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="modal-footer" runat="server">
                    <asp:Button ID="btnAceptar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div> 



    <div>
        <p class="font-weight-bold text-left h2">Perfil</p>
    </div>

    <hr />
    
    <div class="perfil">
        <div class="form-group row">
            <label class="col-sm-3 col-form-label font-weight-bold">Legajo</label>
            <asp:Label id="txtLegajo" runat="server" CssClass="col-sm-9 form-control-plaintext"></asp:Label>
        </div>
 
        <div class="form-group row">
            <label for="txtNombre" class="col-sm-3 col-form-label font-weight-bold">Nombre</label>
            <asp:Label id="txtNombre" runat="server" CssClass="col-sm-9 form-control-plaintext"></asp:Label>
        </div>

        <div class="form-group row">
            <label for="txtApellido" class="col-sm-3 col-form-label font-weight-bold">Apellido</label>
            <asp:Label id="txtApellido" runat="server" CssClass="col-sm-9 form-control-plaintext"></asp:Label>
        </div>    
        <div class="form-group row">
            <label for="txtFechaNac" class="col-sm-3 col-form-label font-weight-bold">Fecha Nacimiento</label>
            <asp:Label id="txtFechaNac" runat="server" CssClass="col-sm-9 form-control-plaintext"></asp:Label>
        </div>
         <div class="form-group row">
            <label for="txtDirec" class="col-sm-3 col-form-label font-weight-bold">Nombre de usuario</label>
            <asp:Label ID="txtUsername" runat="server" CssClass="col-sm-9 form-control-plaintext"></asp:Label>
        </div>          
        <hr />     

        <div class="form-group">
            <label for="txtDirec" class="col-form-label font-weight-bold">Direccion</label>
            <asp:TextBox ID="txtDirec" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail" class="col-form-label font-weight-bold">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTel" class="col-form-label font-weight-bold">Telefono</label>
            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
         <br />


        <asp:UpdatePanel ID="UpdatePanelDatos" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar"/>
            </Triggers>
            <ContentTemplate>
                <div class="form-row">  
                    <div class="col-5">
                        <div id="alertSuccess" class="alert alert-success" runat="server" visible="false">
                            <asp:Label ID="lblSuccess" runat="server" Text="lblSuccess"></asp:Label>
                        </div>
                    </div>
                    <div class="col-7 text-right">
                        <asp:Button ID="btnPass" CssClass="btn btn-lg btn-outline-secondary" runat="server" Text="Cambiar clave" OnClick="btnPass_Click" />
                        <asp:Button ID="btnGuardar" CssClass="btn btn-lg btn-outline-success" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click"/>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>   

</asp:Content>
