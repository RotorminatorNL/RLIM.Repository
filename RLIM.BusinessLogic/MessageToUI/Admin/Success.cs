using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI
{
    public class Success : IAdmin
    {
        public string Status { get; } = "Success";
        public string Title { get; } = "Success!";
        public string Text { get; }

        public Success(string ItemName, string ExecutedFunc)
        {
            switch (ExecutedFunc)
            {
                case "Added":
                    {
                        Text = $"{ItemName} has been successfully added to the system.";
                        break;
                    }
                case "Changed":
                    {
                        Text = $"The data of the chosen {ItemName} has been successfully changed in the system.";
                        break;
                    }
                case "Removed":
                    {
                        Text = $"The chosen {ItemName} has been successfully removed from the system.";
                        break;
                    }
            }
        }
    }
}
