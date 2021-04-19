using System;
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
    public partial class TwoStep : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            userVerified("1");
            Response.Redirect("Login.aspx");
        }

        //look over - needs work to have it verified when clicking 
        public void userVerified(String verified)
        {
            if (txtUsernameInput.Text != null && txtPasswordInput.Text != null)
            {
                DataSet myData = getLoginData(txtUsernameInput.Text, txtPasswordInput.Text);

                int size = myData.Tables[0].Rows.Count;
                if (size > 0)
                {
                    //SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandType = "TP_Userverified";

                    SqlParameter getVerified = new SqlParameter("", verified);
                    getVerified.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(getVerified);
                }
                else
                {
                    Response.Write("<script>alert('Your account is verified!')</script>");
                }
            }
        }

        public DataSet getLoginData(String username, String password)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LoginCheck";

            SqlParameter inputUsername = new SqlParameter("@username", username);
            inputUsername.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUsername);

            SqlParameter inputPassword = new SqlParameter("@password", password);
            inputPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPassword);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }
    }
}