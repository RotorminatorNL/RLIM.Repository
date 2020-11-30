using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IPlatformCollectionDAL
    {
        void Create(PlatformDTO platformDTO);
        PlatformDTO Get(int id);
        List<PlatformDTO> GetAll();
        void Delete(int id);
    }
}
