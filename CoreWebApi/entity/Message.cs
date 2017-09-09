using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.entity
{
    public class Message
    {
        public int id { get; set; }
        
        public string textOfMessage { get; set; }
        public TopicOfMessage topic { get; set; }
        public Contact contact { get; set; }

        public Message(string textOfMessage, TopicOfMessage topic, Contact contact)
        {
            this.textOfMessage = textOfMessage;
            this.topic = topic;
            this.contact = contact;
        }

        public string  toString()
        {
            return "id: " + this.id + ", text: " + textOfMessage + ",topic: " + topic.nameOfTopic + ", contact: " +
                   contact.name;
        }
    }
}