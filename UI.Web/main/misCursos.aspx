<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="misCursos.aspx.cs" Inherits="UI.Web.misCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Mis cursos</p>
        <br />
        <p class="text-left h6"><asp:Label ID="lblCurso" runat="server" Text="cursos"></asp:Label></p>
    </div>

    <hr />

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID"
                    CssClass="table table-bordered table-sm table-responsive table-hover" 
                    OnSelectedIndexChanged="gvCursos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                        <asp:BoundField HeaderText="Materia" DataField="Materia" ItemStyle-Width="50%" />
                        <asp:BoundField HeaderText="Comision" DataField="Comision" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Cupo" DataField="Cupo" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Plan" DataField="Plan" ItemStyle-Width="30%" />
                        <asp:CommandField SelectText="Ver" ShowSelectButton="True" />
                    </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <div runat="server" id="divSinCursos" visible="false">
        <br />
        <p class="text-center">No hay cursos disponibles</p>
    </div>

</asp:Content>
