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
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var res =  await client.GetStringAsync("https://docs.google.com/document/d/e/2PACX-1vRYL5Si8vWz85AGPAMye8JKy71Ob3AYxMz-dxl0S_BLQWQMqbRnIouQYN8IfOH9Lae3vt3dn6YeO79g/pub");
            var document = new HtmlDocument();
            document.LoadHtml(res);
            var nodes = document.DocumentNode.SelectSingleNode("//div[@id='contents']");

            ViewData["Content"] = nodes.OuterHtml;
            return View();
        }
  
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
