using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class MainItemFactoryDAL
    {
        public static IMainItemCollectionDAL GetCollectionDAL()
        {
            return new MainItemDAL();
        }

        public static IMainItemDAL GetDAL()
        {
            return new MainItemDAL();
        }
    }
}
