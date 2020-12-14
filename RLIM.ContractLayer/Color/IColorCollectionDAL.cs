using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public interface IColorCollectionDAL
    {
        bool Create(ColorDTO colorDTO);
        ColorDTO Get(int id);
        int GetID(ColorDTO colorDTO);
        List<ColorDTO> GetAll();
        bool Delete(int id);
    }
}
