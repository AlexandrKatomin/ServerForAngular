﻿using System;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using     Microsoft.AspNetCore.Session;
using    Microsoft.Extensions.Caching.Memory;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CaptchaController:Controller
    {
        private const string _captchaHashKey = "CaptchaHash";
        private const string _usernameHashKey = "Username";
        
        
        private string CaptchaHash
        {
            get
            {
                return HttpContext.Session.GetString(_captchaHashKey) as string;
            }
            set
            {
                HttpContext.Session.SetString(_captchaHashKey, value);
            }
        }
       
        private string Username
        {
            get
            {
                return HttpContext.Session.GetString(_usernameHashKey) as string;
            }
            set
            {
                HttpContext.Session.SetString(_usernameHashKey, value);
            }
        }
        private CaptchaBLL captchaBLL = new CaptchaBLL();
        /*
        [HttpGet]
        public ResultModel Get()
        {
            var result = new ResultModel();
            if (!string.IsNullOrEmpty(Username))
            {
                result.Data = Username;
            }
            result.IsSuccess = true;
            return result;
        }
       [HttpPost]
        public ResultModel Post([FromBody]dynamic body)
        {
            var result = new ResultModel();
            try
            {
                string username = body.username.Value;
                string password = body.password.Value;
                string code = body.code.Value;
                if (!captchaBLL.ComputeMd5Hash(code).Equals(CaptchaHash))
                {
                    result.Message = "все хорошо";
                }
                else if (!username.Equals("john") || !password.Equals("1234"))
                {
                    result.Message = "все плохо";
                }
                else
                {
                    Username = username;
                    HttpContext.Session.Remove(_captchaHashKey);
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpDelete]
        public ResultModel Delete()
        {
            var result = new ResultModel();
            HttpContext.Session.Remove(_usernameHashKey);
            result.IsSuccess = true;
            return result;
        }*/
        [Route("captcha")]
        [HttpGet]
        public ActionResult GetCaptcha()
        {
            
            var randomText = captchaBLL.GenerateRandomText(4);
            
            CaptchaHash = captchaBLL.ComputeMd5Hash(randomText);
            
            return File(captchaBLL.GenerateCaptchaImage(randomText), "image/gif");
        }
     
    }
}