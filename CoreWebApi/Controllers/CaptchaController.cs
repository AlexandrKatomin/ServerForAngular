using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class Capcha2Controller:Controller
    {
        private string captcha;
      
        
        [HttpGet]
        public void  Get()
        {
            Response.Clear();
            Response.ContentType = "image/jpeg";
            captcha = new Captcha3().Generate(Response.Body);
        }
    }
}