using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class PlatformCollection
    {
        public void Create(string name)
        {
            PlatformDTO platformDTO = new PlatformDTO
            {
                Name = name
            };

            PlatformFactoryDAL.GetCollectionDAL().Create(platformDTO);
        }

        public Platform Get(int id)
        {
            return new Platform(PlatformFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Platform> GetAll()
        {
            List<Platform> platforms = new List<Platform>();

            foreach (PlatformDTO platformDTO in PlatformFactoryDAL.GetCollectionDAL().GetAll())
            {
                platforms.Add(new Platform(platformDTO));
            }

            return platforms;
        }

        public void Delete(int id)
        {
            PlatformFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }

}
