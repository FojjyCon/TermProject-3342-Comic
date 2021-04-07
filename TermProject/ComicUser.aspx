<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUser.aspx.cs" Inherits="TermProject.ComicUser" %>

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
            <div class="sidebar-heading text-center">
                <asp:Button ID="btnNewComic" runat="server" Text="List Comic" class="btn btn-outline-light" />
            </div>
            <div class="list-group list-group-flush text-center">
                <asp:LinkButton ID="LBOwned" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active">Owned Comics</asp:LinkButton>
                <asp:LinkButton ID="LBSeller" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active">Selling Comics</asp:LinkButton>
                <asp:LinkButton ID="LBBuyer" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active">Buyer Comics</asp:LinkButton>
                <asp:LinkButton ID="LBShoppingCart" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active">Shopping Cart</asp:LinkButton>
                <asp:LinkButton ID="LBDelete" runat="server" CssClass="list-group-item list-group-item-action bg-primary text-light active">Deleted Comics</asp:LinkButton>
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
                                <asp:TextBox ID="txtSearchComic" runat="server" class="form-control mr-sm-2" placeholder="Search Comic" aria-label="Search Comic"></asp:TextBox>
                                <asp:Button ID="btnSearchComic" runat="server" Text="Search" class="btn btn-outline-light my-2 my-sm-0" />
                            </div>
                        </li>
                    </ul>
                    <div class="form-inline mt-2 mt-md-0">
                        &nbsp
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-outline-danger my-2 my-sm-0" />
                    </div>
                </div>
            </nav>
            <%-- Comic Content --%>
            <div class="container-fluid">
                <div class="dropdown">
                </div>
                <%-- Displays comic books --%>
                <asp:Label ID="lblEmpty" runat="server" Text="Comic book is missing"></asp:Label>
                <asp:GridView ID="gvComicView" runat="server" AutoGenerateColumns="false" GridLines="Horizontal" CssClass="table table-hover" BorderStyle="None" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelectEmail" runat="server" AutoPostBack="true" CssClass="gridStyle" PagerStyle-CssClass="gridPager" HeaderStyle-CssClass="gridHeader" />
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

            <%-- Adding new comic book --%>
            <div class="container-fluid">
                <asp:Label ID="lblComicTitle" runat="server"> <h3>Add Your Comic Book!</h3> </asp:Label>
                <asp:Label ID="lblTitle" runat="server" Text="Comic Title: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtComicTitle" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Title" aria-label="Comic book title" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                <br />
                <asp:Label ID="lblCreator" runat="server" Text="Comic Creator(s): " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtComicCreator" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Creators" aria-label="Creator Name(s)" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                <br />
                <asp:Label ID="lblRetailprice" runat="server" Text="Comic Retail Price: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtRetailPrice" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Retail Price" aria-label="Comic retail Price" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                <br />
                <asp:Label ID="lblResalePrice" runat="server" Text="Comic Resale Price: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtResalePrice" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Resale Price" aria-label="Comic resale Price" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                <br />
                <asp:Label ID="lblReleaseDate" runat="server" Text="Comic Release Date: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Release Date" aria-label="Comic release date" aria-describedby="basic-addon1" Width="256px"></asp:TextBox>
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Comic Description: " CssClass="mr-sm-2" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txt" runat="server" CssClass="form-control my-2 my-sm-0" placeholder="Description" aria-label="Comic Description" aria-describedby="basic-addon1" Height="256px" TextMode="MultiLine" Width="960px"></asp:TextBox>
                <br />
                <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary"  />
                <asp:Button ID="btnAddComic" runat="server" Text="Add!" class="btn btn-primary" />
            </div>

            <%-- displays the comic details --%>
            <div class="container-fluid">

            </div>
        </div>
    </form>
</body>
</html>
