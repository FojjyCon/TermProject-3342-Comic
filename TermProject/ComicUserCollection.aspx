<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUserCollection.aspx.cs" Inherits="TermProject.ComicUserCollection" %>

<%@ Register Src="~/ComicAddFunds.ascx" TagPrefix="uc1" TagName="ComicAddFunds" %>



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
        <!-- sidebar -->
        <div class="d-flex" id="wrapper">
            <div class="bg-dark border-right" id="sidebar-wrapper">
                <div class="sidebar-heading text-center">
                    <asp:Image ID="imgUserAvatar" runat="server" ImageUrl="" Width="85" Height="85" CssClass="rounded" />
                    <br />
                    <asp:Label ID="lblComicUserName" runat="server" Text="Username" CssClass="text-light"></asp:Label>
                    <br />
                    <asp:Label ID="lblAccountBalance" runat="server" Text="Balance" CssClass="text-light"></asp:Label>
                </div>
                <div class="sidebar-heading text-center">
                    <asp:Button ID="Button1" runat="server" Text="Add Comic" OnClick="btnAddComic_Click" class="btn btn-outline-light my-2 my-sm-0"/>
                    <br />
                    <br />
                    <uc1:ComicAddFunds runat="server" id="ComicAddFunds1" class="form-control mr-sm-2"/>
                </div>
            </div>
        

            <div id="page-content-wrapper">
                <%-- Header --%>
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark border-botton">
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
                    <asp:ListView ID="lvMyComics" runat="server" Style="text-align:center" DataKeyNames="ComicId" OnSelectedIndexChanged="lvMyComics_SelectedIndexChanged">
                        <AlternatingItemTemplate>
                            <td runat="server" style="text-align:center">
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                <asp:Image ID="CoverUrlImage" runat="server" style="height: 220px; width: 170px;" ImageUrl='<%# Eval("CoverUrl") %>'/>
                                <br />
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                <br />
                                <asp:Label ID="CreatorsLabel" runat="server" Text='<%# Eval("Creators") %>' />
                                <br />
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                                <br />
                                <asp:Label ID="ResalePriceLabel" runat="server" Text='<%# Eval("ResalePrice") %>' />
                                <br />
                            </td>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <td runat="server" style="text-align:center">
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                <asp:Image ID="CoverUrlImage" runat="server" style="height: 220px; width: 170px;" ImageUrl='<%# Eval("CoverUrl") %>'/>
                                <br />
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                                <br />
                                <asp:TextBox ID="CreatorsTextBox" runat="server" Text='<%# Bind("Creators") %>' />
                                <br />
                                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                <br />
                                <asp:TextBox ID="ResalePriceTextBox" runat="server" Text='<%# Bind("ResalePrice") %>' />
                                <br />               
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table style="">
                                <tr>
                                    <td>No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <td runat="server" style="text-align:center">
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                <asp:Image ID="CoverUrlImage" runat="server" style="height: 220px; width: 170px;" ImageUrl='<%# Bind("CoverUrl") %>'/>
                                <br />
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                                <br />
                                <asp:TextBox ID="CreatorsTextBox" runat="server" Text='<%# Bind("Creators") %>' />
                                <br />
                                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                <br />
                                <asp:TextBox ID="ResalePriceTextBox" runat="server" Text='<%# Bind("ResalePrice") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />

                            </td>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <td runat="server" style="text-align:center">
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                <asp:Image ID="CoverUrlImage" runat="server" style="height: 220px; width: 170px;" ImageUrl='<%# Eval("CoverUrl") %>'/>
                                <br />
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                <br />
                                <asp:Label ID="CreatorsLabel" runat="server" Text='<%# Eval("Creators") %>' />
                                <br />
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                                <br />
                                <asp:Label ID="ResalePriceLabel" runat="server" Text='<%# Eval("ResalePrice") %>' />
                                <br />
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server" border="0" style="">
                                <tr runat="server" id="itemPlaceholderContainer">
                                    <td runat="server" id="itemPlaceholder">
                                    </td>
                                </tr>
                            </table>
                            <div style="">
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>
                </div>

                <div class="container-fluid">
                    <asp:Label ID="lblAddTitle" runat="server" Text="Label"> <h3>Input Comic Information</h3></asp:Label>
                    <asp:Label ID="lblCoverUrl" runat="server" Text="Comic Cover Image URL: " Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtCoverUrl" runat="server" class="form-control my-2 my-sm-0" width="256px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblTitle" runat="server" Text="Title:" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtTitle" runat="server" class="form-control my-2 my-sm-0" placeholder="Title" aria-label="Title" aria-describedby="basic-addon1"  width="256px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblCreators" runat="server" Text="Creator(s): " class="mr-sm-2" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtCreators" runat="server" class="form-control my-2 my-sm-0" Width="256px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblDescription" runat="server" Text="Description: " class="mr-sm-2" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" class="form-control my-2 my-sm-0" Width="256px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblResalePrice" runat="server" Text="Resale Price:" class="mr-sm-2" Font-Bold="true" ></asp:Label>
                    <asp:TextBox ID="txtResalePrice" runat="server" class="form-control my-2 my-sm-0" Width="256px" ></asp:TextBox>
                    <br />
                    <asp:Button ID="btnCreate" runat="server" Text="Create" class="btn btn-dark" OnClick="btnCreate_Click" />
                </div>

                <%-- displays the comic details --%>
                <div class="container-fluid">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
