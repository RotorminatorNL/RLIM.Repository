using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IMainItemDAL
    {
        bool Update(MainItemDTO mainItemDTO);
    }
}
