using ComicLibrary;
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
    public partial class ForgotInfo : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        String username = "";
        String password = "";
        String selectedQuestion = "";
        String answer1 = "";
        String answer2 = "";
        String answer3 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplaySecurity(false);

            String q1 = "Where were you born?";
            String q2 = "Where did you go to elementary school?";
            String q3 = "What is the name of your first pet?";

            String[] questions = {q1, q2, q3};
            Random rand = new Random();
            int randomNumber = rand.Next(0, 3);
            selectedQuestion = questions[randomNumber];
        }

        protected void btnCheckEmail_Click(object sender, EventArgs e)
        {
            DataSet myData = getLoginData(txtEmailInput.Text);

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                username = myData.Tables[0].Rows[0]["Username"].ToString();
                password = myData.Tables[0].Rows[0]["Password"].ToString();
                answer1 = myData.Tables[0].Rows[0]["Answer1"].ToString();
                answer2 = myData.Tables[0].Rows[0]["Answer2"].ToString();
                answer3 = myData.Tables[0].Rows[0]["Answer3"].ToString();

                lblQuestion.Text = selectedQuestion;
                DisplaySecurity(true);
            }
            else
            {
                Response.Write("<script>alert('There was no account assoicated with this email.')</script>");
            }
        }
        
        // method for showing/hiding the security question feature
        public void DisplaySecurity(Boolean tf)
        {
            if (tf == true)
            {
                lblSecurityHeader.Visible = true;
                txtAnswer.Visible = true;
                lblQuestion.Visible = true;
                btnSend.Visible = true;
            }
            else
            {
                lblSecurityHeader.Visible = false;
                txtAnswer.Visible = false;
                lblQuestion.Visible = false;
                btnSend.Visible = false;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Email objEmail = new Email();
            String strTO = txtEmailInput.Text;
            String strFROM = "do_not_reply@comic.com";
            String strSubject = "Your Password";

            String answer = txtAnswer.Text;

            if (answer == answer1 || answer == answer2 || answer == answer3)
            {
                try
                {
                    String strMessage = "Your Username is: " + username + ". Your Password is: " + password + ".";
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);

                    Response.Write("<script>alert('Your password has been sent to your email address')</script>");
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Answer Incorrect')</script>");
                }
            }
        }

        public DataSet getLoginData(String email)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetEmail";

            SqlParameter inputEmailAddress = new SqlParameter("@Email", email);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }
    }


}