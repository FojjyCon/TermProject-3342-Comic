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

            String username = txtUsername.Text;
            String avatar = ddlAvatar.SelectedValue;
            String email = txtEmail.Text;
            String securityEmail = txtSecurityEmail.Text;
            String homeAddress = txtHomeAddress.Text;
            String billingAddress = txtBillingAddress.Text;
            String phoneNumber = txtPhoneNumber.Text;
            String money = txtMoney.Text;
            String type = rbUserAdmin.SelectedValue.ToString();

            String answer1 = txtAnswer1.Text;
            String answer2 = txtAnswer2.Text;
            String answer3 = txtAnswer3.Text;

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
    }

}