<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    <style>
        body {
            background-image: url("imgs/deadPoolWave.jpg");
        }
        .card{
            position: absolute;
            max-height: 400px;
            top: 15vh;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server" style="text-align: center">
        <div class="container">
            <div class="d-flex justify-content-center h-100">
                <div class="card shadow-lg bg-dark text-light rounded border-dark wi">
                    <div class="card-header">
                        <h3>Login Page</h3>
                    </div>
                    <div class="card-body text-light">
                        <div class="input-group form-group">
                            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnCreateNewUser" runat="server" Text="Create Account" OnClick="btnCreateNewUser_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnForgot" runat="server" Text="Forgot Username/Password?" OnClick="btnForgot_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnClearCookies" runat="server" Text="Clear Cookies" OnClick="btnClearCookies_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
