using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    txtUsername.Text = Session["Username"].ToString();
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null && txtPassword.Text != null)
            {
                DataSet myData = getLoginData(txtUsername.Text, txtPassword.Text);

                int size = myData.Tables[0].Rows.Count;
                for (int i = 0; i < size; i++)
                {
                    int userBanned = int.Parse(dbConnect.GetField("BanStatus", 0).ToString());
                    if (userBanned == 0)
                    {
                        Response.Write("<script>alert('Your email account is banned.')</script>");
                    } else
                    {
                        String userType = dbConnect.GetField("Type", 0).ToString();

                        if (userType.CompareTo("User") == 0)
                        {
                            Session["UserId"] = dbConnect.GetField("UserId", 0);
                            Session["Username"] = txtUsername.Text;
                            Session["HomeAddress"] = dbConnect.GetField("HomeAddress", 0);
                            Session["BillingAddress"] = dbConnect.GetField("BillingAddress", 0);
                            Session["Avatar"] = dbConnect.GetField("Avatar", 0);
                            Session["Money"] = dbConnect.GetField("Money", 0);
                            Session["PhoneNumber"] = dbConnect.GetField("PhoneNumber", 0);
                            Response.Redirect();
                        } else
                        {
                            Session["UserId"] = dbConnect.GetField("UserId", 0);
                            Session["Username"] = txtUsername.Text;
                            Session["HomeAddress"] = dbConnect.GetField("HomeAddress", 0);
                            Session["BillingAddress"] = dbConnect.GetField("BillingAddress", 0);
                            Session["Avatar"] = dbConnect.GetField("Avatar", 0);
                            Session["Money"] = dbConnect.GetField("Money", 0);
                            Session["PhoneNumber"] = dbConnect.GetField("PhoneNumber", 0);
                            Response.Redirect();
                        }
                    }
                }
            } else
            {
                Response.Write("<script>alert('Your Password is Incorrect')</script>");
            }
        }

        protected void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {

        }

        public DataSet getLoginData(String username, String password)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CheckLoginData";

            SqlParameter sqlUsername = new SqlParameter("@username", username);
            sqlUsername.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(sqlUsername);

            SqlParameter sqlPassword = new SqlParameter("@password", password);
            sqlPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(sqlPassword);

            DataSet data = dbConnect.GetDataSetUsingCmdObj(objCommand);
            return data;
        }
    }
}