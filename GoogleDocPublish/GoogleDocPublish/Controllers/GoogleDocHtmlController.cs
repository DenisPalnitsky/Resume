using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoogleDocPublish.Controllers
{
    [Route("api/[controller]")]
    public class GoogleDocHtmlController : Controller
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient();
            return await client.GetStringAsync("https://docs.google.com/document/d/e/2PACX-1vRYL5Si8vWz85AGPAMye8JKy71Ob3AYxMz-dxl0S_BLQWQMqbRnIouQYN8IfOH9Lae3vt3dn6YeO79g/pub");
        }


    }
}
