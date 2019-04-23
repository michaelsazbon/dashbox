<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DashBox.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="Content/bootstrap.min.css" />


    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body class="loginpage">
    <form id="form1" runat="server">

        <div id="content">

            <div class="logoDiv">

               <div id="logo">Dashbox </div> 

            </div>

            <div class="wrapper">

                <div class="form-signin">
                    <h2 class="form-signin-heading">Please login</h2>

                    <div id="ErrorMessage" visible="false" runat="server" class="alert alert-danger" role="alert">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Erreur:</span>
                        <asp:Label ID="ErrorMessageLbl" runat="server"></asp:Label>
                    </div>

                    <div id="SuccesMessage" visible="false" runat="server" class="alert alert-success" role="alert">
                        <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                        <asp:Label ID="SuccessMessageLbl" runat="server"></asp:Label>
                    </div>

                    <asp:TextBox ID="UsernameTxt" class="form-control" placeholder="Nom d'utilisateur" runat="server"></asp:TextBox>
                    <div id="UsernameValidator" visible="false" runat="server" class="alert alert-danger" role="alert">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Erreur:</span>
                        <asp:Label ID="UsernameError" runat="server"></asp:Label>
                    </div>

                    <asp:TextBox TextMode="Password" ID="PasswordTxt" class="form-control" placeholder="Mot de passe" runat="server"></asp:TextBox>
                    <div id="PasswordValidator" visible="false" runat="server" class="alert alert-danger" role="alert">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Erreur:</span>
                        <asp:Label ID="PasswordError" runat="server"></asp:Label>
                    </div>
                    <label class="checkbox">
                        <input type="checkbox" value="remember-me" id="rememberMe" name="rememberMe" />
                        Remember me
                    </label>
                    <asp:Button role="button" class="btn btn-lg btn-primary btn-block" Text="Connexion" ID="ConnexionBtn" runat="server" OnClick="ConnexionBtn_Click" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
