<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h3>Login Page</h3>
        </div>
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSignIn" runat="server" Text="SignIn" OnClick="btnSignIn_Click" />
            <br />
            <asp:Button ID="btnCreateNewUser" runat="server" Text="Create New Account" OnClick="btnCreateNewUser_Click" />
            <br />
            <asp:Button ID="btnForgot" runat="server" Text="Forgot Username/Password ?" OnClick="btnForgot_Click" />
            <br />
            <asp:Button ID="btnVerify" runat="server" Text="Verify Account" OnClick="btnVerify_Click" />
        </div>
    </form>
</body>
</html>
