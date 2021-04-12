<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUserHome.aspx.cs" Inherits="TermProject.ComicUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex" id="wrapper">
            <div class="bg-primary border-right text-dark" id="sidebar-wrapper">
                <asp:Image ID="ComicUserAvater" runat="server" ImageUrl="" Width="85" Height="85" CssClass="rounded" />
                <br />
                <asp:Label ID="lblComicUserName" runat="server" Text="User" CssClass="text-light"></asp:Label>"
           
            </div>
            <div class="list-group list-group-flush text-center">
                <asp:LinkButton ID="LBOwned" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active" OnClick="LBOwned_Click">Owned Comics</asp:LinkButton>
                <asp:LinkButton ID="LBSeller" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active" OnClick="LBSeller_Click">Selling Comics</asp:LinkButton>
                <asp:LinkButton ID="LBBuyer" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active" OnClick="LBBuyer_Click">Buyer Comics</asp:LinkButton>
                <asp:LinkButton ID="LBShoppingCart" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active" OnClick="LBShoppingCart_Click">Shopping Cart</asp:LinkButton>
                <asp:LinkButton ID="LBDelete" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active" OnClick="LBDelete_Click">Deleted Comics</asp:LinkButton>
            </div>
        </div>

        <div id="page-content-wrapper">
            <%-- Header --%>
            <nav class="navbar navbar-expand-lg navbar-light bg-primary border-botton">
                <a class="navbar-brand text-light" href="#">Comic Book Service</a>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:Button ID="btnNavHome" runat="server" Text="Home" class="form-control mr-sm-2"/>
                            </div>
                        </li>
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:Button ID="btnNavComics" runat="server" Text="Comics" class="form-control mr-sm-2" OnClick="btnNavComics_Click" />
                            </div>
                        </li>
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:Button ID="btnShoppingCart" runat="server" Text="Shopping Cart" class="form-control mr-sm-2" OnClick="btnShoppingCart_Click" />
                            </div>
                        </li>
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:Button ID="btnPersonal" runat="server" Text="Personal" class="form-control mr-sm-2" OnClick="btnPersonal_Click" />
                            </div>
                        </li>
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:TextBox ID="txtSearchComic" runat="server" class="form-control mr-sm-2" placeholder="Search Comic" aria-label="Search Comic"></asp:TextBox>
                                <asp:Button ID="btnSearchComic" runat="server" Text="Search" class="btn btn-outline-light my-2 my-sm-0" OnClick="btnSearchComic_Click" />
                            </div>
                        </li>
                    </ul>
                    <div class="form-inline mt-2 mt-md-0">
                        &nbsp
                    
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-outline-danger my-2 my-sm-0" OnClick="btnLogout_Click" />
                    </div>
                </div>
            </nav>
            <%-- Comic Content --%>
            <div class="container-fluid">
                <div class="dropdown">
                </div>
                <%-- Displays comic books --%>
                <asp:Label ID="lblEmpty" runat="server" Text="Comic book is missing"></asp:Label>
                <asp:GridView ID="gvComicView" runat="server" AutoGenerateColumns="false" GridLines="Horizontal" CssClass="table table-hover" BorderStyle="None" ShowHeader="false" OnSelectedIndexChanged="gvComicView_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelectEmail" runat="server" AutoPostBack="true" CssClass="gridStyle" PagerStyle-CssClass="gridPager" HeaderStyle-CssClass="gridHeader" OnCheckedChanged="chkSelectEmail_CheckedChanged" />
                            </ItemTemplate>
                            <ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:ButtonField Text="View Comic" />
                        <asp:BoundField DataField="Title" HeaderText="Title">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Creators" HeaderText="Creator">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RetailPrice" HeaderText="Retail Price">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ResalePrice" HeaderText="Resale Price">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date">
                            <ItemStyle Width="200px" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle VerticalAlign="Middle" />
                </asp:GridView>
            </div>

            <%-- Comic info/add portion --%>
            <div class="container-fluid">
                <asp:Label ID="lblComicTitle" runat="server" Text="Comic Title"></asp:Label>
                <br />
                <asp:Label ID="lblTitle" runat="server" Text="Comic Title: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblCreator" runat="server" Text="Comic Creator(s): " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblRetailprice" runat="server" Text="Comic Retail Price: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblResalePrice" runat="server" Text="Comic Resale Price: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblReleaseDate" runat="server" Text="Comic Release Date: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Comic Description: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <br />
                <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary" OnClick="btnBack_Click" />
                <asp:Button ID="btnAddComic" runat="server" Text="Add!" class="btn btn-primary" OnClick="btnAddComic_Click" />
            </div>

            <%-- displays the comic details --%>
            <div class="container-fluid">
            </div>
        </div>
    </form>
</body>
</html>
