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
        public DbSet<Room> rooms {get; set;}
        public DbSet<Message> messages {get; set;}
        public DbSet<LogBook> logBooks {get; set;}
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Room>().HasKey(p=>p.roomId);
            builder.Entity<Room>().HasMany(p=> p.messages);
            builder.Entity<Message>().HasKey(p=>p.messageId);
            builder.Entity<LogBook>().HasKey(p=>p.logBookId);

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(){name = "Deportes", description="Sala deportes"});
            rooms.Add(new Room(){name = "Cine", description="Sala Cine"});
            rooms.Add(new Room(){name = "Ventas", description="Sala Ventas"});
            builder.Entity<Room>().HasData(rooms);
        }
    }
}