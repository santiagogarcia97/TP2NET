<%@ Page Title="Especialidades" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Especialidades1.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <!-- Modal para cargar, editar o eliminar -->
    <div class="modal fade" id="nuevoModal" tabindex="-1" role="dialog" aria-labelledby="nuevoModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">                
            <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
            <ContentTemplate>                
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"><asp:Label ID="modalHeader" runat="server" Text="modalHeader"></asp:Label></h5>                    
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="form-group">
                        <label for="inputID" class="col-form-label">ID</label>
                        <asp:TextBox id="inputID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                            
                    <div class="form-group">
                        <label for="descripcionTextBox" class="col-form-label">Descripción</label>
                        <asp:TextBox ID="descripcionTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="modal-footer" runat="server">
                    <asp:Button ID="aceptarButton" runat="server" Text="aceptarBtn"  OnClick="aceptarButton_Click" class="btn btn-primary" />
                    <asp:Button ID="cancelarButton" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
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
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnNuevo" Text="Nuevo" runat="server"  OnClick="nuevoButton_Click" 
                    CssClass="btn btn-outline-success btn-sm" />
                <asp:Button ID="btnEditar" Text="Editar" runat="server" OnClick="editarButton_Click" 
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false"/>
                <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" OnClick="eliminarButton_Click" 
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" />
                <asp:Button ID="btnDesseleccionar" CssClass="btn btn-outline-danger btn-sm" runat="server" 
                    OnClick="btnDeseleccionar_Click" Visible="false" Text="x" />
            </ContentTemplate>
        </asp:UpdatePanel>
           <p>
           </p>
       </p>    
    </asp:Panel>
    </div>

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="aceptarButton"/>
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" OnLoad="Page_Load" OnSelectedIndexChanged="gridView_SelectedIndexChanged"
                    CssClass="table table-bordered table-striped table-sm table-responsive table-hover">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion"  ItemStyle-Width="100%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass=”thead-light” />
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
