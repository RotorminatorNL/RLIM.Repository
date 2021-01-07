using RLIM.BusinessLogic.MessageToUI.Admin;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Color
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;
        public string Hex { get; private set; }
        private readonly string previousHex;

        public Color(ColorDTO colorDTO)
        {
            ID = colorDTO.ID;
            Name = colorDTO.Name;
            previousName = Name;
            Hex = colorDTO.Hex;
            previousHex = Hex;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetHex(string hex)
        {
            Hex = hex;
        }

        public IMessageToAdmin Update()
        {
            ColorDTO colorDTO = new ColorDTO
            {
                ID = ID,
                Name = Name,
                Hex = Hex
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
                Name = previousName;
                Hex = previousHex;
                return new AlreadyExisting("Color");
            }

            return new Success("Color", "Update");
        }
    }
}
