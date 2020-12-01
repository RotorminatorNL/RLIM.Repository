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

        public void Update(string name, string hex)
        {
            Name = name;
            Hex = hex;

            ColorFactoryDAL.GetDAL().Update(new ColorDTO
            {
                ID = ID,
                Name = Name,
                Hex = Hex
            });
        }
    }
}
