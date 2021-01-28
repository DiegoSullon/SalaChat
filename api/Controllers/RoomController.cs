using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Context;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        public ChatContext context;

        public RoomController(ChatContext dbcontext){
            context = dbcontext;
            context.Database.EnsureCreated();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Room>> Get()
        {
            return context.rooms;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Room value)
        {
            value.roomId = Guid.NewGuid();
            context.rooms.Add(value);
            await context.SaveChangesAsync();
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