using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class PlatformCollection
    {
        private readonly List<Platform> platforms = new List<Platform>();

        public IAdmin Create(string name)
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                Name = name
            };

            if (PlatformFactoryDAL.GetCollectionDAL().GetID(platformDTO) == 0)
            {
                if (!PlatformFactoryDAL.GetCollectionDAL().Create(platformDTO))
                {
                    return new Error("Platform", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Platform");
            }

            return new Success("Platform", "Create");
        }

        public Platform Get(int id)
        {
            return new Platform(PlatformFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Platform> GetAll()
        {
            foreach (PlatformDTO platformDTO in PlatformFactoryDAL.GetCollectionDAL().GetAll())
            {
                platforms.Add(new Platform(platformDTO));
            }

            return platforms;
        }

        public IAdmin Delete(int id)
        {
            if (!PlatformFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Platform", "Delete");
            }

            return new Success("Platform", "Delete");
        }
    }

}
