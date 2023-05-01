namespace Chat.DAL.Entities;

public class Message : BaseEntity
{
    public int Id { get; set; }
    public string Text { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}