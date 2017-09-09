using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.entity
{
    public class TestDBContext: DbContext
    {
        public  TestDBContext(DbContextOptions<TestDBContext> options):base(options)
        {}
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TopicOfMessage> TopicOfMessages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<TopicOfMessage>().ToTable("TopicOfMessage");
        }
        
        public  List<Contact> FindContactsByEmailAndPhone (Contact contact )
        {
            return  Contacts
                .Where(p => p.email == contact.email && p.phone == contact.phone)
                .ToList();
        }
    }
}