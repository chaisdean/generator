using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace randompasscodetwo
{
    public class passwordController:Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? run = HttpContext.Session.GetInt32("run");
            if(run == null)
            {
                run = 0;
            }
            run += 1;
            string characters = "ABCDEFGHIJKLMNOPQRSTUBVWXYZ0123456789";
            string PassCode = "";
            Random rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                PassCode = PassCode + characters[rand.Next(0,characters.Length)];
            }
            ViewBag.PassCode = PassCode;
            ViewBag.run = run;
            HttpContext.Session.SetInt32("run", (int)run);
            return View();
        }
    }
}