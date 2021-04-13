using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class ComicUserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {

        }

        protected void LBBuyer_Click(object sender, EventArgs e)
        {

        }

        protected void LBShoppingCart_Click(object sender, EventArgs e)
        {

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

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddComic_Click(object sender, EventArgs e)
        {

        }

        protected void btnNavHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserHome.aspx");
        }

        protected void btnNavComics_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserList.aspx");
        }

        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserCart.aspx");
        }

        protected void btnPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComicUserPersonal.aspx");
        }
    }
}