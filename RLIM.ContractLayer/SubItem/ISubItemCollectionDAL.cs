using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ISubItemCollectionDAL
    {
        bool Create(SubItemDTO subItemDTO);
        SubItemDTO Get(int id);
        int GetID(SubItemDTO subItemDTO);
        List<SubItemDTO> GetAll();
        List<SubItemDTO> GetAllWithMainItemID(int mainItemID);
        bool Delete(int id);
        bool DeleteAllWithMainItemID(int mainItemID);
    }
}
