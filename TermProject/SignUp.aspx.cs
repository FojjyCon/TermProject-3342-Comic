using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using ComicLibrary;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace TermProject
{
    public partial class SignUp : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            Email objEmail = new Email();

            String password = txtPassword.Text;
            String confirmPassword = txtConfirmPassword.Text;

            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.Avatar = "imgs/" + ddlAvatar.SelectedValue + ".jpg";
            user.EmailAddress  = txtEmail.Text;
            user.SecurityEmail = txtSecurityEmail.Text;
            user.HomeAddress = txtHomeAddress.Text;
            user.BillingAddress = txtBillingAddress.Text;
            user.PhoneNumber = txtPhoneNumber.Text;
            user.Money = txtMoney.Text;
            user.Type = rbUserAdmin.SelectedValue.ToString();
            user.Answer1 = txtAnswer1.Text;
            user.Answer2 = txtAnswer2.Text;
            user.Answer3 = txtAnswer3.Text;
            user.BanStatus = "1";
            user.Verified = "0";
            

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonUser = js.Serialize(user);

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Password does not match')</script>");
            }
            else if (checkEmail(user.EmailAddress) == true)
            {
                Response.Write("<script>alert('This email already exists in the system')</script>");
            }
            else
            {
                try
                {
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("https://localhost:44371/api/signup/Users");
                    request.Method = "POST";
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
                        String strTO = txtEmail.Text;
                        String strFROM = "do_not_reply@comic.com";
                        String strSubject = "Comic Account Verification";
                        String strMessage = "Click the link below to verify your account: http://cis-iis2.temple.edu/spring2021/CIS3342_tuh16611/TermProject/TwoStep.aspx";

                        try
                        {
                            objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                            Response.Write("<script>alert('Account Created! We sent you an email. Check that email and click the link to verify.')</script>");
                            Response.Redirect("Login.aspx");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('email wasn't sent because one of the required fields was missing.')</script>");
                        }
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

            // this is code for sending an email for verification 
            /*
             *  String strTO = txtEmail.Text;
                String strFROM = "do_not_reply@comic.com";
                String strSubject = "Comic Account Verification";
                String strMessage = "Click the link below to verify your account: http://cis-iis2.temple.edu/spring2021/CIS3342_tuh16611/TermProject/TwoStep.aspx";
            
                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                    Response.Write("<script>alert('We sent you an email so you can verify your account. Go do that to be able to login.')</script>");
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('The email wasn't sent because one of the required fields was missing.')</script>");
                }    

             */

            /*
            // old code before the API REST
            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Password does not match')</script>");
            } else if (checkEmail(email) == true)
            {
                Response.Write("<script>alert('This email already exists in the system')</script>");
            } else
            {
                String strTO = txtEmail.Text;
                String strFROM = "do_not_reply@comic.com";
                String strSubject = "Comic Account Verification";
                String strMessage = "Click the link below to verify your account: http://cis-iis2.temple.edu/spring2021/CIS3342_tuh16611/TermProject/TwoStep.aspx";

                user.Username = username;
                user.Password = password;
                user.Avatar = avatar;
                user.HomeAddress = homeAddress;
                user.BillingAddress = billingAddress;
                user.PhoneNumber = phoneNumber;
                user.EmailAddress = email;
                user.SecurityEmail = securityEmail;
                user.Money = money;
                user.Type = type;
                user.Answer1 = answer1;
                user.Answer2 = answer2;
                user.Answer3 = answer3;
                int ret = insertData(user.Username, user.Password, user.Avatar, user.HomeAddress, user.BillingAddress, user.PhoneNumber, 
                    user.EmailAddress, user.SecurityEmail, user.Money, user.Type, user.Answer1, user.Answer2, user.Answer3);

                if (ret > 0)
                {
                    String owned = "Owned";
                    String sold = "Sold";
                    String cart = "Cart";
                    String removed = "Removed";

                    DataSet getEmail = signupGetUserId(user.EmailAddress);
                    int userId = Int32.Parse(getEmail.Tables[0].Rows[0]["UserId"].ToString());

                    signupCreateTag(owned, userId);
                    signupCreateTag(sold, userId);
                    signupCreateTag(cart, userId);
                    signupCreateTag(removed, userId);

                    // verification comes into play here (redirect to verification page)
                    try
                    {
                        objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                        Response.Write("<script>alert('We sent you an email so you can verify your account. Go do that to be able to login.')</script>");
                        Response.Redirect("Login.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('The email wasn't sent because one of the required fields was missing.')</script>");
                    }
                } else
                {
                    Response.Write("<script>alert('Did not signup. As said already, some required fields are missing.')</script>");
                }
            }
            */
        }

        public bool checkEmail(String email)
        {
            DataSet getEmail = signUpCheckEmail(email);

            int size = getEmail.Tables[0].Rows.Count;
            if (size > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public DataSet signUpCheckEmail(String email)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_signupCheckEmail";

            SqlParameter inputEmailAddress = new SqlParameter("@emailAddress", email);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            DataSet getEmail = dbConnect.GetDataSetUsingCmdObj(objCommand);
            return getEmail;
        }

        /*
        public int insertData(String username, String password, String avatar, String emailAddress, String securityEmail, String homeAddress, 
            String billingAddress, String phoneNumber, String money, String type, String answer1, String answer2, String answer3)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_signupInsert";

            SqlParameter inputUsername = new SqlParameter("@username", username);
            inputUsername.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUsername);

            SqlParameter inputPassword = new SqlParameter("@password", password);
            inputPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPassword);

            SqlParameter inputAvatar = new SqlParameter("@avatar", avatar);
            inputAvatar.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputAvatar);

            SqlParameter inputHomeAddress = new SqlParameter("@homeAddress", homeAddress);
            inputHomeAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputHomeAddress);

            SqlParameter inputBillingAddress = new SqlParameter("@billingAddress", billingAddress);
            inputBillingAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputBillingAddress);

            SqlParameter inputPhone = new SqlParameter("@phoneNumber", phoneNumber);
            inputPhone.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPhone);

            SqlParameter inputEmail = new SqlParameter("@emailAddress", emailAddress);
            inputEmail.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmail);

            SqlParameter inputSecurityEmail = new SqlParameter("@securityEmail", securityEmail);
            inputSecurityEmail.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputSecurityEmail);

            SqlParameter inputMoney = new SqlParameter("@money", money);
            inputMoney.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputMoney);

            SqlParameter inputType = new SqlParameter("@type", type);
            inputType.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputType);

            SqlParameter inputA1 = new SqlParameter("@answer1", answer1);
            inputA1.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputA1);

            SqlParameter inputA2 = new SqlParameter("@answer2", answer2);
            inputA2.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputA2);

            SqlParameter inputA3 = new SqlParameter("@answer3", answer3);
            inputA3.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputA3);

            SqlParameter inputBanStatus = new SqlParameter("@banStatus", 1);
            inputBanStatus.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputBanStatus);

            SqlParameter inputVerified = new SqlParameter("@verified", 0);
            inputVerified.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputVerified);

            int ret = dbConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }
        */

        /*
        public void signupCreateTag(String tagName, int userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_signupCreateTag";

            SqlParameter inputTagNameInbox = new SqlParameter("@tagName", tagName);
            inputTagNameInbox.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputTagNameInbox);

            SqlParameter inputUserIdInbox = new SqlParameter("@userId", userId);
            inputUserIdInbox.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserIdInbox);
            dbConnect.DoUpdateUsingCmdObj(objCommand);
        }
        */
        /*
        public DataSet signupGetUserId(String email)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_signupGetUserId";

            SqlParameter inputEmailAddress = new SqlParameter("@emailAddress", email);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            DataSet getEmail = dbConnect.GetDataSetUsingCmdObj(objCommand);
            return getEmail;
        }
        */
    }

}