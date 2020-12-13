using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI
{
    public class Error : IAdmin
    {
        public string Status { get; } = "Error";
        public string Title { get; } = "Sorry!";
        public string Text { get; }

        public Error(string ItemName, string ExecutedFunc)
        {
            switch (ExecutedFunc)
            {
                case "Added":
                    {
                        Text = $"{ItemName} has not been added to the system.";
                        break;
                    }
                case "Changed":
                    {
                        Text = $"The data of the chosen {ItemName} has not changed in the system.";
                        break;
                    }
                case "Removed":
                    {
                        Text = $"The chosen {ItemName} has not been removed from the system.";
                        break;
                    }
            }
        }
    }
}
