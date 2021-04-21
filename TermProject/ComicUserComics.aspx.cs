using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using ComicLibrary;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using System.Collections;

namespace TermProject
{
    public partial class ComicUserComics : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        SearchSVC.Search proxy = new SearchSVC.Search();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                proxy = new SearchSVC.Search();
                lblComicUserName.Text = Session["Username"].ToString();
                imgUserAvatar.ImageUrl = Session["Avatar"].ToString();

                if (Session["UserId"] != null)
                {
                    lblEmpty.Text = "Check out the comics below. You can also add any of them to your cart.";

                    displayComics();
                }
            }
        }

        protected void btnNavHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserHome.aspx");
        }

        protected void btnNavComics_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserComics.aspx");
        }

        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCart.aspx");
        }

        protected void btnCollection_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCollection.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        protected void btnSearchComic_Click(object sender, EventArgs e)
        {
            String searchContent = txtSearchComic.Text;

            // getting the arrayList
            ArrayList comics = new ArrayList(proxy.SearchForComic(searchContent));

            gvComics.DataSource = comics;
            gvComics.DataBind();

            txtSearchComic.Text = "";

            if (comics.Count == 0)
            {
                Response.Write("<script>alert('There were no comics that relate to the information provided.')</script>");
            }
        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {

        }

        protected void gvComics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvComics_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int cartStatus = 1;
            
            // if (e.CommandName == **Whatever you named it**)

            String comicId = gvComics.Rows[rowIndex].Cells[1].Text;
            int stat = AddToCart(cartStatus.ToString(), comicId);
            if (stat >= 0)
            {
                // nothing happens here
            } else
            {
                Response.Write("<script>alert('Cannot add to cart.')</script>");
            }

            Response.Write("<script>alert('Item has been added to your cart.')</script>");
        }

        public void displayComics()
        {
            DataSet myData = GetAllComics();

            ArrayList comicArrayList = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            for (int i = 0; i < size; i++)
            {
                String comicId = myData.Tables[0].Rows[i]["ComicId"].ToString();
                String title = myData.Tables[0].Rows[i]["Title"].ToString();
                String creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                String description = myData.Tables[0].Rows[i]["Description"].ToString();
                String resalePrice = myData.Tables[0].Rows[i]["ResalePrice"].ToString();
                String ownerId = myData.Tables[0].Rows[i]["OwnerId"].ToString();

                Comic comic = new Comic();
                comic.ComicId = comicId;
                comic.Title = title;
                comic.Creators = creators;
                comic.Description = description;
                comic.ResalePrice = resalePrice;
                comic.OwnerId = ownerId;

                comicArrayList.Add(comic);
            }

            gvComics.DataSource = comicArrayList;
            gvComics.DataBind();

            if (size == 0)
            {
                gvComics.Visible = false;
                lblEmpty.Visible = true;
                lblEmpty.Text = "There are currently no comics in the system.";
            }
            else
            {
                gvComics.Visible = true;
                lblEmpty.Visible = false;
                lblEmpty.Text = "";
            }
        }

        public DataSet GetAllComics()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllComics";

            DataSet getGridView = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getGridView;
        }

        public int AddToCart(String cartStatus, String comicId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddingToCart";

            SqlParameter inputCartStatus = new SqlParameter("@cartStatus", cartStatus);
            inputCartStatus.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputCartStatus);

            SqlParameter inputComicId = new SqlParameter("@comicId", comicId);
            inputComicId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputComicId);

            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }
    }
}