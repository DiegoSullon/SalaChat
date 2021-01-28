using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.SignalR;

namespace api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message){
           await Clients.Others.SendAsync("RecievedMessage",message);
        }
    }
}