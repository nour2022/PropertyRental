
// DTO for sending messages
public class ChatMassegeDTO
{
    public int TenantId { get; set; }
    public int OwnerId { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}
