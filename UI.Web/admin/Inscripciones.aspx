﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.admin.Inscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

        <!-- Modal para cargar, editar o eliminar -->    
    <div class="modal fade" id="ModalInscripciones" tabindex="-1" role="dialog" >
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">                
            <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
            <ContentTemplate>                
                <div class="modal-header">
                    <h5 class="modal-title"><asp:Label ID="modalHeader" runat="server" Text="modalHeader"></asp:Label></h5>                    
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="form-group row">
                    <label for="txtID" class="col-4 form-text font-weight-bold">ID</label>
                        <div class="col-8 form-text">
                            <asp:Label ID="txtID" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtAlumno" class="col-4 form-text font-weight-bold">Alumno</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtAlumno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtCurso" class="col-4 form-text font-weight-bold">Curso</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtCurso" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="ddCondicion" class="col-4 form-text font-weight-bold">Condición</label>
                        <div class="col-8">
                            <asp:DropDownList ID="ddCondicion" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                   
                    <div class="form-group row">
                    <label for="txtCupo" class="col-4 form-text font-weight-bold">Nota</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtNota" TextMode="Number" min="0" max="10" step="1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div> 

                </div>

                <div class="modal-footer" runat="server">
                    <asp:Button ID="btnAceptar" runat="server" Text="btnAceptar" class="btn btn-primary" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Inscripciones</p>
    </div>

    <hr />

    <div>    
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnEditar" Text="Editar" runat="server"
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" OnClick="btnEditar_Click"/>
                <asp:Button ID="btnEliminar" Text="Eliminar" runat="server"
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnDeseleccionar" CssClass="btn btn-outline-danger btn-sm" runat="server" 
                    Visible="false" Text="x" OnClick="btnDeseleccionar_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
       </p>    
    </div>

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar"/>
            </Triggers>

            <ContentTemplate>
                <asp:GridView ID="gvIns" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" 
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvIns_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Alumno" DataField="Alumno" ItemStyle-Width="40%"/>
                    <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Nota" DataField="Nota" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Condicion" DataField="Condicion" ItemStyle-Width="20%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div runat="server" id="divSinIns" visible="false">
        <br />
        <p class="text-center">No hay inscripciones disponibles</p>
    </div>
</asp:Content>
