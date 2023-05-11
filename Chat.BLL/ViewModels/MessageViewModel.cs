namespace Chat.BLL.ViewModels;

public class MessageViewModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAtUTC { get; set; }
}