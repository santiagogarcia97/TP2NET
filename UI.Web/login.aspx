﻿<%@ Page Title="Home" Language="C#"  AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UI.Web.Default" %>

<!DOCTYPE html>

<html lang="en">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">    
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <title>Academia - Log in</title>

        <link href="Content/bootstrap.min.css" rel="stylesheet">
        <link href="Styles/signin.css" rel="stylesheet">
    </head>

    <body class="text-center">
        <form class="form-signin" id="bodyForm" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <p class="font-weight-bold text-center h1">Academia</p>
            <img class="mb-4" src="Styles/utn-logo.png" alt="" width="80" height="80">
            <h1 class="h3 mb-3 font-weight-normal">Log in</h1>
            <asp:TextBox ID="txtUser" type="text" class="form-control" placeholder="Usuario" required="" autofocus="" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPassword" type="password" class="form-control" placeholder="Contraseña" required="" runat="server"></asp:TextBox>
            
            <asp:UpdatePanel ID="UpdatePanelBtn" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="text-danger">
                        <asp:Label ID="lblBadLogin" runat="server" Visible="false">Usuario o Contraseña incorrecto</asp:Label>
                        <asp:Label ID="lblError" runat="server" Visible="false">Error de Servidor</asp:Label>
                    </div>

                    <hr />
                    <asp:Button Text="Ingresar" runat="server" id="aceptarLinkButton" OnClick="aceptarLinkButton_Click" class="btn btn-lg btn-success btn-block" type="submit" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <p class="mt-5 mb-3 text-muted">Caracini, Bruno - Cardona, Joaquín<br />García, Santiago</p>
        </form>
    </body>
</html>