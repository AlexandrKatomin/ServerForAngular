using System;
using System.Collections.Generic;
using System.Linq;
using CoreWebApi.entity;
using Microsoft.AspNetCore.Mvc;

using  Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private TestDBContext db;

        public MessageController(TestDBContext context)
        {
            db = context;
        }
        
        public class StoryAddRequest
        {
            public string Message { get; set; }
        }
      
        [HttpPost]
        public void Post([FromBody] StoryAddRequest request)
        {
            if (request != null)
            {
                Console.WriteLine(request.Message);
                JObject responseJson = JObject.Parse(request.Message);
                Message message = responseJson.ToObject<Message>();
                List<Contact> contacts = db.FindContactsByEmailAndPhone(message.contact);
                if (contacts.Count != 0)
                {
                    message.contact = contacts.ToList()[0];
                }
                else
                {
                   db.Contacts.Add(message.contact);
                }
                message.topic=db.TopicOfMessages.Find(message.topic.id);
               db.Messages.Add(message);
               db.SaveChanges();
            }
        }
       
    }
}