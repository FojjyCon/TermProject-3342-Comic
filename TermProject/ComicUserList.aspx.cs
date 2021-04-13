using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using ComicLibrary;

namespace TermProject
{
    public partial class ComicUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            WebRequest request = WebRequest.Create("http://gateway.marvel.com/v1/public/comics?ts=1&apikey=c0ca0ea7ab4a1a199d4780793365f375&hash=cb662e91267de7d0099312953927ecdd0479a3a2");
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Comic[] comics = js.Deserialize<Comic[]>(data);

            lvAllComics.DataSource = comics;
            lvAllComics.DataBind();
            
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        protected void btnSearchComic_Click(object sender, EventArgs e)
        {

        }

        protected void LBOwned_Click(object sender, EventArgs e)
        {

        }

        protected void LBSeller_Click(object sender, EventArgs e)
        {

        }
    }
}