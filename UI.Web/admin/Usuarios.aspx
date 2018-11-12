<%@ Page Title="Usuarios" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <!-- Modal para cargar, editar o eliminar -->    
    <div class="modal fade" id="ModalUsuarios" tabindex="-1" role="dialog" >
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
                    <div class="form-row">
                        <label for="lblID" class="col-4 form-text font-weight-bold">ID</label>
                        <div class="col-8 form-text">
                            <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <label for="lblLegajo" class="col-4 form-text font-weight-bold">Legajo</label>
                        <div class="col-8 form-text">
                            <asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label>                 
                        </div>
                    </div>

                    <hr />

                    <div class="form-group row">
                        <label for="txtNombre" class="col-4 form-text font-weight-bold">Nombre</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtApellido" class="col-4 form-text font-weight-bold">Apellido</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtFechaNac" class="col-4 form-text font-weight-bold">Fecha nacimiento</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" TextMode="DateTime"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                    <div class="form-group row">
                        <label for="txtDirec" class="col-4 form-text font-weight-bold">Dirección</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtDirec" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtTel" class="col-4 form-text font-weight-bold">Telefono</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtEmail" class="col-4 form-text font-weight-bold">Email</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <hr />
                    
                    <div class="form-group row">
                        <label for="txtUser" class="col-4 form-text font-weight-bold">Usuario</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row" runat="server" id="divPass">
                        <label for="txtPass" class="col-4 form-text font-weight-bold">Clave</label>
                        <div class="col-8">
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="ddTipo" class="col-4 form-text font-weight-bold">Tipo de usuario</label>
                        <div class="col-8">
                            <asp:DropDownList ID="ddTipo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>

                    <hr />
                    
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
                    <asp:Button ID="btnAceptar" runat="server" Text="btnAceptar" class="btn btn-primary" OnClick="btnAceptar_Click"  />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>

        <!-- Modal para cambiar pass -->    
    <div class="modal fade" id="ModalPass" tabindex="-1" role="dialog" >
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">                
            <asp:UpdatePanel ID="UpdatePanelCambiaPass" runat="server" UpdateMode="Conditional">
            <ContentTemplate>                
                <div class="modal-header">
                    <h5 class="modal-title">Cambiar Contraseña</h5>                    
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtNuevaPass1" class="col-form-label">Nueva Contraseña</label>
                        <asp:TextBox id="txtNuevaPass1" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                            
                    <div class="form-group">
                        <label for="txtNuevaPass2" class="col-form-label">Reingresar Contraseña</label>
                        <asp:TextBox id="txtNuevaPass2" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="modal-footer" runat="server">
                    <asp:Button ID="btnGuardarPass" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardarPass_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div> 

    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Usuarios</p>
    </div>

    <hr />

    <div>    
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnNuevo" Text="Nuevo" runat="server"
                    CssClass="btn btn-outline-success btn-sm" OnClick="btnNuevo_Click"  />
                <asp:Button ID="btnEditar" Text="Editar" runat="server"
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" OnClick="btnEditar_Click" />
                <asp:Button ID="btnEliminar" Text="Eliminar" runat="server"
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" OnClick="btnEliminar_Click"  />
                <asp:Button ID="btnCambiaPass" Text="Cambiar Pass" runat="server"
                    CssClass="btn btn-outline-secondary btn-sm" Enabled="false" OnClick="btnCambiaPass_Click"  />
                <asp:Button ID="btnDeseleccionar" CssClass="btn btn-outline-danger btn-sm" runat="server" 
                    Visible="false" Text="x" OnClick="btnDeseleccionar_Click"  />
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
                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID"
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="NombreUsuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-Width="100%" />
                    <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="FechaNac" DataField="FechaNac" />
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                    <asp:BoundField HeaderText="Plan" DataField="Plan" />


                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
