using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchWebService
{
    public class Comic
    {
        public String ComicId { get; set; }
        public String Title { get; set; }
        public String Creators { get; set; }
        public String Description { get; set; }
        public String ResalePrice { get; set; }
        public String OwnerId { get; set; }
    }
}