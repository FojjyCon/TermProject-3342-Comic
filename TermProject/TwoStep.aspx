<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoStep.aspx.cs" Inherits="TermProject.TwoStep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">


    <style>
        body{
            background-image: url("imgs/marvel.jpg");
        }
        .card{
            position: absolute;
            top:15vh;
        }
        .input-group{
            align-content: center;
        }
    </style>

</head>
<body style="text-align:center">
    <form id="form1" runat="server" style="text-align:center">
        <div class="container">
            <div class="d-flex justify-content-around-center h-100">
                <div class="card shadow-lg bg-dark text-light rounded border-dark">
                    <div class="card-header">
                        <h2>Verification Page</h2>
                        <p>Input your username and password below then click the 'Verify' button to verify your account.</p>
                        <asp:Label ID="lblErrorOccured" runat="server" Text="Username or Passoword is invalid. Please try again."></asp:Label>
                    </div>
                    <br />
                    <div class="card-body">
                        <div class="input-group form-group">
                            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                            <asp:TextBox ID="txtUsernameInput" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                            <asp:TextBox ID="txtPasswordInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="btnCheckAccountExistence" runat="server" Text="Check Account Existence" OnClick="btnCheckAccountExistence_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        <br />
                        <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                    </div>

                </div> <%--card--%>
            </div> <%--d-flex--%>
        </div><%--container--%>

    </form>
</body>
</html>
