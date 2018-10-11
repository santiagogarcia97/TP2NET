<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
   
    <!-- Modal -->
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
            <asp:Panel ID="formPanel" Visible="true" runat="server">
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-3 pull-right"><asp:Label ID="IDLabel" runat="server" Text="ID"></asp:Label></div>
                    <div class="col-sm-3"><asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-2"></div>
                </div>

                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-3 pull-right"><asp:Label ID="descripcionLabel" runat="server" Text="Descripción"></asp:Label></div>   
                    <div class="col-sm-3"><asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-2"></div>                                     
                </div>
            </asp:Panel>
      </div>
      <div class="modal-footer" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" class="btn btn-primary">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" class="btn btn-secondary" data-dismiss="modal">Cancelar</asp:LinkButton>
      </div>
    </div>
  </div>
</div>



    <div>
        <p class="font-weight-bold text-left h2">Especialidades</p>
    </div>
    <hr />
    <div>
    <asp:Panel ID="gridActionsPanel" runat="server">
       <p>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" data-toggle="modal" data-target="#nuevoModal" CssClass="btn btn-outline-success btn-sm">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn btn-outline-success btn-sm">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn btn-outline-success btn-sm">Eliminar</asp:LinkButton>
       </p>    
    </asp:Panel>
    </div>
    <div class="grid-view">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
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
    </div>

</asp:Content>
