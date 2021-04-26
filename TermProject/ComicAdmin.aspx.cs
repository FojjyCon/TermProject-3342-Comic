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
    public partial class ComicAdmin : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUsers();
                showListedComics();
            }
        }

        protected void btnUnban_Click(object sender, EventArgs e)
        {
            banUser("1");
        }

        protected void btnBan_Click(object sender, EventArgs e)
        {
            banUser("0");
        }

        protected void gvComicAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }


        protected void gvComicBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Comic comic = new Comic();
            
            comic.Title = gvComicBooks.SelectedRow.Cells[1].Text;
            comic.Creators = gvComicBooks.SelectedRow.Cells[2].Text;
            comic.Description = gvComicBooks.SelectedRow.Cells[3].Text;
            comic.ResalePrice = gvComicBooks.SelectedRow.Cells[4].Text;

            gvComicBooks.Visible = false;
        }

        protected void gvComicBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String comicId = gvComicBooks.Rows[rowIndex].Cells[1].Text;
            int ret = DeleteComic(comicId);
            if (ret > 0)
            {
                Response.Redirect("ComicAdmin.aspx");
            }
            else
            {
                Response.Write("<script>alert('Comic not deleted')</script>");
            }
        }

        public void showUsers()
        {
            DataSet myData = GetAllUsers();

            ArrayList userList = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    User users = new User();
                    users.Avatar = myData.Tables[0].Rows[i]["Avatar"].ToString();
                    users.Username = myData.Tables[0].Rows[i]["Username"].ToString();
                    users.HomeAddress = myData.Tables[0].Rows[i]["HomeAddress"].ToString();
                    users.BillingAddress = myData.Tables[0].Rows[i]["BillingAddress"].ToString();
                    users.EmailAddress = myData.Tables[0].Rows[i]["EmailAddress"].ToString();
                    users.Money = myData.Tables[0].Rows[i]["Money"].ToString();
                    if (myData.Tables[0].Rows[i]["BanStatus"].ToString().CompareTo("1") == 0)
                    {
                        users.BanStatus = "Is not banned";
                    }
                    else
                    {
                        users.BanStatus = "Banned";
                    }
                    userList.Add(users);
                }
                gvComicAccounts.DataSource = userList;
                gvComicAccounts.DataBind();
            }
            else
            {
                Response.Write("<script>alert('User is missing')</script>");
            }
        }

        public void showListedComics()
        {
            String userId = Session["UserId"].ToString();

            DataSet myData = GetAllComics();
            ArrayList comicList = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    DataSet myData2 = GetUsername(userId);
                    String username = myData2.Tables[0].Rows[0]["Username"].ToString();

                    String comicId = myData.Tables[0].Rows[i]["ComicId"].ToString();
                    String coverUrl = myData.Tables[0].Rows[i]["CoverUrl"].ToString();
                    String title = myData.Tables[0].Rows[i]["Title"].ToString();
                    String creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                    String description = myData.Tables[0].Rows[i]["Description"].ToString();
                    float resalePrice = float.Parse(myData.Tables[0].Rows[i]["ResalePrice"].ToString());
                    String priceFormatted = String.Format("{0:C}", resalePrice);

                    Comic comic = new Comic();

                    comic.ComicId = comicId;
                    comic.CoverUrl = coverUrl;
                    comic.Title = title;
                    comic.Creators = creators;
                    comic.Description = description;
                    comic.ResalePrice = priceFormatted;
                    comic.OwnerId = username;

                    comicList.Add(comic);
                }

                gvComicBooks.DataSource = comicList;
                gvComicBooks.DataBind();

                lblEmptyComicBook.Visible = false;
            }
            else
            {
                lblEmptyComicBook.Visible = false;
            }
        }

        public void banUser(String banStatus)
        {
            for (int row = 0; row < gvComicAccounts.Rows.Count; row++)
            {
                CheckBox cbox;
                cbox = (CheckBox)gvComicAccounts.Rows[row].FindControl("chkSelectAccount");
                if (cbox.Checked)
                {
                    String email = gvComicAccounts.Rows[row].Cells[3].Text;
                    int ret = SetBan(banStatus, email);
                    if (ret >= 0)
                    {
                        // do nothing
                    }
                    else
                    {
                        // cannot ban the user
                        Response.Write("<script>alert('Cannot ban the user.')</script>");
                    }
                }
            }
            showUsers();
        }


        public int DeleteComic(String comicId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteComic";

            SqlParameter inputBan = new SqlParameter("@comicId", comicId);
            inputBan.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputBan);

            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }

        public DataSet GetAllComics()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllComics";

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public DataSet GetAllUsers()
        {
            objCommand = new SqlCommand(); //connect with storedprocedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllUsers";

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }

        public DataSet GetUsername(String userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUsername";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            DataSet getGridView = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return getGridView;
        }

        public int SetBan(String banStatus, String email)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SetBan";

            SqlParameter inputBan = new SqlParameter("@banStatus", banStatus);
            inputBan.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputBan);

            SqlParameter inputEmail = new SqlParameter("@email", email);
            inputEmail.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmail);

            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }

        protected void comicsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        protected void btnViewComic_Click(object sender, EventArgs e)
        {

        }
    }
}