<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <asp:Panel ID="gridPanel" runat="server">
        <head runat="server" />
        <asp:GridView ID="gridView" font-name="Georgia" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnLoad="Page_Load" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Email" DataField="EMail" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="UsuariosDataSource" runat="server"></asp:ObjectDataSource>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton font-name="Georgia" ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton font-name="Georgia" ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton font-name="Georgia" ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>


    <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label font-name="Georgia" ID="IDLabel" runat="server" Text="ID: -"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedNom" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedAp" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="emailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedEmail" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
            <br />
            <asp:Label font-name="Georgia" ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedUser" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="LegajoLabel" runat="server" Text="Legajo: "></asp:Label>
            <asp:TextBox ID="LegajoTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label font-name="Georgia" ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedClave" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="fechaLabel" runat="server" Text="Fecha nacimiento: "></asp:Label>
            <asp:TextBox ID="fechaTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedNac" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="direccionLabel" runat="server" Text="Dirección: "></asp:Label>
            <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedDirec" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="telefonoLabel" runat="server" Text="Teléfono: "></asp:Label>
            <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
            <asp:Label font-name="Georgia" ID="lblRedTel" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="tipoLabel" runat="server" Text="Tipo de Usuario: "></asp:Label>
            <asp:DropDownList ID="tipoDDL" runat="server">
                <asp:ListItem Value=1>Alumno</asp:ListItem>
                <asp:ListItem Value=2>Docente</asp:ListItem>
                <asp:ListItem Value=3>Administrativo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label font-name="Georgia" ID="lblRedTipo" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label font-name="Georgia" ID="especialidadLabel" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="especialidadDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Label font-name="Georgia" ID="planLabel" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="planDDL" runat="server"></asp:DropDownList>
            <asp:Label font-name="Georgia" ID="lblRedPlan" forecolor="Red" runat="server" Text="*" Visible="False"></asp:Label>
            <br />
        
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton font-name="Georgia" ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton font-name="Georgia" ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>

</asp:Content>
