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

            String question1 = ddlQuestion1.SelectedValue.ToString();
            String answer1 = txtAnswer1.Text;
            String question2 = ddlQuestion2.SelectedValue.ToString();
            String answer2 = txtAnswer2.Text;
            String question3 = ddlQuestion3.SelectedValue.ToString();
            String answer3 = txtAnswer3.Text;

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Password does not match')</script>");
            } else if (checkEmail(email) == true)
            {
                Response.Write("<script>alert('This email already exists in the system')</script>");
            } else
            {
                user.Username = username;
                user.Avatar = avatar;
                user.EmailAddress = email;
                user.SecurityEmail = securityEmail;
                user.HomeAddress = homeAddress;
                user.BillingAddress = billingAddress;
                user.PhoneNumber = phoneNumber;
                user.Money = money;
                user.Type = type;
                user.Question1 = question1;
                user.Answer1 = answer1;
                user.Question2 = question2;
                user.Answer2 = answer2;
                user.Question3 = question3;
                user.Answer3 = answer3;
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
            objCommand.CommandText = "signupCheckEmail";

            SqlParameter inputEmailAddress = new SqlParameter("@emailAddress", email);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            DataSet getEmail = dbConnect.GetDataSetUsingCmdObj(objCommand);
            return getEmail;
        }
    }
}