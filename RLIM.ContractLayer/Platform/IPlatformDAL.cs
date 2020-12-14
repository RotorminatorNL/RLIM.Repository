using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IPlatformDAL
    {
        bool Update(PlatformDTO platformDTO);
    }
}
