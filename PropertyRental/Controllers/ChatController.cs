using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    // POST: api/chat/send
    [Authorize(Roles ="Owner" +","+"Tenant")]
    [HttpPost("send")]
   
    public async Task<IActionResult> SendMessage([FromBody] ChatMassegeDTO chatMessageDto)
    {
        if (string.IsNullOrWhiteSpace(chatMessageDto.Message))
        {
            return BadRequest("Message cannot be empty.");
        }

        await _chatService.SendMessageAsync(chatMessageDto.TenantId, chatMessageDto.OwnerId, chatMessageDto.SenderId, chatMessageDto.Message);
        return Ok(new { message = "Message sent successfully." });
    }

    // GET: api/chat/history/{tenantId}/{ownerId}
    [HttpGet("history/{tenantId}/{ownerId}")]
    public async Task<IActionResult> GetChatHistory(int tenantId, int ownerId)
    {
        var history = await _chatService.GetChatHistoryAsync(tenantId, ownerId);
        return Ok(history);
    }
}
