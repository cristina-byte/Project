
namespace Domain.Entities
{
    public class ChatMember
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; } 

        public ChatMember(int userId,int chatId)
        {
            UserId = userId;
            ChatId = chatId;
        }
    }
}
