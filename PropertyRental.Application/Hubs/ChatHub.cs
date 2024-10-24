using Microsoft.AspNetCore.SignalR;
using PropertyRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Hubs
{
  
    public class ChatHub : Hub
    {
        public async Task SendMessage(string tenantId, string ownerId, string user, string message)
        {
            await Clients.User(tenantId).SendAsync("ReceiveMessage", user, message);
            await Clients.User(ownerId).SendAsync("ReceiveMessage", user, message);
        }
    }

}
