using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public interface IColorCollectionDAL
    {
        void Create(ColorDTO colorDTO);
        ColorDTO Get(int id);
        int GetID(ColorDTO colorDTO);
        List<ColorDTO> GetAll();
        void Delete(int id);
    }
}
