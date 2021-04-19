<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgottenInfo.aspx.cs" Inherits="TermProject.ForgottenInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgotten Password</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h2>Forgot Password Page</h2>
        </div>
        <div>
            <asp:Label ID="lblEmailInput" runat="server" Text="Enter the email address associated with your account: "></asp:Label>
            <asp:TextBox ID="txtEmailInput" runat="server"></asp:TextBox>
            <div class="form-group">
                <asp:Label ID="lblMsg" class="float-left" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
            </div>
        </div>
        <%--<div class="form-group">
            <asp:Button ID="btnEmail" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Continue" OnClick="btnEmail_Click" />
        </div>--%>

        <br />
        <div>
            <div class="header">
                <h3>Security Questions</h3>
            </div>
            <div>
                <asp:Label ID="lblQ1" runat="server" Text="What is the name of your first pet?"></asp:Label>
                <asp:TextBox ID="txtQ1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblQ2" runat="server" Text="Where did you go to elementary school?"></asp:Label>
                <asp:TextBox ID="txtQ2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblQ3" runat="server" Text="Where were you born?"></asp:Label>
                <asp:TextBox ID="txtQ3" runat="server"></asp:TextBox>
                <%--<div class="form-group">
                    <asp:Button ID="btnAnswer" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" Text="Continue" OnClick="btnAnswer_Click" />
                </div>--%>
            </div>
        </div>
        <br />
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <asp:Button ID="btnSend" runat="server" Text="Send/Submit" OnClick="btnSend_Click" />
        </div>
    </form>
</body>
</html>
