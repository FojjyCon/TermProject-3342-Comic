using ComicLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class ComicUserComics : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void btnPersonal_Click(object sender, EventArgs e)
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

        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {

        }

        protected void gvComics_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int cartStatus = 1;

            String title = gvComics.Rows[rowIndex].Cells[5].Text;
            String ownerId = gvComics.Rows[rowIndex].Cells[1].Text;
            int stat = setCartStatus(cartStatus.ToString(), title, ownerId);
            if (stat >= 0)
            {
                // nothing happens here
            }
            else
            {
                Response.Write("<script>alert('Cannot add to cart.')</script>");
            }

        }

        public void displayComics()
        {
            DataSet myData = GetAllComics();

            ArrayList comicArrayList = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            for (int i = 0; i < size; i++)
            {
                String title = myData.Tables[0].Rows[i]["Title"].ToString();
                String creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                String description = myData.Tables[0].Rows[i]["Description"].ToString();
                String resalePrice = myData.Tables[0].Rows[i]["ResalePrice"].ToString();
                String ownerId = myData.Tables[0].Rows[i]["OwnerId"].ToString();

                Comic comic = new Comic();
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

        public int setCartStatus(String cartStatus, String ownerId, String title)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddingToCart";

            SqlParameter inputCartStatus = new SqlParameter("@cartStatus", cartStatus);
            inputCartStatus.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputCartStatus);

            SqlParameter inputOwnerId = new SqlParameter("@ownerId", ownerId);
            inputOwnerId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputOwnerId);

            SqlParameter inputTitle = new SqlParameter("@title", title);
            inputTitle.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputTitle);
            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }
    }
}