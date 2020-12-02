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

        public void Update(string name)
        {
            Name = name;

            PlatformFactoryDAL.GetDAL().Update(new PlatformDTO
            {
                ID = ID,
                Name = Name
            });
        }
    }
}
