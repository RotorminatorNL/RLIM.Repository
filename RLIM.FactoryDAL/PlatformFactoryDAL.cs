using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class PlatformFactoryDAL
    {
        public static IPlatformCollectionDAL GetCollectionDAL()
        {
            return new PlatformDAL();
        }

        public static IPlatformDAL GetDAL()
        {
            return new PlatformDAL();
        }
    }
}
