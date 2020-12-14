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

        /// <summary>
        /// Returns AlreadyExisting message to UI
        /// </summary>
        /// <param name="ItemName">Name of the item</param>
        public AlreadyExisting(string ItemName)
        {
            Text = $"This {ItemName} already exists in the system.";

            if (ItemName == "")
            {
                Title = "Hmmm...";
                Text = "Normally there would be an (kind of informative) error message here, " +
                    "but this time something went so wrong that this is al you can get for now.";
            }
        }
    }
}
