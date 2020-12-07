using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IMainItemCollectionDAL
    {
        int Create(MainItemDTO mainItemDTO);
        MainItemDTO Get(int id);
        int GetID(MainItemDTO mainItemDTO);
        List<MainItemDTO> GetAll();
        void Delete(int id);
    }
}
