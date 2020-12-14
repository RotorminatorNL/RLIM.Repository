using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ISubItemDAL
    {
        bool Update(SubItemDTO subItemDTO);
    }
}
