using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public interface IColorCollectionDAL
    {
        void Create(ColorDTO colorDTO);
        ColorDTO Get(int id);
        List<ColorDTO> GetAll();
        void Delete(int id);
    }
}
