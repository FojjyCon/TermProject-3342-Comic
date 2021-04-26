using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;              // import needed for DataSet and other data classes
using System.Data.SqlClient;    // import needed for ADO.NET classes
using Utilities;
using System.Collections;

namespace SignupWebService.Controllers
{
    [Route("api/signup")]
    public class SignupController : Controller
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        [HttpGet("{Username}")]
        public User Get(String username)
        {
            //DBConnect objDB = new DBConnect();

            DataSet myData = GetUserData(username);
            DataRow record;

            User user = new User();
            if (myData.Tables[0].Rows.Count != 0)
            {
                record = myData.Tables[0].Rows[0];
                user.Username = record["Username"].ToString();
                user.Password = record["Password"].ToString();
            }
            return user;
        }

        [HttpPost("Users")]
        public Boolean Post([FromBody] User theUser)
        {
            //DBConnect objDB = new DBConnect();
            int ret = insertData(theUser.Username, theUser.Password, theUser.Avatar, theUser.HomeAddress,
                theUser.BillingAddress, theUser.PhoneNumber, theUser.EmailAddress, theUser.SecurityEmail,
                theUser.Money, theUser.Type, theUser.Answer1, theUser.Answer2, theUser.Answer3, theUser.BanStatus, theUser.Verified);

            if (ret > 0)
            {
                return true;
            }
            return false;
        }

        // this collapsed method is an my attempt to create a PUT rest api method
        /*
        [HttpPut("Verify/{username}")]
        public void Put(String username, [FromBody] User theUser)
        {
            DataSet myData = GetUserData(username);
            DataRow record;

            User user = new User();
            if (myData.Tables[0].Rows.Count != 0)
            {
                record = myData.Tables[0].Rows[0];
                user.Username = record["Username"].ToString();
                user.Password = record["Password"].ToString();
                String verified = "1";

                VerifyUser(user.Username, user.Password, verified);
            }
            
        }
        */

        public int insertData(String username, String password, String avatar, String emailAddress, String securityEmail, 
            String homeAddress, String billingAddress, String phoneNumber, String money, String type, 
            String answer1, String answer2, String answer3, String banStatus, String verified)
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

            SqlParameter inputBanStatus = new SqlParameter("@banStatus", banStatus);
            inputBanStatus.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputBanStatus);

            SqlParameter inputVerified = new SqlParameter("@verified", verified);
            inputVerified.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputVerified);

            int ret = dBConnect.DoUpdateUsingCmdObj(objCommand);
            return ret;
        }

        // this is the verify user method that is to be used with the PUT method
        /*
        public DataSet VerifyUser(String username, String password, String verified)
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

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }
        */

        public DataSet GetUserData(String username)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllUserData";

            SqlParameter inputUsername = new SqlParameter("@username", username);
            inputUsername.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUsername);

            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return myData;
        }
    }
}
