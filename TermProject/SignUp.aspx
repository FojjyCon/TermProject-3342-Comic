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
            <asp:Label ID="lblQuestion1" runat="server" Text="Security Question 1: "></asp:Label>
            <asp:DropDownList ID="ddlQuestion1" runat="server">
                <asp:ListItem Value="q10">What is the name of your first pet?</asp:ListItem>
                <asp:ListItem Value="q11">Where did you go to elementary school?</asp:ListItem>
                <asp:ListItem Value="q12">Where were you born?</asp:ListItem>
                <asp:ListItem Value="q13">What is your mothers middle name?</asp:ListItem>
                <asp:ListItem Value="q14">What is your fathers middle name?</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuestion2" runat="server" Text="Security Question 2: "></asp:Label>
            <asp:DropDownList ID="ddlQuestion2" runat="server">
                <asp:ListItem Value="q20">What is the name of your first pet?</asp:ListItem>
                <asp:ListItem Value="q21">Where did you go to elementary school?</asp:ListItem>
                <asp:ListItem Value="q22">Where were you born?</asp:ListItem>
                <asp:ListItem Value="q23">What is your mothers middle name?</asp:ListItem>
                <asp:ListItem Value="q24">What is your fathers middle name?</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQuestion3" runat="server" Text="Security Question 3: "></asp:Label>
            <asp:DropDownList ID="ddlQuestion3" runat="server">
                <asp:ListItem Value="q30">What is the name of your first pet?</asp:ListItem>
                <asp:ListItem Value="q31">Where did you go to elementary school?</asp:ListItem>
                <asp:ListItem Value="q32">Where were you born?</asp:ListItem>
                <asp:ListItem Value="q33">What is your mothers middle name?</asp:ListItem>
                <asp:ListItem Value="q34">What is your fathers middle name?</asp:ListItem>
            </asp:DropDownList>
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
