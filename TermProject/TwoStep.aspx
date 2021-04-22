<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoStep.aspx.cs" Inherits="TermProject.TwoStep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
        <div class="header">
            <h2>Verification Page</h2>
            <h4>Input your username and password below then click the 'Verify' button to verify your account.</h4>
            <asp:Label ID="lblErrorOccured" runat="server" Text="Username or Passoword is invalid. Please try again."></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsernameInput" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPasswordInput" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="btnCheckAccountExistence" runat="server" Text="Check Account Existence" OnClick="btnCheckAccountExistence_Click" />
            <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />
        </div>
    </form>
</body>
</html>
