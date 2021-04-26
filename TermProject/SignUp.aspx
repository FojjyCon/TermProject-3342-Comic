<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TermProject.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    <style>
        body {
            background-image: url("imgs/dcMarvel.jpg");
        }
        .card{
            box-shadow: 5px 10px;
            top: 15vh;
            left: 0px;
        }
    </style>
</head>
 
<body style="text-align:center">
    <form id="form2" runat="server" style="text-align: center">
        <div class="container">
            <div class="d-flex justify-content-around-center h-100">
                <div class="card mx-auto shadow-lg bg-black rounded border-dark bg-dark text-light">
                    <div class="card-header">
                        <h3>Sign Up Page</h3>
                    </div>
                    <div class="card-body">
                        <div class="input-group form-group">
                            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                            <asp:Label ID="lblAvatar" runat="server" Text="Avatar:"></asp:Label>
                            <asp:DropDownList ID="ddlAvatar" runat="server" AutoPostBack ="true">
                                <asp:ListItem>blackWidow</asp:ListItem>
                                    <asp:ListItem>captain</asp:ListItem>
                                    <asp:ListItem>hawkeye</asp:ListItem>
                                    <asp:ListItem>hulk</asp:ListItem>
                                    <asp:ListItem>ironMan</asp:ListItem>
                                    <asp:ListItem>panther</asp:ListItem>
                                    <asp:ListItem>strange</asp:ListItem>
                                    <asp:ListItem>thor</asp:ListItem>
                                    <asp:ListItem>vision</asp:ListItem>
                                    <asp:ListItem Selected="True">witch</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>

                            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

                            <asp:Label ID="lblSecurityEmail" runat="server" Text="Security Email:"></asp:Label>
                            <asp:TextBox ID="txtSecurityEmail" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblHomeAddress" runat="server" Text="Home Address:"></asp:Label>
                            <asp:TextBox ID="txtHomeAddress" runat="server"></asp:TextBox>

                            <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:"></asp:Label>
                            <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>

                            <asp:Label ID="lblMoney" runat="server" Text="$$ amount to start with:"></asp:Label>
                            <asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="input-group form-group">
                                <asp:Label ID="lblQuestion1" runat="server" Text="Security Question 1: What is the name of your first pet? "></asp:Label>
                                <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-group form-group">
                                <asp:Label ID="lblQuestion2" runat="server" Text="Security Question 2: Where did you go to elementary school? "></asp:Label>
                                <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
                            </div>
                            <div class="input-group form-group">                        
                                <asp:Label ID="lblQuestion3" runat="server" Text="Security Question 3: Where were you born? "></asp:Label>
                                <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox>
                            </div>
                            <asp:RadioButtonList ID="rbUserAdmin" runat="server" Style="text-align: center; width: 100%">
                                <asp:ListItem>User</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" class="btn btn-outline-success my-2 my-sm-0"/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnBackToLogin" runat="server" Text="Back to Login" OnClick="btnBackToLogin_Click" class="btn btn-outline-warning my-2 my-sm-0"/>
                        </div>
                    </div>
                </div> <%-- card --%>
            </div> <%-- d-flex --%>
        </div> <%-- container --%>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
