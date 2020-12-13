using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic.MessageToUI
{
    public interface IAdmin
    {
        string Status { get; }
        string Title { get; }
        string Text { get; }
    }
}
