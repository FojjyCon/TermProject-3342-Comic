<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUserList.aspx.cs" Inherits="TermProject.ComicUserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-content-wrapper">
            <%-- Header --%>
            <nav class="navbar navbar-expand-lg navbar-light bg-primary border-botton">
                <a class="navbar-brand text-light" href="#">Comic Book Service</a>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <div class="form-inline">
                                <asp:Button ID="btnNavHome" runat="server" Text="Home" class="form-control mr-sm-2" OnClick="btnNavHome_Click"/>
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
                <%-- Displays comic books --%>
                <asp:Label ID="lblEmpty" runat="server" Text="Comics"></asp:Label>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1"></asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sp21_3342_tuh16611ConnectionString %>" SelectCommand="SELECT [Title], [Creators], [Description], [RetailPrice], [ReleaseDate] FROM [TP_Comics] ORDER BY [Title]"></asp:SqlDataSource>
            </div>

            <%-- displays the comic details --%>
            <div class="container-fluid">
            </div>
        </div>
    </form>
</body>
</html>
