using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Platform
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Platform(PlatformDTO platformDTO)
        {
            ID = platformDTO.ID;
            Name = platformDTO.Name;
        }

        public IAdmin Update(string name)
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                ID = ID,
                Name = name
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
                return new AlreadyExisting("Platform");
            }

            return new Success("Platform", "Update");
        }
    }
}
