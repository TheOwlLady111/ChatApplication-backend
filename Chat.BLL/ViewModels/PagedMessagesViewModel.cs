namespace Chat.BLL.ViewModels;

public class PagedMessagesViewModel
{
    public int Page { get; set; }
    public int Rows { get; set; }
    public List<MessageViewModel> Messages { get; set; }
}