using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.entity
{
    public class TopicOfMessage
    {
        public int id { get; set; }
       
        public string nameOfTopic { get; set; }
        
        public ICollection<Message> Messages { get; set; }

        public TopicOfMessage( string nameOfTopic)
        {
            this.nameOfTopic = nameOfTopic;
        }

        public TopicOfMessage()
        {
        }
    }
}