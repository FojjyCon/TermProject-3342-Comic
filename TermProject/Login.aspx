<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align:center">
        <div class="header">
            <h3>Login Page</h3>
        </div>
        <div>
            <asp:Label ID="lblUsernameLogin" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsernameLogin" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPasswordLogin" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPasswordLogin" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSignIn" runat="server" Text="SignIn" OnClick="btnSignIn_Click" />
            <asp:Button ID="btnCreateNewUser" runat="server" Text="Create New Account" OnClick="btnCreateNewUser_Click" />
            <asp:Button ID="btnForgot" runat="server" Text="Forgot Username/Password ?" OnClick="btnForgot_Click" />
        </div>
    </form>
</body>
</html>
