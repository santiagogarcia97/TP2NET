<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cargaNotas.aspx.cs" Inherits="UI.Web.main.cargaNotas" %>
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
                    <asp:Button ID="btnAceptar" runat="server" Text="btnAceptar" class="btn btn-primary" OnClick="btnAceptar_Click"  />
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
        <br />
        <p class="text-left h6"><asp:Label ID="lblCurso" runat="server" Text="Inscripciones para el curso..."></asp:Label></p>
    </div>

    <hr />

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar"/>
            </Triggers>

            <ContentTemplate>
                <asp:GridView ID="gvIns" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" 
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvIns_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Alumno" DataField="Alumno" ItemStyle-Width="40%"/>
                    <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Nota" DataField="Nota" ItemStyle-Width="20%"/>
                    <asp:BoundField HeaderText="Condicion" DataField="Condicion" ItemStyle-Width="20%"/>
                    <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div runat="server" id="divSinAlumnos" visible="false">
        <br />
        <p class="text-center">No hay alumnos inscriptos</p>
    </div>

</asp:Content>
