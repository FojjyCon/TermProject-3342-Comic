using ComicLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using Utilities;

namespace SearchWebService
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Search : System.Web.Services.WebService
    {
        
        [WebMethod]
        [XmlInclude(typeof(Comic))]
        public ArrayList SearchForComic(String searchContent)
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            ArrayList comicList = new ArrayList();

            // Stored procedure to grab all of the search content 
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SearchForComic";
            objCommand.Parameters.AddWithValue("@SearchContent", searchContent);
            DataSet myData = dBConnect.GetDataSetUsingCmdObj(objCommand);

            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                comicList = new ArrayList();
                for (int i = 0; i < size; i++)
                {
                    Comic comic = new Comic();
                    comic.ComicId = myData.Tables[0].Rows[i]["ComicId"].ToString();
                    comic.Title = myData.Tables[0].Rows[i]["Title"].ToString();
                    comic.Creators = myData.Tables[0].Rows[i]["Creators"].ToString();
                    comic.Description = myData.Tables[0].Rows[i]["Description"].ToString();
                    comic.ResalePrice = myData.Tables[0].Rows[i]["ResalePrice"].ToString();
                    comic.OwnerId = myData.Tables[0].Rows[i]["OwnerId"].ToString();

                    comicList.Add(comic);
                }
            }
            return comicList;
        }
    }
}
