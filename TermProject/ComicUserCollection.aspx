<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComicUserCollection.aspx.cs" Inherits="TermProject.ComicUserCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
                </div>
                <div class="sidebar-heading text-center">
                    <asp:Button ID="btnAddComic" runat="server" Text="Add+" OnClick="btnAddComic_Click" />
                </div>
                <div class="list-group list-group-flush text-center">
                    <asp:LinkButton ID="lbOwned" runat="server" CssClass="list-group-item list-group-item-action bg-dark text-light active" OnClick="LBOwned_Click">Owned Comics</asp:LinkButton>
                    <asp:LinkButton ID="lbSold" runat="server" CssClass="list-group-item list-group-item-action bg-dark text-light active" OnClick="LBSeller_Click">Sold Comics</asp:LinkButton>
                    <asp:LinkButton ID="lbDelete" runat="server" CssClass="list-group-item list-group-item-action bg-dark text-light active" OnClick="LBDelete_Click">Removed Comics</asp:LinkButton>
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
                    <asp:ListView ID="lvMyComics" runat="server" DataSourceID="dsPersonalComics" DataKeyNames="ComicId">
                        <AlternatingItemTemplate>
                            <td runat="server" style="">ComicId:
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                CoverUrl:
                                <asp:Label ID="CoverUrlLabel" runat="server" Text='<%# Eval("CoverUrl") %>' />
                                <br />
                                Title:
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                <br />
                                Creators:
                                <asp:Label ID="CreatorsLabel" runat="server" Text='<%# Eval("Creators") %>' />
                                <br />
                                Description:
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                                <br />
                                ResalePrice:
                                <asp:Label ID="ResalePriceLabel" runat="server" Text='<%# Eval("ResalePrice") %>' />
                                <br />
                                Quantity:
                                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                <br />
                                OwnerId:
                                <asp:Label ID="OwnerIdLabel" runat="server" Text='<%# Eval("OwnerId") %>' />
                                <br />
                            </td>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <td runat="server" style="">ComicId:
                                <asp:Label ID="ComicIdLabel1" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                CoverUrl:
                                <asp:TextBox ID="CoverUrlTextBox" runat="server" Text='<%# Bind("CoverUrl") %>' />
                                <br />
                                Title:
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                                <br />
                                Creators:
                                <asp:TextBox ID="CreatorsTextBox" runat="server" Text='<%# Bind("Creators") %>' />
                                <br />
                                Description:
                                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                <br />
                                ResalePrice:
                                <asp:TextBox ID="ResalePriceTextBox" runat="server" Text='<%# Bind("ResalePrice") %>' />
                                <br />
                                Quantity:
                                <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
                                <br />
                                OwnerId:
                                <asp:TextBox ID="OwnerIdTextBox" runat="server" Text='<%# Bind("OwnerId") %>' />
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
                            <td runat="server" style="">
                                CoverUrl:
                                <asp:TextBox ID="CoverUrlTextBox" runat="server" Text='<%# Bind("CoverUrl") %>' />
                                <br />
                                Title:
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                                <br />
                                Creators:
                                <asp:TextBox ID="CreatorsTextBox" runat="server" Text='<%# Bind("Creators") %>' />
                                <br />
                                Description:
                                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                <br />
                                ResalePrice:
                                <asp:TextBox ID="ResalePriceTextBox" runat="server" Text='<%# Bind("ResalePrice") %>' />
                                <br />
                                Quantity:
                                <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
                                <br />
                                OwnerId:
                                <asp:TextBox ID="OwnerIdTextBox" runat="server" Text='<%# Bind("OwnerId") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            </td>
                        </InsertItemTemplate>
                        <ItemTemplate>

                            <td runat="server" style="">ComicId:
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                CoverUrl:
                                <asp:Label ID="CoverUrlLabel" runat="server" Text='<%# Eval("CoverUrl") %>' />
                                <br />
                                Title:
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                <br />
                                Creators:
                                <asp:Label ID="CreatorsLabel" runat="server" Text='<%# Eval("Creators") %>' />
                                <br />
                                Description:
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                                <br />
                                ResalePrice:
                                <asp:Label ID="ResalePriceLabel" runat="server" Text='<%# Eval("ResalePrice") %>' />
                                <br />
                                Quantity:
                                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                <br />
                                OwnerId:
                                <asp:Label ID="OwnerIdLabel" runat="server" Text='<%# Eval("OwnerId") %>' />
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
                        <SelectedItemTemplate>
                            <td runat="server" style="">ComicId:
                                <asp:Label ID="ComicIdLabel" runat="server" Text='<%# Eval("ComicId") %>' />
                                <br />
                                CoverUrl:
                                <asp:Label ID="CoverUrlLabel" runat="server" Text='<%# Eval("CoverUrl") %>' />
                                <br />
                                Title:
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                                <br />
                                Creators:
                                <asp:Label ID="CreatorsLabel" runat="server" Text='<%# Eval("Creators") %>' />
                                <br />
                                Description:
                                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                                <br />
                                ResalePrice:
                                <asp:Label ID="ResalePriceLabel" runat="server" Text='<%# Eval("ResalePrice") %>' />
                                <br />
                                Quantity:
                                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                <br />
                                OwnerId:
                                <asp:Label ID="OwnerIdLabel" runat="server" Text='<%# Eval("OwnerId") %>' />
                                <br />
                            </td>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="dsPersonalComics" runat="server" ConnectionString="<%$ ConnectionStrings:sp21_3342_tuh16611ConnectionString %>" SelectCommand="TP_GrabOwnedComics" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="userId" SessionField="UserId" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
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
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" class="mr-sm-2" Font-Bold="true" ></asp:Label>
                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control my-2 my-sm-0" Width="256px" ></asp:TextBox>
                    <br />
                    <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-dark" OnClick="btnBack_Click" />
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
