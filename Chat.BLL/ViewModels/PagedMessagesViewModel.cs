namespace Chat.BLL.ViewModels;

public class PagedMessagesViewModel
{
    public int SkipAmount { get; set; }
    public int TakeAmount { get; set; }
    public List<MessageViewModel> Messages { get; set; }
}