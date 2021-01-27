using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ChatContext context;
        public MessageController(ChatContext dbContext){
            context=dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return context.messages;
        }

        [HttpGet]
        [Route("ByRoom/{id}")]
        public ActionResult<IEnumerable<Message>> GetByRoom(string id)
        {
            return context.messages.Where(p=>p.roomId == Guid.Parse(id)).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Message> Get(string id)
        {
           return context.messages.FirstOrDefault(p=>p.roomId == Guid.Parse(id));
        }

        [HttpPost]
        public void Post([FromBody] Message value)
        {
            value.messageId = Guid.NewGuid();
            value.messageDate = DateTime.Now;
            context.messages.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}