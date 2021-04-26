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
            WebRequest request = WebRequest.Create("https://localhost:44371/api/signup/" + username);
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

            if (user.Username != null || user.Username != "")
            {
                txtUsernameInput.Text = user.Username;
                txtPasswordInput.Text = user.Password;
                btnVerify.Visible = true;
                lblErrorOccured.Visible = true;
                lblErrorOccured.Text = "Account Exists! Click Verify.";
            }
            else
            {
                lblErrorOccured.Text = "No user found. Enter information again";
            }
        }

        // userVerified() method for the PUT method I was trying to use for REST api
        
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            String verified = "1";
            userVerified(verified);
            Response.Write("<script>alert('Your account has been verified. You will now be taken to the login screen.')</script>");
            Response.Redirect("Login.aspx");
        }

        // this was my attempt at creating userVerified() to call to the Web API to do a POST method
        /*
        public void userVerified(String verified)
        {
            String username = txtUsernameInput.Text;

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44371/api/signup/" + username);
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

            try
            {
                // Setup an HTTP PUT Web Request and get the HTTP Web Response from the server.
                WebRequest request2 = WebRequest.Create("https://localhost:44371/api/signup/Verify/" + username);
                request2.Method = "PUT";
                request2.ContentLength = .Length;
                request2.ContentType = "application/json";

                // Write the JSON data to the Web Request
                StreamWriter writer = new StreamWriter(request2.GetRequestStream());
                writer.Write(jsonVerified);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.
                WebResponse response2 = request2.GetResponse();
                Stream theDataStream2 = response.GetResponseStream();
                StreamReader reader2 = new StreamReader(theDataStream);
                String data2 = reader2.ReadToEnd();
                reader.Close();
                response.Close();

                if (data2 == "true")
                {
                    Response.Write("<scipt>alert('The user was successfully verified.')</script>");
                }
                else
                {
                    Response.Write("<scipt>alert('The user could not be verified')</script>");
                }
            }
            catch (Exception ex)
            {
                String error = "Error: " + ex.Message;
                Response.Write("<scipt>alert('" + error + "')</script>");
            }
        }
        */

        //look over - needs work to have it verified when clicking 
        public void userVerified(String verified)
        {
            if (txtUsernameInput.Text != null && txtPasswordInput.Text != null)
            {
                VerifyUser(txtUsernameInput.Text, txtPasswordInput.Text, verified);
            }
            else
            {

            }
        }

        public int VerifyUser(String username, String password, String verified)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UserVerified";

            SqlParameter inputUsername = new SqlParameter("@username", username);
            inputUsername.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUsername);

            SqlParameter inputPassword = new SqlParameter("@password", password);
            inputPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPassword);

            SqlParameter inputVerified = new SqlParameter("@verified", verified);
            inputVerified.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputVerified);

            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }
    }
}