using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI
{
    public class AlreadyExisting : IAdmin
    {
        public string Status { get; } = "Error";
        public string Title { get; } = "Whoops!";
        public string Text { get; }

        public AlreadyExisting(string ItemName)
        {
            Text = $"{ItemName} already exists in the system.";
        }
    }
}
