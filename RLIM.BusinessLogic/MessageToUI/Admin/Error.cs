using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI.Admin
{
    public class Error : IMessageToAdmin
    {
        public string Status { get; } = "Error";
        public string Title { get; } = "Sorry!";
        public string Text { get; }

        /// <summary>
        /// Returns Error message to UI
        /// </summary>
        /// <param name="ItemName">Name of the item</param>
        /// <param name="FailedFunc">Name of the failed function: Create, Update or Delete</param>
        public Error(string ItemName, string FailedFunc)
        {
            switch (FailedFunc)
            {
                case "Create":
                    {
                        Text = $"The {ItemName} has not been added to the system.";
                        break;
                    }
                case "Update":
                    {
                        Text = $"The data of the chosen {ItemName} has not been changed in the system.";
                        break;
                    }
                case "Delete":
                    {
                        Text = $"The chosen {ItemName} has not been removed from the system.";
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
