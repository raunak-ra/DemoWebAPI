using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISample.Controllers
{
    [Route("greet")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{greeting}")]
        public ActionResult<string> Get(string greeting)
        {
            return greeting == "hi" ? "hello" : greeting == "hello" ? "hi" : "Invalid";
        }

      
    }
}