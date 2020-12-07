using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ICategoryCollectionDAL
    {
        void Create(CategoryDTO categoryDTO);
        CategoryDTO Get(int id);
        int GetID(CategoryDTO categoryDTO);
        List<CategoryDTO> GetAll();
        void Delete(int id);
    }
}
