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
    public partial class ComicUserCollection : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblComicUserName.Text = Session["Username"].ToString();
                imgUserAvatar.ImageUrl = Session["Avatar"].ToString();

                float grabbedBalance = float.Parse(Session["Money"].ToString());
                lblAccountBalance.Text = String.Format("{0:C}", grabbedBalance);

                addComicToolsShow(false);
                if (Session["UserId"] != null)
                {
                    addComicToolsShow(false);

                    int userId = Int32.Parse(Session["UserId"].ToString());

                    // getting all emails
                    DataSet myData = GrabOwnedComics(userId);

                    ArrayList comicList = new ArrayList();
                    //var list = new List<Comic>();
                    int size = myData.Tables[0].Rows.Count;
                    for (int i = 0; i < size; i++)
                    {
                        String comicId = myData.Tables[0].Rows[i]["ComicId"].ToString();
                        String coverUrl = myData.Tables[0].Rows[i]["CoverUrl"].ToString();
                        String title = myData.Tables[0].Rows[i]["Title"].ToString();
                        String creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                        String description = myData.Tables[0].Rows[i]["Description"].ToString();
                        String price = myData.Tables[0].Rows[i]["ResalePrice"].ToString();

                        float floatPrice = float.Parse(price);
                        String resalePrice = String.Format("{0:C}", floatPrice);

                        Comic comic = new Comic();
                        comic.ComicId = comicId;
                        comic.CoverUrl = coverUrl;
                        comic.Title = title;
                        comic.Creators = creators;
                        comic.Description = description;
                        comic.ResalePrice = resalePrice;

                        comicList.Add(comic);
                    }

                    lvMyComics.DataSource = comicList;
                    lvMyComics.DataBind();
                    lvMyComics.Visible = true;
                }
            }
        }

        protected void btnAddoney_Click(object sender, EventArgs e)
        {

        }

        protected void btnCollection_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCollection.aspx");
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

        protected void btnSearchComic_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {
            
            addComicToolsShow(false);
            
        }

        protected void LBDelete_Click(object sender, EventArgs e)
        {
            addComicToolsShow(false);
           
        }

        protected void btnAddComic_Click(object sender, EventArgs e)
        {
            lvMyComics.Visible = false;
            addComicToolsShow(true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            addComicToolsShow(false);
            lvMyComics.Visible = true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            addComicToolsShow(false);

            String coverUrl = txtCoverUrl.Text;
            String title = txtTitle.Text;
            String creators = txtCreators.Text;
            String description = txtDescription.Text;
            float resaleprice = float.Parse(txtResalePrice.Text);
            int ownerId = Int32.Parse(Session["UserId"].ToString());

            // creating a whole comic
            createComic(coverUrl, title, creators, description, resaleprice, ownerId);
            Response.Redirect("ComicUserCollection.aspx");
        }

        public void addComicToolsShow(bool tf)
        {
            if (tf == true)
            {
                lblAddTitle.Visible = true;

                lblCoverUrl.Visible = true;
                txtCoverUrl.Visible = true;

                lblTitle.Visible = true;
                txtTitle.Visible = true;

                lblCreators.Visible = true;
                txtCreators.Visible = true;

                lblDescription.Visible = true;
                txtDescription.Visible = true;

                lblResalePrice.Visible = true;
                txtResalePrice.Visible = true;

                //btnBack.Visible = true;
                btnCreate.Visible = true;
            } else
            {
                lblAddTitle.Visible = false;

                lblCoverUrl.Visible = false;
                txtCoverUrl.Visible = false;

                lblTitle.Visible = false;
                txtTitle.Visible = false;

                lblCreators.Visible = false;
                txtCreators.Visible = false;

                lblDescription.Visible = false;
                txtDescription.Visible = false;

                lblResalePrice.Visible = false;
                txtResalePrice.Visible = false;

                //btnBack.Visible = false;
                btnCreate.Visible = false;
            }
        }

        public DataSet GrabComicOwnerInfo(int userId, String comicTag)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GrabComicOwnerInfo";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            SqlParameter inputComicTag = new SqlParameter("@comicTag", comicTag);
            inputComicTag.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputComicTag);

            DataSet getGridView = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getGridView;
        }

        public DataSet GrabOwnedComics(int userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GrabOwnedComics";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public void createComic(String coverUrl, String title, String creators, String description, 
            float resalePrice, int ownerId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateComic";

            SqlParameter inputUrl = new SqlParameter("@coverURL", coverUrl);
            inputUrl.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUrl);


            SqlParameter inputTitle = new SqlParameter("@title", title);
            inputTitle.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputTitle);

            SqlParameter inputCreators = new SqlParameter("@creators", creators);
            inputCreators.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputCreators);

            SqlParameter inputDescription = new SqlParameter("@description", description);
            inputDescription.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputDescription);

            SqlParameter inputResalePrice = new SqlParameter("@resalePrice", resalePrice);
            inputResalePrice.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputResalePrice);

            SqlParameter inputOwnerId = new SqlParameter("@ownerId", ownerId);
            inputOwnerId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputOwnerId);

            dBConnect.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet getEmailId(int userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetEmailIdWithUserId";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            DataSet getIt = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getIt;
        }

        protected void gvComics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvComics_RowCommand(object sender, EventArgs e)
        {



        }

        protected void lvMyComics_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void lvMyComics_SelectedIndexChanged(object sender, ListViewSelectEventArgs e)
        {
        }
    }
}