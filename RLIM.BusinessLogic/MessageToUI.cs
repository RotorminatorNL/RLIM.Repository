namespace RLIM.BusinessLogic
{
    public class MessageToUI
    {
        public string Status { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string PreviousData { get; set; }
        public string NewData { get; set; }

        public MessageToUI(string status, string title, string text)
        {
            Status = status;
            Title = title;
            Text = text;
        }

        public MessageToUI(string status, string title, string text, string previousData, string newData)
        {
            Status = status;
            Title = title;
            Text = text;
            PreviousData = previousData;
            NewData = newData;
        }
    }
}
