using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ISubItemCollectionDAL
    {
        void Create(SubItemDTO subItemDTO);
        SubItemDTO Get(int id);
        List<SubItemDTO> GetAll();
        List<SubItemDTO> GetAllWithMainItemID(int mainItemID);
        void Delete(int id);
    }
}
