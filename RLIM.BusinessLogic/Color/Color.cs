using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class Color
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Hex { get; private set; }

        public Color(ColorDTO colorDTO)
        {
            ID = colorDTO.ID;
            Name = colorDTO.Name;
            Hex = colorDTO.Hex;
        }

        public IAdmin Update(string name, string hex)
        {
            ColorDTO colorDTO = new ColorDTO
            {
                ID = ID,
                Name = name,
                Hex = hex
            };

            if (ColorFactoryDAL.GetCollectionDAL().GetID(colorDTO) == 0)
            {
                if (!ColorFactoryDAL.GetDAL().Update(colorDTO))
                {
                    return new Error("Color", "Update");
                }
            }
            else
            {
                return new AlreadyExisting("Color");
            }

            return new Success("Color", "Update");
        }
    }
}
