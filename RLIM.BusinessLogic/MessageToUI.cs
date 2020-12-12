namespace RLIM.BusinessLogic
{
    public class MessageToUI
    {
        public string Status { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public object Data { get; private set; }

        public MessageToUI(string status, string title, string text, object data)
        {
            Status = status;
            Title = title;
            Text = text;
            Data = data;
        }

        public MessageToUI(string status, string title, string text)
        {
            Status = status;
            Title = title;
            Text = text;
        }
    }
}
