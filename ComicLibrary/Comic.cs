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
        private String retailPrice;
        private String resalePrice;
        private String releaseDate;
        private String quantity;
        private String sellerId;
        private String buyerId;

        public String Title { get { return title; } set { title = value; } }
        public String Creators { get { return creators; } set { creators = value; } }
        public String Description { get { return description; } set { description = value; } }
        public String RetailPrice { get { return retailPrice; } set { retailPrice = value; } }
        public String ResalePrice { get { return resalePrice; } set { resalePrice = value; } }
        public String ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }
        public String Quantity { get { return quantity; } set { quantity = value; } }
        public String SellerId { get { return sellerId; } set { sellerId = value; } }
        public String BuyerId { get { return buyerId; } set { buyerId = value; } }
    }
}
