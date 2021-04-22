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
    public partial class ComicAddFunds : System.Web.UI.UserControl
    {

        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtAddMoney.Visible = false;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnAddMoney_Click(object sender, EventArgs e)
        {
            txtAddMoney.Visible = true;
            btnSubmit.Visible = true;
            btnCancel.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtAddMoney.Text = "";
            txtAddMoney.Visible = false;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            float addMoney = float.Parse(txtAddMoney.Text);
            float balance = Int32.Parse(Session["Money"].ToString());
            String newBalance = "";
            String userId = Session["UserId"].ToString();
            balance += addMoney;
            newBalance = balance.ToString();
            Session["Money"] = balance;

            AddFunds(userId, newBalance);

            txtAddMoney.Text = "";
            txtAddMoney.Visible = false;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
        }

        public void AddFunds(String userId, String balance)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddFunds";

            SqlParameter inputUserId = new SqlParameter("@userId", userId);
            inputUserId.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputUserId);

            SqlParameter inputResalePrice = new SqlParameter("@money", balance);
            inputResalePrice.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputResalePrice);

            dBConnect.DoUpdateUsingCmdObj(objCommand);
        }
    }
}