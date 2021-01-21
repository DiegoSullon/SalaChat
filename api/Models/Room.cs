using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Room
    {
        public Guid roomId {set; get;}
        public string name {get;set;}
        public string description {get;set;}

        public virtual ICollection<Message> messages {get;set;}
        
    }
}