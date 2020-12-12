using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ICategoryCollectionDAL
    {
        bool Create(CategoryDTO categoryDTO);
        CategoryDTO Get(int id);
        int GetID(CategoryDTO categoryDTO);
        List<CategoryDTO> GetAll();
        bool Delete(int id);
    }
}
