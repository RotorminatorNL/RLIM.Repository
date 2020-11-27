using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class ColorCollection
    {
        private IColorCollectionDAL colorCollectionDAL = ColorFactoryDAL.GetCollectionDAL();

        public void Create(string name, string hex)
        {
            ColorDTO certificateDTO = new ColorDTO
            {
                Name = name,
                Hex = hex
            };

            colorCollectionDAL.Create(certificateDTO);
        }

        public List<Color> GetaAll()
        {
            List<Color> colors = new List<Color>();

            foreach (ColorDTO colorDTO in colorCollectionDAL.GetAll())
            {
                colors.Add(new Color(colorDTO));
            }

            return colors;
        }

        public Color Get(int id)
        {
            return new Color(colorCollectionDAL.Get(id));
        }

        public void Delete(int id)
        {
            colorCollectionDAL.Delete(id);
        }
    }
}
