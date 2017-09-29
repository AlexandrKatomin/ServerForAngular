using System;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace CoreWebApi.Controllers
{
  
    [Route("api/[controller]")]
    public class Capcha2Controller:Controller
    {
        private string CAPTCHA = "Captcha";
        [HttpGet]
        public Stream  Get()
        {
            string captcha;
            Stream stream = new System.IO.MemoryStream();
            Response.Clear();
            Response.ContentType = "image/jpeg";
            captcha = new Captcha3().Generate(stream);  
            // captcha = new Captcha3().Generate(Response.Body);
            HttpContext.Session.SetString(CAPTCHA, captcha);
            Console.WriteLine( HttpContext.Session.GetString(CAPTCHA));
            stream.Position = 0;
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin","http://localhost:4200");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials","true");
            Console.WriteLine( HttpContext.Session.Id);
            return stream;
        }
        
        [HttpGet("{captcha}")]
        public Boolean Get(string captcha)
        {
            if (HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Session"))
                Console.WriteLine(HttpContext.Request.Cookies[".AspNetCore.Session"]);
           
            Console.WriteLine( HttpContext.Session.GetString(CAPTCHA));
            Console.WriteLine("----");
            Console.WriteLine(captcha);
            HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials","true");
            return  captcha.Equals( HttpContext.Session.GetString(CAPTCHA));
        }
    }
}