using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class CategoryFactoryDAL
    {
        public static ICategoryCollectionDAL GetCollectionDAL()
        {
            return new CategoryDAL();
        }

        public static ICategoryDAL GetDAL()
        {
            return new CategoryDAL();
        }
    }
}
