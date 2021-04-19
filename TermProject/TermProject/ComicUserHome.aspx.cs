using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class ComicUserHome : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNavHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserHome.aspx");
        }

        protected void btnNavComics_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserComics.aspx");
        }

        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCart.aspx");
        }

        protected void btnPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCollection.aspx");
        }

        protected void btnCollection_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCollection.aspx");
        }

        protected void LBDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchComic_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        protected void gvComicView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkSelectEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {

        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }
    }
}