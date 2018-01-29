using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleDocPublish.Models;
using System.Net.Http;
using HtmlAgilityPack;

namespace GoogleDocPublish.Controllers
{
    public class HomeController : Controller
    {
        private const string DocId = "1Rzf7T8J2RKAg_DHUu4M6Jyx4igzBQbIhUQ8f5ZFkJks";
        private const string DocHtmlRequestUri = "https://docs.google.com/document/d/e/2PACX-1vRYL5Si8vWz85AGPAMye8JKy71Ob3AYxMz-dxl0S_BLQWQMqbRnIouQYN8IfOH9Lae3vt3dn6YeO79g/pub";

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var res =  await client.GetStringAsync(DocHtmlRequestUri);
            var document = new HtmlDocument();
            document.LoadHtml(res);
            var nodes = document.DocumentNode.SelectSingleNode("//div[@id='contents']");
            
            return View( new ResumeViewModel(DocId, nodes.OuterHtml));
        }
  
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
