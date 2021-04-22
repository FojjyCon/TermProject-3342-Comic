<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComicAddFunds.ascx.cs" Inherits="TermProject.ComicAddFunds" %>

<asp:Button ID="btnAddMoney" runat="server" Text="Add Money" OnClick="btnAddMoney_Click" />
<br />
<asp:TextBox ID="txtAddMoney" runat="server" placeholder="Input an amount"></asp:TextBox>
<br />
<asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" />
<asp:Button ID="btnSubmit" runat="server" Text="Ok" OnClick="btnSubmit_Click" />