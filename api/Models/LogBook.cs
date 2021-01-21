using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class LogBook
    {
        public Guid logBookId{get;set;}
        public string userName {get;set;}

        public DateTime logBookDate{get;set;}
    }
}