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
            showUsers();
            showListedComics();
            showDetailView(false);
        }

        protected void btnUnban_Click(object sender, EventArgs e)
        {
            userBanning("1");
        }

        protected void btnBan_Click(object sender, EventArgs e)
        {
            userBanning("0");
        }

        public void userBanning(String banstatus)
        {
            for (int row = 0; row < gvComicAccounts.Rows.Count; row++)
            {
                CheckBox chkBox;
                chkBox = (CheckBox)gvComicAccounts.Rows[row].FindControl("chkSelectAccount");
                if (chkBox.Checked)
                {
                    String userName = gvComicAccounts.Rows[row].Cells[2].Text;
                    String email = gvComicAccounts.Rows[row].Cells[5].Text;
                    SqlCommand objCommand = new SqlCommand(); //connect with storedprocedure
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_AdminUserBanning";

                    SqlParameter getActive = new SqlParameter("@BanStatus", banstatus);
                    getActive.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(getActive);

                    SqlParameter getEmail = new SqlParameter("@Email", email);
                    getEmail.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(getEmail);

                    SqlParameter getUsername = new SqlParameter("@Username", userName);
                    getUsername.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(getUsername);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);
                }
                //else
                //{
                //    Response.Write("<script>alert('User not bannable.')</script>");
                //}
            }
            showUsers();
        }

        public void showUsers()
        {
            SqlCommand objCommand = new SqlCommand(); //connect with storedprocedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AdminShowUsers";
            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);

            ArrayList showUsers = new ArrayList();

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    User users = new User();
                    users.Avatar = myData.Tables[0].Rows[i]["Avatar"].ToString();
                    users.Username = myData.Tables[0].Rows[i]["Username"].ToString();
                    users.PhoneNumber = myData.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    users.HomeAddress = myData.Tables[0].Rows[i]["HomeAddress"].ToString();
                    users.EmailAddress = myData.Tables[0].Rows[i]["EmailAddress"].ToString();
                    users.SecurityEmail = myData.Tables[0].Rows[i]["SecurityEmail"].ToString();
                    if (myData.Tables[0].Rows[i]["BanStatus"].ToString().CompareTo("1") == 0)
                    {
                        users.BanStatus = "Is not banned";
                    }
                    else
                    {
                        users.BanStatus = "Banned";
                    }
                    showUsers.Add(users);
                }
                gvComicAccounts.DataSource = showUsers;
                gvComicAccounts.DataBind();
            }
            else
            {
                Response.Write("<script>alert('User is missing')</script>");
            }
        }

        public string getUserByUserID(String userID)
        {
            SqlCommand objCommand = new SqlCommand(); //connect with storedprocedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AdminGetUserID";

            SqlParameter getUserId = new SqlParameter("@UserId", userID);
            getUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(getUserId);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                String comics = myData.Tables[0].Rows[0]["EmailAddress"].ToString();
                return comics;
            }
            else
            {
                return "User is missing.";
            }
        }

        public void showDetailView(Boolean flag)
        {
            lblAddTitle.Visible = flag;
            lblCoverUrl.Visible = flag;
            lblTitle.Visible = flag;
            lblCreators.Visible = flag;
            lblDescription.Visible = flag;
            lblResalePrice.Visible = flag;
            lblQuantity.Visible = flag;
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
            //comic.RetailPrice = gvComicBooks.SelectedRow.Cells[1].Text;
            comic.ResalePrice = gvComicBooks.SelectedRow.Cells[4].Text;
            //comic.ReleaseDate = gvComicBooks.SelectedRow.Cells[1].Text;

            gvComicBooks.Visible = false;
            showDetailView(true);
        }

        //look over - need to add sql query
        public void showListedComics(String userID = "")
        {
            ArrayList comics = new ArrayList();
            String sql = "";
            if (userID.CompareTo("") == 0)
            {
                //sql = "SELECT SenderId, ReceiverId, Subject, EmailBody, CreatedTime " +
                //      "FROM Emails, EmailReceipt " +
                //      "WHERE EmailReceipt.Flag = 1 AND " +
                //      "EmailReceipt.EmailId = Emails.EmailId ";
            }
            else
            {
                //sql = "SELECT SenderId, ReceiverId, Subject, EmailBody, CreatedTime " +
                //      "FROM Emails, EmailReceipt " +
                //      "WHERE EmailReceipt.Flag = 1 AND " +
                //      "EmailReceipt.EmailId = Emails.EmailId " + userID;
            }
            DataSet myData = dBConnect.GetDataSet(sql);
            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Comic comic = new Comic();
                    String comicID = myData.Tables[0].Rows[i]["ComicId"].ToString();
                    //String receiverID = myData.Tables[0].Rows[i]["ReceiverId"].ToString();
                    String creatorComic = getUserByUserID(comicID);
                    //String receiverEmail = getUserByUserID(receiverID);
                    comic.Creators = creatorComic;
                    //comic.ReceiverName = receiverEmail;
                    comic.Title = myData.Tables[0].Rows[i]["Subject"].ToString();
                    comic.Description = myData.Tables[0].Rows[i]["Description"].ToString();
                    String resalePrice = myData.Tables[0].Rows[i]["ResalePrice"].ToString();
                    comic.ResalePrice = DateTime.Parse(resalePrice).ToShortDateString();

                    comics.Add(comic);
                }
                gvComicBooks.DataSource = comics;
                gvComicBooks.DataBind();

                lblEmptyComicBook.Visible = false;
            }
            else
            {
                lblEmptyComicBook.Visible = false;
            }

        }

        protected void gvComicBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int comicReader = Int32.Parse(e.CommandArgument.ToString());
            String comicTitle = gvComicBooks.Rows[comicReader].Cells[1].Text;
            lblTitle.Text = comicTitle;
            String comicCreator = gvComicBooks.Rows[comicReader].Cells[2].Text;
            lblCreators.Text = comicCreator;
            String comicDesc = gvComicBooks.Rows[comicReader].Cells[3].Text;
            lblDescription.Text = comicDesc;
            String comicResale = gvComicBooks.Rows[comicReader].Cells[4].Text;
            lblResalePrice.Text = comicResale;
            String comicQty = gvComicBooks.Rows[comicReader].Cells[4].Text;
            lblQuantity.Text = comicQty;
            showDetailView(true);
        }
    }
}