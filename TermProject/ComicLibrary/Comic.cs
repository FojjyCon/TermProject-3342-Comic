using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicLibrary
{
    public class Comic
    {
        private String coverUrl;
        private String title;
        private String creators;
        private String description;
        private String resalePrice;
        private String quantity;
        private String ownerId;

        public String CoverUrl { get { return coverUrl; } set { coverUrl = value; } }
        public String Title { get { return title; } set { title = value; } }
        public String Creators { get { return creators; } set { creators = value; } }
        public String Description { get { return description; } set { description = value; } }
        public String ResalePrice { get { return resalePrice; } set { resalePrice = value; } }
        public String Quantity { get { return quantity; } set { quantity = value; } }
        public String OwnerId { get { return ownerId; } set { ownerId = value; } }
    }
}
