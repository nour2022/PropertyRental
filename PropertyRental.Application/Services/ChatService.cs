using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Application.Hubs;
using PropertyRental.Domain.Entities;
using PropertyRental.Domain.Entities.User;
using PropertyRental.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IChatService
{
    Task SendMessageAsync(int tenantId, int ownerId, int userId, string message);
    Task<List<ChatMassege>> GetChatHistoryAsync(int tenantId, int ownerId);
}

public class ChatService : IChatService
{
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly AppDbContext _appDbContext;

    public ChatService(IHubContext<ChatHub> hubContext, AppDbContext appDbContext)
    {
        _hubContext = hubContext;
        _appDbContext = appDbContext;
    }

    // Method to send a message
    public async Task SendMessageAsync(int tenantId, int ownerId, int userId, string message)
    {
        var chatMessage = new ChatMassege
        {
            TenantId = tenantId, 
            OwnerId = ownerId,
            SenderId = userId,
            Message = message,
            Timestamp = DateTime.UtcNow
        };

        await _appDbContext.ChatMasseges.AddAsync(chatMessage);
        await _appDbContext.SaveChangesAsync();

        await _hubContext.Clients.User(tenantId.ToString()).SendAsync("ReceiveMessage", userId.ToString(), message);
        await _hubContext.Clients.User(ownerId.ToString()).SendAsync("ReceiveMessage", userId.ToString(), message);

    }

    // Method to get chat history
    public async Task<List<ChatMassege>> GetChatHistoryAsync(int tenantId, int ownerId)
    {
        var history = await _appDbContext.ChatMasseges
       .Where(cm => (cm.SenderId == tenantId && cm.ReceiverId == ownerId) ||
                    (cm.SenderId == ownerId && cm.ReceiverId == tenantId))
       .OrderBy(cm => cm.Timestamp) // Order messages by timestamp
       .ToListAsync(); // Retrieve the list of messages


        return history;
    }
}
