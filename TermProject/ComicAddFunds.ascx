<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComicAddFunds.ascx.cs" Inherits="TermProject.ComicAddFunds" %>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<br />
<asp:Button ID="btnAddMoney" runat="server" Text="Add Money" OnClick="btnAddMoney_Click" class="btn btn-outline-light my-2 my-sm-0"/>
<br />

<asp:TextBox ID="txtAddMoney" runat="server" placeholder="Input an amount"></asp:TextBox>
<br />
<asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" class="btn btn-outline-light my-2 my-sm-0"/>
<asp:Button ID="btnSubmit" runat="server" Text="Ok" OnClick="btnSubmit_Click" class="btn btn-outline-light my-2 my-sm-0"/>