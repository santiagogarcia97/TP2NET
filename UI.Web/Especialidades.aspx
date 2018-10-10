<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
   
    <div>
        <p class="font-weight-bold text-left h2">Especialidades</p>
    </div>
    <hr />
    <div>
    <asp:Panel ID="gridActionsPanel" runat="server">
       <p>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-outline-success btn-sm">Nuevo</asp:LinkButton>
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



    <div>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="IDLabel" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <br />
        
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>
    </div>

</asp:Content>
