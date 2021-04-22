using ComicLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
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
            lblErrorOccured.Visible = false;
            btnVerify.Visible = false;
        }

        protected void btnCheckAccountExistence_Click(object sender, EventArgs e)
        {
            String username = txtUsernameInput.Text;

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44371/api/signup/Users/" + username);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User user = js.Deserialize<User>(data);

            if (user.Username != "")
            {
                //User[] users = new User[1];
                //users[0] = user;

                txtUsernameInput.Text = user.Username;
                txtPasswordInput.Text = user.Password;
                btnVerify.Visible = true;
                lblErrorOccured.Text = "Account Exists! Click Verify.";
            }
            else
            {
                lblErrorOccured.Text = "No user found. Enter information again";
            }
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
                /*
                DataSet myData = getLoginData(txtUsernameInput.Text, txtPasswordInput.Text);
                objCommand = new SqlCommand();

                int size = myData.Tables[0].Rows.Count;
                if (size > 0)
                {
                    //objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_Userverified";

                    SqlParameter getVerified = new SqlParameter("@verified", verified);
                    getVerified.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(getVerified);
                }
                else
                {
                    Response.Write("<script>alert('Your account is already verified!')</script>");
                }
                */

                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonUser = js.Serialize(verified);

                try
                {
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("https://localhost:44371/api/signup/Users/" + username);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/spring2021/CIS3342_tuh16611/TermProject/");
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Users/tuh16611/CIS3342/CoreWebAPI/api/users/");
                    request.Method = "PUT";
                    request.ContentLength = jsonUser.Length;
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonUser);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        Response.Write("<scipt>alert('The user was successfully saved to the database.')</script>");
                    }
                    else
                    {
                        Response.Write("<scipt>alert('The user wasn't saved to the database.')</script>");
                    }
                }
                catch (Exception ex)
                {
                    String error = "Error: " + ex.Message;
                    Response.Write("<scipt>alert('" + error + "')</script>");
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