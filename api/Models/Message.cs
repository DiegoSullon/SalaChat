using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Message
    {
        public Guid messageId {get;set;}
        public Guid roomId {get;set;}
        public string content {get;set;}
        public string userName{get;set;}
        public DateTime messageDate {get;set;}
        public virtual Room room {get;set;}
    }
}