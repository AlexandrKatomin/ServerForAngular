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
        [HttpGet]
        public void  Get()
        {
            string captcha;
            this.HttpContext.Session.SetString("Captcha", captcha);
           
            Response.Clear();
            Response.ContentType = "image/jpeg";
            captcha = new Captcha3().Generate(Response.Body);
        }
        
        [HttpGet("{captcha}")]
        public Boolean Get(string captcha)
        {
            Console.WriteLine( HttpContext.Session.GetString("Captcha"));
            return  this.captcha.Equals( HttpContext.Session.GetString("Captcha"));
        }
    }
}