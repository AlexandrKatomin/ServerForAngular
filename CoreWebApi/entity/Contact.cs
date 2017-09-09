using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.entity
{
    [Table("Contact")]
    public class Contact
    {
        public int id { get; set; }
       
        public string name { get; set; }
      
        public string email { get; set; }
       
        public string phone { get; set; }
        
        public ICollection<Message> Messages { get; set; }

        public Contact()
        {
        }

        public Contact(string name, string email, string phone)
        {
            
            this.name = name;
            this.email = email;
            this.phone = phone;
        }
    }
    
}