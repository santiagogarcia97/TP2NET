<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mis-cursos.aspx.cs" Inherits="UI.Web.mis_cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <!-- tabla -->
    <div>
        <p class="font-weight-bold text-left h2">Mis cursos</p>
    </div>

    <hr />

    <div>    
       <p>
        <asp:UpdatePanel ID="UpdatePanelButtons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnCarga" Text="Nuevo" runat="server"
                    CssClass="btn btn-outline-success btn-sm"/>
                <asp:Button ID="btnDeseleccionar" CssClass="btn btn-outline-danger btn-sm" runat="server" 
                    Visible="false" Text="x"/>
            </ContentTemplate>
        </asp:UpdatePanel>
       </p>    
    </div>

    <div class="grid-view">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="#343a40"
                    SelectedRowStyle-ForeColor="White"
                    DataKeyNames="ID" OnLoad="Page_Load"
                    CssClass="table table-bordered table-sm table-responsive table-hover">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                    <asp:BoundField HeaderText="Materia" DataField="Materia" ItemStyle-Width="50%"/>
                    <asp:BoundField HeaderText="Comision" DataField="Comision" ItemStyle-Width="10%"/>
                    <asp:BoundField HeaderText="Cupo" DataField="Cupo" ItemStyle-Width="10%"/>
                    <asp:BoundField HeaderText="Plan" DataField="Plan" ItemStyle-Width="30%"/>
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
