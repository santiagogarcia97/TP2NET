<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Modal para cargar o editar -->
    <div class="modal fade" id="nuevoModal" tabindex="-1" role="dialog" aria-labelledby="nuevoModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Nueva Especialidad</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <div class="form-group">
                        <label for="inputID" class="col-form-label">ID</label>
                        <asp:TextBox id="inputID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="descripcionTextBox" class="col-form-label">Descripción</label>
                        <asp:TextBox ID="descripcionTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer" runat="server">
                    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" class="btn btn-primary">
                        Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarLinkButton" runat="server" class="btn btn-secondary" data-dismiss="modal">
                        Cancelar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Especialidades</p>
    </div>
    <hr />
    <div>
    <asp:Panel ID="gridActionsPanel" runat="server">
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server">
        <ContentTemplate>
        <asp:Button ID="nuevoButton" Text="Nuevo" runat="server"  OnClick="nuevoButton_Click" CssClass="btn btn-outline-success btn-sm" data-toggle="modal" data-target="#nuevoModal" />
        <asp:Button ID="editarButton" Text="Editar" runat="server" OnClick="editarButton_Click" CssClass="btn btn-outline-success btn-sm" data-toggle="modal" data-target="#nuevoModal" />
        <asp:Button ID="eliminarButton" Text="Eliminar" runat="server" OnClick="eliminarButton_Click" CssClass="btn btn-outline-success btn-sm" />   
        </ContentTemplate>
        </asp:UpdatePanel>
       </p>    
    </asp:Panel>
    </div>
    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
        <ContentTemplate>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="#343a40"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnLoad="Page_Load" OnSelectedIndexChanged="Page_Load"
            CssClass="table table-bordered table-striped table-sm table-responsive table-hover">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion"  ItemStyle-Width="100%"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="EspecialidadesDataSource" runat="server"></asp:ObjectDataSource>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
