<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TermProject.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
        <div class="header">
            <h3>Sign Up Page</h3>
        </div>
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvatar" runat="server" Text="Avatar:"></asp:Label>
            <asp:DropDownList ID="ddlAvatar" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:Label ID="lblSecurityEmail" runat="server" Text="Security Email:"></asp:Label>
            <asp:TextBox ID="txtSecurityEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblHomeAddress" runat="server" Text="Home Address:"></asp:Label>
            <asp:TextBox ID="txtHomeAddress" runat="server"></asp:TextBox>
            <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:"></asp:Label>
            <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <asp:Label ID="lblMoney" runat="server" Text="$$ amount to start with:"></asp:Label>
            <asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="lblQuestion1" runat="server" Text="Security Question 1: What is the name of your first pet? "></asp:Label>
            <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuestion2" runat="server" Text="Security Question 2: Where did you go to elementary school? "></asp:Label>
            <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuestion3" runat="server" Text="Security Question 3: Where were you born? "></asp:Label>
            <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:RadioButtonList ID="rbUserAdmin" runat="server">
                <asp:ListItem>User</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <div>
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <asp:Button ID="btnBackToLogin" runat="server" Text="Back to Login" OnClick="btnBackToLogin_Click" />
        </div>
    </form>
</body>
</html>
