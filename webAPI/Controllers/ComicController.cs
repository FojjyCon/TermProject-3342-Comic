using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    public class ComicController : Controller
    {

        [HttpGet]
        public String Get()
        {
            return "Web API - HTTP  GET Action Method executed.";
        }
    }
}
