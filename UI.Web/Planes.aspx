<%@ Page Title="Planes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:Panel ID="gridPanel" runat="server">
        <head />
        <asp:GridView ID="PlanGridView" font-name="Georgia" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnLoad="Page_Load" OnSelectedIndexChanged="PlanGridView_SelectedIndexChanged" Width="200px">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="ID Especialidad" DataField="IDEspecialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="PlanesDataSource" runat="server"></asp:ObjectDataSource>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton font-name="Georgia" ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton font-name="Georgia" ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton font-name="Georgia" ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>


    <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label font-name="Georgia" ID="IDLabel" runat="server" Text="ID: -"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="descLabel" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="descTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedDesc" forecolor="Red" runat="server" Text="*" Visible="False" Font-Names="Georgia"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="especialidadLabel" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="especialidadDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label font-name="Georgia" ID="lblRedEsp" forecolor="Red" runat="server" Text="*" Visible="False" Font-Names="Georgia"></asp:Label>
            <br />
        
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton font-name="Georgia" ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton font-name="Georgia" ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>

</asp:Content>
