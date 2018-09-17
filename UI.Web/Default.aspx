<%@ Page Title="Home" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<!DOCTYPE html>

<html lang="en">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">    
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>Signin Template for Bootstrap</title>

        <!-- Bootstrap core CSS -->
        <link href="Content/bootstrap.min.css" rel="stylesheet">

        <!-- Custom styles for this template -->
        <link href="Styles/signin.css" rel="stylesheet">
    </head>

    <body class="text-center">
        <form class="form-signin" id="bodyForm" runat="server">
            <img class="mb-4" src="Styles/bootstrap-solid.svg" alt="" width="72" height="72">
            <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
            <label for="inputEmail" class="sr-only">Email address</label>
            <input type="text" id="userTextBox" class="form-control" placeholder="Username" required="" autofocus="" runat="server">
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" ID="passwordTextBox" class="form-control" placeholder="Password" required="" runat="server">
            <div class="checkbox mb-3">
            <label>
                <input type="checkbox" value="remember-me"> Remember me
            </label>
            </div>
            <asp:Button Text="Login" runat="server" id="aceptarLinkButton" OnClick="aceptarLinkButton_Click" class="btn btn-lg btn-primary btn-block" type="submit" />
            <p class="mt-5 mb-3 text-muted">© 2017-2018</p>
        </form>
    </body>
</html>


