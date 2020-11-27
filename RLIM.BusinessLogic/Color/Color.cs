using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class Color
    {
        private IColorDAL colorDAL = ColorFactoryDAL.GetDAL();

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Hex { get; private set; }

        public Color(ColorDTO colorDTO)
        {
            Id = colorDTO.Id;
            Name = colorDTO.Name;
            Hex = colorDTO.Hex;
        }

        public void Update(string name, string hex)
        {
            Name = name;
            Hex = hex;

            ColorDTO colorDTO = new ColorDTO
            {
                Id = Id,
                Name = Name,
                Hex = Hex
            };

            colorDAL.Update(colorDTO);
        }
    }
}
