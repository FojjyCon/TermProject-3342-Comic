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
        <!--
        <%-- header --%>
        <header>
            <div class="navbar navbar-expand-lg navbar-light bg-dark border-botton">
                <div class="text-center">
                    <h1 class="navbar-brand text-light">Comic Book Admin Panel</h1>
                </div>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <div class="form-inline mt-2 mt-md-0">
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-outline-danger " 
                             style="position:relative; float:right; margin-right:63px;" OnClick="btnLogout_Click" />
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
                                HeaderStyle-CssClass="gridHeader"  RowStyle-CssClass="inputRows"
                                cellpadding="10" cellspacing="5" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="gvComicAccounts_SelectedIndexChanged" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectAccount" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Avatar" HeaderText="Avatar" />
                                    <asp:BoundField DataField="Username" HeaderText="UserName" />
                                    <asp:BoundField DataField="HomeAddress" HeaderText="Home Address" />
                                    <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                    <asp:BoundField DataField="Money" HeaderText="Current Wallets" />
                                    <asp:BoundField DataField="BanStatus" HeaderText="Active" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </asp:GridView>
                        </div>
                        <hr />

                        <div>
                            <h3 class="text-center">Comic Book Posts</h3>
                            <asp:GridView ID="gvComicBooks" runat="server" CssClass="gridStyle" PagerStyle-CssClass="gridPager"  
                                RowStyle-CssClass="inputRows" HeaderStyle-CssClass="gridHeader" OnRowCommand="gvComicBooks_RowCommand" 
                                cellpadding="10" cellspacing="5" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="gvComicBooks_SelectedIndexChanged" HorizontalAlign="Center">
                                <Columns>
                                    <asp:ButtonField Text="View Comic"/>
                                    <asp:BoundField DataField="Title" HeaderText="Comic Title" />
                                    <asp:BoundField DataField="Creators" HeaderText="Creator(s)" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="RetailPrice" HeaderText="Retail Price" />
                                    <asp:BoundField DataField="ResalePrice" HeaderText="Resale Price" />
                                    <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </asp:GridView>
                            <asp:Label ID="lblEmptycomicBook" runat="server" Text="No comic books listed." OnSelectedIndexChanged="" ></asp:Label>
                        </div>

                        <%-- displays the comic details --%>
                        <div class="container-fluid">

                        </div>
                    </div>
                </div>
            </div>
        </main>
        -->
        <%-- header --%>
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
                                <asp:Button ID="Button2" runat="server" Text="Ban" class="btn btn-danger" OnClick="btnBan_Click" />
                                &nbsp
                                <asp:Button ID="Button3" runat="server" Text="Unban" class="btn btn-success" OnClick="btnUnban_Click" />
                                <br />
                                <br />
                            </div>

                            <asp:GridView ID="GridView1" runat="server" CssClass="gridStyle" PagerStyle-CssClass="gridPager"
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
                                    <asp:BoundField DataField="Username" HeaderText="User Name" />
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                    <asp:BoundField DataField="Money" HeaderText="Current Wallets" />
                                    <asp:BoundField DataField="HomeAddress" HeaderText="Home Address" />
                                    <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
                                    <asp:BoundField DataField="BanStatus" HeaderText="Active" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </asp:GridView>
                        </div>
                        <hr />

                        <div>
                            <h3 class="text-center">Comic Book Posts</h3>
                            <asp:GridView ID="GridView2" runat="server" CssClass="gridStyle" RowStyle-CssClass="inputRows" HeaderStyle-CssClass="gridHeader" CellPadding="10" CellSpacing="5" AutoGenerateColumns="false" OnSelectedIndexChanged="gvComicBooks_SelectedIndexChanged" OnRowCommand="gvComicBooks_RowCommand" HorizontalAlign="Center" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnViewComic" runat="server" CommandName="ViewComic">View Comic</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Title" HeaderText="Comic Title" />
                                    <asp:BoundField DataField="Creators" HeaderText="Creator(s)" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="ResalePrice" HeaderText="Resale Price" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:GridView>
                            <asp:Label ID="Label1" runat="server" Text="No Comic Books listed."></asp:Label>
                        </div>

                        <%--<asp:BoundField DataField="RetailPrice" HeaderText="Retail Price" />--%>
                        <div class="container-fluid">
                            <asp:Label ID="lblAddTitle" runat="server" Text="Label"> <h3>Input Comic Information</h3></asp:Label>
                            <asp:Label ID="lblCoverUrl" runat="server" Text="Comic Cover Image URL: " Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtCoverUrl" runat="server" class="form-control my-2 my-sm-0" Width="256px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTitle" runat="server" Text="Title:" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtTitle" runat="server" class="form-control my-2 my-sm-0" placeholder="Title" aria-label="Title" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblCreators" runat="server" Text="Creator(s): " class="mr-sm-2" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtCreators" runat="server" class="form-control my-2 my-sm-0" Width="256px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblDescription" runat="server" Text="Description: " class="mr-sm-2" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtDescription" runat="server" class="form-control my-2 my-sm-0" Width="256px" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblResalePrice" runat="server" Text="Resale Price:" class="mr-sm-2" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtResalePrice" runat="server" class="form-control my-2 my-sm-0" Width="256px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" class="mr-sm-2" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control my-2 my-sm-0" Width="256px"></asp:TextBox>
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
