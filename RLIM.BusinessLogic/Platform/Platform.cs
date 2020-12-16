using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Platform
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;

        public Platform(PlatformDTO platformDTO)
        {
            ID = platformDTO.ID;
            Name = platformDTO.Name;
            previousName = platformDTO.Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public IAdmin Update()
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                ID = ID,
                Name = Name
            };

            if (PlatformFactoryDAL.GetCollectionDAL().GetID(platformDTO) == 0)
            {
                if (!PlatformFactoryDAL.GetDAL().Update(platformDTO))
                {
                    return new Error("Platform", "Update");
                }
            }
            else
            {
                Name = previousName;
                return new AlreadyExisting("Platform");
            }

            return new Success("Platform", "Update");
        }
    }
}
