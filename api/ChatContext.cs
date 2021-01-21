using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Context
{
    public class ChatContext : DbContext
    {
        DbSet<Room> rooms {get; set;}
        DbSet<Message> messages {get; set;}
        DbSet<LogBook> logBooks {get; set;}
        public ChatContext(DbContextOptions<DbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Room>().HasKey(p=>p.roomId);
            builder.Entity<Room>().HasMany(p=> p.messages);
            builder.Entity<Message>().HasKey(p=>p.messageId);
            builder.Entity<LogBook>().HasKey(p=>p.logBookId);
        }
    }
}