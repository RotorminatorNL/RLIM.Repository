using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class ColorCollection
    {
        public void Create(string name, string hex)
        {
            ColorDTO certificateDTO = new ColorDTO
            {
                Name = name,
                Hex = hex
            };

            if (ColorFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                ColorFactoryDAL.GetCollectionDAL().Create(certificateDTO);
            }
        }

        public Color Get(int id)
        {
            return new Color(ColorFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Color> GetAll()
        {
            List<Color> colors = new List<Color>();

            foreach (ColorDTO colorDTO in ColorFactoryDAL.GetCollectionDAL().GetAll())
            {
                colors.Add(new Color(colorDTO));
            }

            return colors;
        }

        public void Delete(int id)
        {
            ColorFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }
}
