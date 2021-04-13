<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotInfo.aspx.cs" Inherits="TermProject.ForgotInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div class="header">
            <h2>Forgot Password Page</h2>
        </div>
        <div>
            <asp:Label ID="lblEmailInput" runat="server" Text="Enter the email address associated with your account: "></asp:Label>
            <asp:TextBox ID="txtEmailInput" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <div class="header">
                <h3>Security Questions</h3>
            </div>
            <div>
                <asp:Label ID="lblQ1" runat="server" Text="What is the name of your first pet?"></asp:Label>
                <asp:TextBox ID="txtQ1" runat="server"></asp:TextBox>
                <asp:Label ID="lblQ2" runat="server" Text="Where did you go to elementary school?"></asp:Label>
                <asp:TextBox ID="txtQ2" runat="server"></asp:TextBox>
                <asp:Label ID="lblQ3" runat="server" Text="Where were you born?"></asp:Label>
                <asp:TextBox ID="txtQ3" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" />
            <asp:Button ID="btnSend" runat="server" Text="Send/Submit" />
        </div>
    </form>
</body>
</html>
