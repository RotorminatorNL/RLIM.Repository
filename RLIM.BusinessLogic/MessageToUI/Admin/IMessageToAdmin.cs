using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI.Admin
{
    public interface IMessageToAdmin
    {
        string Status { get; }
        string Title { get; }
        string Text { get; }
    }
}
