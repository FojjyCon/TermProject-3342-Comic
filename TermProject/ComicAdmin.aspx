<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicAdmin.aspx.cs" Inherits="TermProject.ComicAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="navbar navbar-expand-lg navbar-light bg-dark border-botton ">
                <div class="text-center">
                    <h1 class="navbar-brand text-light">Comic Book Admin Panel</h1>
                </div>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <div class="form-inline mt-2 mt-md-0">
                        <asp:Button ID="Button1" runat="server" Text="Logout" class="btn btn-outline-danger "
                            Style="position: relative; float: right; margin-right: 63px;" OnClick="btnLogout_Click" />
                    </div>
                </div>
            </div>
        </header>

        <main role="main">
            <div class="container">
                <div class="row justify-content-center">
                    <div class=" col">
                        <div>
                            <br />
                            <h3 class="text-center">Comic Accounts</h3>
                            <div style="text-align: center;">
                                <asp:Button ID="btnBan" runat="server" Text="Ban" class="btn btn-danger" OnClick="btnBan_Click" />
                                &nbsp
                                <asp:Button ID="btnUnban" runat="server" Text="Unban" class="btn btn-success" OnClick="btnUnban_Click" />
                                <br />
                                <br />
                            </div>

                            <asp:GridView ID="gvComicAccounts" runat="server" CssClass="gridStyle" PagerStyle-CssClass="gridPager"
                                HeaderStyle-CssClass="gridHeader" RowStyle-CssClass="inputRows"
                                CellPadding="10" CellSpacing="5" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="gvComicAccounts_SelectedIndexChanged" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectAccount" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Avatar" HeaderText="Avatar" />
                                    <asp:BoundField DataField="Username" HeaderText="Username" />
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                    <asp:BoundField DataField="Money" HeaderText="Current Wallets" />
                                    <asp:BoundField DataField="HomeAddress" HeaderText="Home Address" />
                                    <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
                                    <asp:BoundField DataField="BanStatus" HeaderText="Active" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" />

                                <PagerStyle CssClass="gridPager"></PagerStyle>

                                <RowStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </asp:GridView>
                        </div>
                        <hr />

                        <div>
                            <h3 class="text-center">Comic Book Posts</h3>
                   
                            <asp:GridView ID="gvComicBooks" runat="server" CssClass="gridStyle" RowStyle-CssClass="inputRows" HeaderStyle-CssClass="gridHeader" CellPadding="10" CellSpacing="5" AutoGenerateColumns="False" OnSelectedIndexChanged="gvComicBooks_SelectedIndexChanged" OnRowCommand="gvComicBooks_RowCommand" HorizontalAlign="Center">
                                <Columns>
                                    <asp:ButtonField Text="Delete" />
                                    <asp:BoundField DataField="ComicId" HeaderText="ComicId" />
                                    <asp:ImageField DataImageUrlField="CoverUrl" HeaderText="Cover" ControlStyle-Width="150px" ControlStyle-Height="180px" >
                                    <ControlStyle Height="180px" Width="150px"></ControlStyle>
                                    </asp:ImageField>
                                    <asp:BoundField DataField="Title" HeaderText="Title" />
                                    <asp:BoundField DataField="Creators" HeaderText="Creator(s)" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="ResalePrice" HeaderText="Resale Price" />
                                    <asp:BoundField DataField="OwnerId" HeaderText="Owner" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:GridView>
                            <asp:Label ID="lblEmptyComicBook" runat="server" Text="No Comic Books listed."></asp:Label>
                        </div>

                        <footer class="footer">
                            <div class="container">
                                <span class="text-muted"></span>
                            </div>
                        </footer>

                    </div>
                </div>
            </div>
        </main>

    </form>
</body>
</html>
