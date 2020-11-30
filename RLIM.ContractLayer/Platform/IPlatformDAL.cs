using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IPlatformDAL
    {
        void Update(PlatformDTO platformDTO);
    }
}
