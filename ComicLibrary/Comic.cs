using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicLibrary
{
    public class Comic
    {
        private String title;
        private String creators;
        private String description;
        private float retailPrice;
        private float resalePrice;
        private DateTime releaseDate;
        private int sellerId;
        private int buyerId;

        public String Title { get { return title; } set { title = value; } }
        public String Creators { get { return creators; } set { creators = value; } }
        public String Description { get { return description; } set { description = value; } }
        public float RetailPrice { get { return retailPrice; } set { retailPrice = value; } }
        public float ResalePrice { get { return resalePrice; } set { resalePrice = value; } }
        public DateTime ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }
        public int SellerId { get { return sellerId; } set { sellerId = value; } }
        public int BuyerId { get { return buyerId; } set { buyerId = value; } }
    }
}
