using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Context;

namespace api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogBookController : ControllerBase
    {
        private ChatContext context;
        public LogBookController(ChatContext dbContext){
            context=dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogBook>> Get()
        {
            return context.logBooks;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] LogBook value)
        {
            value.logBookId = Guid.NewGuid();
            value.logBookDate = DateTime.Now;
            context.logBooks.Add(value);
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