<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoStep.aspx.cs" Inherits="TermProject.TwoStep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify!</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h2>Verification Page</h2>
            <h4>Input your username and password below then click the 'Verify' button to verify your account.</h4>
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
            <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />
        </div>
    </form>
</body>
</html>
