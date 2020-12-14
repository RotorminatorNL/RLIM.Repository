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

        /// <summary>
        /// Returns Success message to UI
        /// </summary>
        /// <param name="ItemName">Name of the item</param>
        /// <param name="ExecutedFunc">Name of the executed function: Create, Update or Delete</param>
        public Success(string ItemName, string ExecutedFunc)
        {
            switch (ExecutedFunc)
            {
                case "Create":
                    {
                        Text = $"The {ItemName} has been successfully added to the system.";
                        break;
                    }
                case "Update":
                    {
                        Text = $"The data of the chosen {ItemName} has been successfully changed in the system.";
                        break;
                    }
                case "Delete":
                    {
                        Text = $"The chosen {ItemName} has been successfully removed from the system.";
                        break;
                    }
                default:
                    {
                        Title = "Hmmm...";
                        Text = "Normally there would be an (kind of informative) error message here, " +
                            "but this time something went so wrong that this is al you can get for now.";
                        break;
                    }
            }
        }
    }
}
