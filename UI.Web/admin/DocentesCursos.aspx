<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.admin.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <!-- Modal para cargar, editar o eliminar -->    
    <div class="modal fade" id="ModalDocentesCursos" tabindex="-1" role="dialog" >
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
                    <div class="form-group">
                        <label for="txtID" class="col-form-label">ID</label>
                        <asp:TextBox id="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddCurso" class="col-form-label">Curso</label>
                        <asp:DropDownList ID="ddCurso" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddDocente" class="col-form-label">Docente</label>
                        <asp:DropDownList ID="ddDocente" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddCargo" class="col-form-label">Cargo</label>
                        <asp:DropDownList ID="ddCargo" runat="server" CssClass="form-control"></asp:DropDownList>
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
        <p class="font-weight-bold text-left h2">Docentes - Cursos</p>
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
                <asp:GridView ID="gvDC" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" OnLoad="Page_Load"
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvDC_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="40%"/>
                    <asp:BoundField HeaderText="Docente" DataField="Docente" ItemStyle-Width="40%"/>
                    <asp:BoundField HeaderText="Cargo" DataField="Cargo" ItemStyle-Width="20%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
