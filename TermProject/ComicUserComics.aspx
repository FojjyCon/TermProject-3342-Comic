<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUserComics.aspx.cs" Inherits="TermProject.ComicUserComics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/topNavbar.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex" id="wrapper">
            <!--sidebar-->
            <div class="bg-dark border-right" id="sidebar-wrapper">
                <div class="sidebar-heading text-center">
                    <asp:Image ID="imgUserAvatar" runat="server" ImageUrl="" Width="85" Height="85" CssClass="rounded" />
                    <br />
                    <asp:Label ID="lblComicUserName" runat="server" Text="Username" CssClass="text-light"></asp:Label>
                    <br />
                    <asp:Label ID="lblAccountBalance" runat="server" Text="Balance" CssClass="text-light"></asp:Label>
                </div>
            </div>

            <div id="page-content-wrapper">
                <%-- Header --%>
                <nav class="navbar navbar-expand-lg navbar-light bg-dark border-botton">
                    <a class="navbar-brand text-light" href="#">Comic Book Service</a>
                    <div class="collapse navbar-collapse" id="navbarCollapse">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <div class="form-inline">
                                    <asp:Button ID="btnNavHome" runat="server" Text="Home" class="form-control mr-sm-2" OnClick="btnNavHome_Click" />
                                </div>
                            </li>
                            <li class="nav-item">
                                <div class="form-inline">
                                    <asp:Button ID="btnCollection" runat="server" Text="Collection" class="form-control mr-sm-2" OnClick="btnCollection_Click" />
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
                <div class="container-fluid" style="text-align:center">
                    <%-- Displays comic books --%>
                    <asp:Label ID="lblEmpty" runat="server" Text="Comics"></asp:Label>
                    <br />
                    <asp:GridView ID="gvComics" runat="server" OnRowCommand="gvComics_RowCommand" OnSelectedIndexChanged="gvComics_SelectedIndexChanged" AutoGenerateColumns="False">
                        <Columns>
                            <asp:ButtonField Text="Add to Cart"/>
                            <asp:BoundField DataField="ComicId" HeaderText="ComicId" />
                            <asp:ImageField DataImageUrlField="CoverUrl" HeaderText="Cover" ControlStyle-Width="150px" ControlStyle-Height="180px">
                            <ControlStyle Height="180px" Width="150px"></ControlStyle>
                            </asp:ImageField>
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                            <asp:BoundField DataField="Creators" HeaderText="Creator(s)" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="ResalePrice" HeaderText="Resale Price" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="OwnerId" HeaderText="OwnerId" />
                        </Columns>
                    </asp:GridView>
                </div>

                <%-- displays the comic details --%>
                <div class="container-fluid">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
