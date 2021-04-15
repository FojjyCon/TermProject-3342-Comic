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


                addComicToolsShow(false);
                if (Session["UserId"] != null)
                {
                    showEmailClient();
                }
            }


            addComicToolsShow(false);
        }

        public void showEmailClient()
        {
            Session["Tag"] = "Owned";
            String tagName = "Owned";
            int userId = Int32.Parse(Session["UserId"].ToString());

            // grabbing tag Id
            DataSet getTag = grabTagId(userId, tagName);
            String comicTag = getTag.Tables[0].Rows[0]["TagId"].ToString();

            // Username and Avatar Display
            lblComicUserName.Text = Session["Username"].ToString();
            imgUserAvatar.ImageUrl = Session["Avatar"].ToString();

            DataSet comicInfo = GrabComicOwnerInfo(userId, comicTag);

            int size = comicInfo.Tables[0].Rows.Count;
            if (size > 0)
            {
                var comicList = new List<Comic>();
                for (int i = 0; i < size; i++)
                {

                    Comic comic = new Comic();
                    comic.CoverUrl = comicInfo.Tables[0].Rows[0]["CoverUrl"].ToString();
                    comic.Title = comicInfo.Tables[0].Rows[i]["Title"].ToString();
                    comic.Creators = comicInfo.Tables[0].Rows[i]["Creators"].ToString();
                    comic.Description = comicInfo.Tables[0].Rows[i]["Description"].ToString();
                    comic.ResalePrice = comicInfo.Tables[0].Rows[i]["ResalePrice"].ToString();
                    comic.Quantity = comicInfo.Tables[0].Rows[i]["Quantity"].ToString();

                    comicList.Add(comic);
                }

                lvMyComics.DataSource = comicList;
                lvMyComics.DataBind();
                lvMyComics.Visible = true;

            }
            else
            {
                lblEmpty.Text = "Your search content is empty";
                lblEmpty.Visible = true;
                lvMyComics.Visible = false;
            }
            txtSearchComic.Text = "";
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
            addComicToolsShow(false);
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
            addComicToolsShow(true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            addComicToolsShow(false);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            addComicToolsShow(false);

            String coverUrl = txtCoverUrl.Text;
            String title = txtTitle.Text;
            String creators = txtCreators.Text;
            String description = txtDescription.Text;
            float resaleprice = float.Parse(txtResalePrice.Text);
            int quantity = Int32.Parse(txtQuantity.Text);
            int ownerId = Int32.Parse(Session["UserId"].ToString());

            // creating a whole comic
            createComic(coverUrl, title, creators, description, resaleprice, quantity, ownerId);

            // grabbing comicId based on userId
            DataSet getIt = getEmailId(ownerId);
            int comicId = Int32.Parse(getIt.Tables[0].Rows[0]["ComicId"].ToString());

            // grabbing 'owner' tagId for the owner of the comic
            String tagName = "Owned";
            DataSet myData = grabTagId(ownerId, tagName);
            int tagId = Int32.Parse(myData.Tables[0].Rows[0]["TagId"].ToString());

            // inserting receipt (comic is now owned by this user)
            receiptInsert(ownerId, comicId, tagId);

        }

        /*
        public void populateTags()
        {
            String userId = Session["UserId"].ToString();
            DataSet myData = grabForPopulateTags(userId);

            ArrayList tags0 = new ArrayList();
            ArrayList tags = new ArrayList();
            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Tag tag0 = new Tag();
                    Tag tag = new Tag();
                    String tagName = myData.Tables[0].Rows[i]["TagName"].ToString();

                    if (tagName.CompareTo("Sold") == 0)
                    {
                        // do nothing 
                    }
                    else
                    {
                        tag0.TagName = tagName;
                        tags0.Add(tag0);
                    }
                    if (tagName.CompareTo("Owned") == 0 || tagName.CompareTo("Sold") == 0 ||
                        tagName.CompareTo("Removed") == 0)
                    {
                        // do nothing 
                    }
                    else
                    {
                        tag.TagName = tagName;
                        tags.Add(tag);
                    }
                }
            }

        }
        */
        /*
        public DataSet grabForPopulateTags(String userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_PopulateTags";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            DataSet getTagName = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getTagName;
        }
        */

        public void addComicToolsShow(bool tf)
        {
            if (tf == true)
            {
                lblAddTitle.Visible = true;

                lblTitle.Visible = true;
                txtTitle.Visible = true;

                lblCreators.Visible = true;
                txtCreators.Visible = true;

                lblDescription.Visible = true;
                txtDescription.Visible = true;

                lblResalePrice.Visible = true;
                txtResalePrice.Visible = true;

                lblQuantity.Visible = true;
                txtQuantity.Visible = true;

                btnBack.Visible = true;
                btnCreate.Visible = true;
            } else
            {
                lblAddTitle.Visible = false;

                lblTitle.Visible = false;
                txtTitle.Visible = false;

                lblCreators.Visible = false;
                txtCreators.Visible = false;

                lblDescription.Visible = false;
                txtDescription.Visible = false;

                lblResalePrice.Visible = false;
                txtResalePrice.Visible = false;

                lblQuantity.Visible = false;
                txtQuantity.Visible = false;

                btnBack.Visible = false;
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

        public void createComic(String coverUrl, String title, String creators, String description, float resalePrice, 
            int quantity, int ownerId)
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

            SqlParameter inputQuantity = new SqlParameter("@quantity", quantity);
            inputQuantity.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputQuantity);

            SqlParameter inputOwnerId = new SqlParameter("@ownerId", ownerId);
            inputOwnerId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputOwnerId);

            dBConnect.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet grabTagId(int userId, String tagName)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GrabTagId";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            SqlParameter inputTagName = new SqlParameter("@tagName", tagName);
            inputTagName.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputTagName);

            DataSet getTagId = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getTagId;
        }

        public void receiptInsert(int userId, int comicId, int comicTag)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ecSentRecipInsert";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            SqlParameter inputComicId = new SqlParameter("@inputEmailIdRecip", comicId);
            inputComicId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputComicId);

            SqlParameter inputComicTag = new SqlParameter("@comicTag", comicTag);
            inputComicTag.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputComicTag);

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
    }
}