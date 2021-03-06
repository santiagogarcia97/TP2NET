﻿<%@ Page Title="" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.admin.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <!-- Modal para cargar, editar o eliminar -->    
    <div class="modal fade" id="ModalMaterias" tabindex="-1" role="dialog" >
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
                    <label for="txtDescripcion" class="col-4 form-text font-weight-bold">Descripción</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtDescripcion" runat="server" Text="Label"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="form-group col-6">
                            <label for="ddHSSem" class="form-text font-weight-bold">Hrs Semanales</label>
                            <asp:TextBox ID="txtHSSem" TextMode="Number" min="0" max="100" step="1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-6">
                            <label for="ddHSTot" class="form-text font-weight-bold">Hrs Totales</label>
                            <asp:TextBox ID="txtHSTot" TextMode="Number" min="0" max="300" step="1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group col-6">
                            <label for="ddEsp" class="form-text font-weight-bold">Especialidad</label>
                            <asp:DropDownList ID="ddEsp" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddEsp_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group col-6">
                            <label for="ddPlan" class="form-text font-weight-bold">Plan</label>
                            <asp:DropDownList ID="ddPlan" runat="server" CssClass="form-control"  AutoPostBack="false"></asp:DropDownList>
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
        <p class="font-weight-bold text-left h2">Materias</p>
    </div>

    <hr />

    <div>    
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnNuevo" Text="Nuevo" runat="server"
                    CssClass="btn btn-outline-success btn-sm" OnClick="btnNuevo_Click" />
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
                <asp:GridView ID="gvMat" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" 
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvMat_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" ItemStyle-Width="40%"/>
                    <asp:BoundField HeaderText="Hrs Sem" DataField="HSSemanales" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Hrs Tot" DataField="HSTotales" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Plan" DataField="Plan" ItemStyle-Width="20%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div runat="server" id="divSinMaterias" visible="false">
        <br />
        <p class="text-center">No hay materias disponibles</p>
    </div>
</asp:Content>
