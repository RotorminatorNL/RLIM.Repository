using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ICategoryDAL
    {
        bool Update(CategoryDTO categoryDTO);
    }
}
