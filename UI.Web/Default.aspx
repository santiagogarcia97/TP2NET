<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="formPanel" runat="server">
        <head />
            <asp:Label ID="userLabel" runat="server" Text="Nombre de usuario: "></asp:Label>
            <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="passwordLabel" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="passwordTextBox" TextMode ="password" runat="server"></asp:TextBox>
            <br />
        
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>
</asp:Content>
