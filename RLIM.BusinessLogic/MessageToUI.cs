using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class MessageToUI
    {
        public string Status { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        public MessageToUI(string status, string title, string text)
        {
            Status = status;
            Title = title;
            Text = text;
        }
    }
}
