using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class ColorCollection
    {
        public IAdmin Create(string name, string hex)
        {
            ColorDTO certificateDTO = new ColorDTO
            {
                Name = name,
                Hex = hex
            };

            if (ColorFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                if (!ColorFactoryDAL.GetCollectionDAL().Create(certificateDTO))
                {
                    return new Error("Color", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Color");
            }

            return new Success("Color", "Create");
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

        public IAdmin Delete(int id)
        {
            if (!ColorFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Color", "Delete");
            }

            return new Success("Color", "Delete");
        }
    }
}
