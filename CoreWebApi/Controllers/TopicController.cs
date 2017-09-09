using System.Collections.Generic;
using System.Linq;
using CoreWebApi.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using  Newtonsoft.Json;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : Controller
    {
        private TestDBContext db;

        public TopicController(TestDBContext context)
        {
            db = context;
        }

        // GET
        [HttpGet]
        public string Get()
        {
            db.TopicOfMessages.Load();
            ICollection<TopicOfMessage> topicOfMessages = db.TopicOfMessages.Local.ToBindingList();
            string jsonStr = JsonConvert.SerializeObject(topicOfMessages);
            return jsonStr;
        }
    }
}