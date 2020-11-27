using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class SubItemFactoryDAL
    {
        public static ISubItemCollectionDAL GetCollectionDAL()
        {
            return new SubItemDAL();
        }

        public static ISubItemDAL GetDAL()
        {
            return new SubItemDAL();
        }
    }
}
