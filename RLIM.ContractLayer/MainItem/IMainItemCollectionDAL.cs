using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IMainItemCollectionDAL
    {
        void Create(MainItemDTO mainItemDTO);
        MainItemDTO Get(int id);
        List<MainItemDTO> GetAll();
        void Delete(int id);
    }
}
