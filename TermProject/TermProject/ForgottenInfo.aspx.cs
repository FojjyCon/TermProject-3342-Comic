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
    public partial class ForgottenInfo : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //look over - submit button to change password completely
        protected void btnPasswordSubmit_Click(object sender, EventArgs e)
        {

        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataSet myData = DBConnect.getLoginData(txtEmailInput.Text);

            Email objEmail = new Email();
            String strTO = txtEmailInput.Text;
            String strFROM = "do_not_reply@comic.com";
            String strSubject = "Your Password";

            try
            {
                String strMessage = "Your password is: " + myData.Tables[0].Rows[0]["Password"];
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);

                lblMsg.Text = "Your password has been sent to your email address";
            }

            catch (Exception ex)
            {
                lblMsg.Text = "This email does not exist";
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