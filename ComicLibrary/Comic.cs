using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicLibrary
{
    public class Comic
    {
        private int comicid;
        private String title;
        private String creator;
        private String description;
        private int retailPrice;
        private int resalePrice;
        private String releaseDate;
        private int sellerid;
        private int buyerid;

        public int ComicID { get { return comicid; } set { comicid = value; } }
        public String Title { get { return title; } set { title = value; } }
        public String Creator { get { return creator; } set { creator = value; } }
        public String Description { get { return description; } set { description = value; } }
        public int RetailPrice { get { return retailPrice; } set { retailPrice = value; } }
        public int ResalePrice { get { return resalePrice; } set { resalePrice = value; } }
        public String ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }
        public int SellerID { get { return sellerid; } set { sellerid = value; } }
        public int BuyerID { get { return buyerid; } set { buyerid = value; } }
    }
}
