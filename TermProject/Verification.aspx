<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="TermProject.Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <asp:Label ID="lblComicAccVerified" runat="server"> <h3>Verify Email</h3> </asp:Label>

            <p>Thanks for creating an account with us.</p>
            <p>To continue please verify your email with us.</p>
            <asp:Button ID="btnComicAccVerified" runat="server" Text="Verify!" class="btn btn-primary" />
        </div>
    </form>
</body>
</html>
