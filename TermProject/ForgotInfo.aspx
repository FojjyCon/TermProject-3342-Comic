<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotInfo.aspx.cs" Inherits="TermProject.ForgotInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    
    <style>
        body{
            background-image: url("imgs/229965.jpg");
        }
        .card{
            position: absolute;
            top:15vh;
        }
        .input-group{
            padding: 10px;
        }
    </style>

</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        s<div class="container" style="text-align:center">
            <div class="d-flex justify-content-center h-100">
                <div class="card shadow-lg bg-dark text-light rounded border-dark wi">
                    <div class="card-header">
                        <h2>Forgot Password Page</h2>
                    </div>
                    <div class="card-body">
                        <div class="input-group form-group">
                            <asp:Label ID="lblEmailInput" runat="server" Text="Enter Email: "></asp:Label>
                            <asp:TextBox ID="txtEmailInput" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnCheckEmail" runat="server" Text="Check Email" OnClick="btnCheckEmail_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                        <br />
                        <div class="input-group form-group">
                            <asp:Label ID="lblSecurityHeader" runat="server" Text="Security Question"></asp:Label>
                        </div>
                        <div class="input-group form-group">
                            <asp:Label ID="lblQuestion" runat="server" Text="question"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSend" runat="server" Text="Send/Submit" OnClick="btnSend_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
