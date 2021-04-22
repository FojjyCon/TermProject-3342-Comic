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
    public partial class ComicUserCart : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblComicUserName.Text = Session["Username"].ToString();
                imgUserAvatar.ImageUrl = Session["Avatar"].ToString();
                lblAccountBalance.Text = Session["Money"].ToString();

                if (Session["UserId"] != null)
                {
                    lblEmpty.Text = "Check out the comics below. You can also add any of them to your cart.";

                    displayCartItems();
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

        protected void gvComicView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkSelectEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        protected void btnSearchComic_Click(object sender, EventArgs e)
        {

        }

        protected void btnCollection_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCollection.aspx");
        }

        public void displayCartItems()
        {
            String userId = Session["UserId"].ToString();
            //String comicId = "";
            int inCart = 1;
            int total = 0;

            DataSet myData = GetCartItems(inCart.ToString());

            ArrayList comicArrayList = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            for (int i = 0; i < size; i++)
            {
                String comicId = myData.Tables[0].Rows[i]["ComicId"].ToString();
                String coverUrl = myData.Tables[0].Rows[i]["CoverUrl"].ToString();
                String title = myData.Tables[0].Rows[i]["Title"].ToString();
                String creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                String resalePrice = myData.Tables[0].Rows[i]["ResalePrice"].ToString();

                Comic comic = new Comic();
                comic.ComicId = comicId;
                comic.CoverUrl = coverUrl;
                comic.Title = title;
                comic.Creators = creators;
                comic.ResalePrice = resalePrice;

                total += Int32.Parse(resalePrice);

                comicArrayList.Add(comic);
            }

            gvComicCart.DataSource = comicArrayList;
            gvComicCart.DataBind();

            if (size == 0)
            {
                gvComicCart.Visible = false;
                lblTotal.Visible = false;
                lblTotalText.Visible = false;
                btnConfirmPurchase.Visible = false;

                lblEmpty.Visible = true;
                lblEmpty.Text = "There are currently no comics in your cart.";
            }
            else
            {
                lblTotal.Visible = true;
                lblTotalText.Visible = true;
                btnConfirmPurchase.Visible = true;

                gvComicCart.Visible = true;
                lblEmpty.Visible = false;
                lblEmpty.Text = "";
                lblTotalText.Text = total.ToString();
            }


            gvComicCart.Visible = true;
        }

        public void getCartTotal()
        {

        }

        protected void gvComicCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int cartStatus = 0;

            // if (e.CommandName == **Whatever you named it**)

            String title = gvComicCart.Rows[rowIndex].Cells[2].Text;
            int stat = setCartStatus(cartStatus.ToString(), title);
            if (stat >= 0)
            {
                // nothing happens here
            }
            else
            {
                Response.Write("<script>alert('Cannot add to cart.')</script>");
            }

            Response.Redirect(Request.RawUrl);
        }

        public DataSet GetCartItems(String inCart)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCartComics";

            SqlParameter inputInCart = new SqlParameter("@inCart", inCart);
            inputInCart.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputInCart);

            DataSet getGridView = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getGridView;
        }

        protected void gvComicCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfirmPurchase_Click(object sender, EventArgs e)
        {
            int inCart = 1;
            // grabs all info related to comic owner in cart
            DataSet myData = GetCurrentOwnerMoney(inCart.ToString());

            String userId = Session["UserId"].ToString();
            float totalCost = float.Parse(lblTotalText.Text);

            // grabs the buyers account info
            DataSet newOwnerMoney = GetUserMoney(userId);
            float moneyInAccount = float.Parse(newOwnerMoney.Tables[0].Rows[0]["Money"].ToString());
            
            if (moneyInAccount < totalCost)
            {
                Response.Write("<script>alert('Insufficient Funds')</script>");
            } 
            else
            {
                int size = myData.Tables[0].Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    float oldOwnerMoney = float.Parse(myData.Tables[0].Rows[i]["Money"].ToString());
                    float resalePrice = float.Parse(myData.Tables[0].Rows[i]["ResalePrice"].ToString());
                    String oldOwnerId = myData.Tables[0].Rows[i]["OwnerId"].ToString();

                    oldOwnerMoney += resalePrice;
                    
                    // updates the account balance for the seller of the comic book
                    UpdateNewOwnerMoney(oldOwnerId, oldOwnerMoney);

                }

                float newAccountTotal = moneyInAccount - totalCost;
                // updates the account balance for the buyer of the account 
                UpdateNewOwnerMoney(userId, newAccountTotal);
                // updates who the actual owner now is of the comic that was bought 
                UpdateComicOwner(userId);
                Session["Money"] = newAccountTotal;

                Response.Write("<script>alert('Comics Successfully Purchased!')</script>");
                Response.Redirect("ComicUserCollection.aspx");
            }

        }

        public void UpdateComicOwner(String userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateComicOwner";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            dBConnect.DoUpdateUsingCmdObj(objCommand);
        }

        public int setCartStatus(String cartStatus, String title)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RemoveFromCart";

            SqlParameter inputCartStatus = new SqlParameter("@cartStatus", cartStatus);
            inputCartStatus.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputCartStatus);
                
            SqlParameter inputTitle = new SqlParameter("@title", title);
            inputTitle.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputTitle);
            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }

        public DataSet GetOwnerAndComicId(String inCart)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AllCartInfo";

            SqlParameter inputInCart = new SqlParameter("@inCart", inCart);
            inputInCart.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputInCart);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public DataSet GetOldOwnerInfo(String inCart)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOldOwnerInfo";

            SqlParameter inputInCart = new SqlParameter("@inCart", inCart);
            inputInCart.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputInCart);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public DataSet GetNewOwnerInfo(String inCart)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetNewOwnerInfo";

            SqlParameter inputInCart = new SqlParameter("@inCart", inCart);
            inputInCart.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputInCart);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public DataSet GetUserMoney(String userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUserMoney";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public void UpdateNewOwnerMoney(String userId, float newAccountTotal)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateNewOwnerMoney";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            SqlParameter inputMoney = new SqlParameter("@newAccountTotal", newAccountTotal);
            inputMoney.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputMoney);
            dBConnect.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet GetCurrentOwnerMoney(String inCart)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCurrentOwnerMoney";

            SqlParameter inputInCart = new SqlParameter("@inCart", inCart);
            inputInCart.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputInCart);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }
    }
}