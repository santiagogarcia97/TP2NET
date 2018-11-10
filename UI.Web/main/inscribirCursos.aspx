<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inscribirCursos.aspx.cs" Inherits="UI.Web.inscribirCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <!-- Modal para confirmar -->    
    <div class="modal fade" id="ModalConfirm" tabindex="-1" role="dialog" >
        <div class="modal-dialog modal-dialog-centered" role="document">

            <div class="modal-content">                
          
                <div class="modal-header">
                    <h5 class="modal-title"><asp:Label ID="modalHeader" runat="server" Text="Confirmar inscripción"></asp:Label></h5>                    
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span>
                    </button>
                </div>
            <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
            <ContentTemplate>                       
                <div class="modal-body">
                    <div class="form-group text-center">
                        <asp:Label ID="lblCurso" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
                <div class="modal-footer" runat="server">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cerrar" class="btn btn-secondary" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>  
    
    
    
    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Inscribir a cursado</p>
        <br />
        <p class="text-left h5"><asp:Label ID="lblEstado" runat="server" Text="lblEstado"></asp:Label></p>
    </div>

    <hr />

    <div class="grid-view">

        <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID" 
            CssClass="table table-bordered table-sm table-responsive table-hover" 
                OnSelectedIndexChanged="gvCursos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" />
            <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
            <asp:BoundField HeaderText="Curso" DataField="Curso" ItemStyle-Width="50%"/>
            <asp:BoundField HeaderText="Cupo" DataField="Cupo" ItemStyle-Width="50%"/>
            <asp:CommandField SelectText="Inscribir" ShowSelectButton="True" />
        </Columns>
        <HeaderStyle CssClass="thead-light" />
        </asp:GridView>
    </div>

    <div runat="server" id="divSinCursos" visible="false">
        <br />
        <p>No hay cursos disponibles</p>
    </div>

</asp:Content>
