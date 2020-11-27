using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class ColorFactoryDAL
    {
        public static IColorCollectionDAL GetCollectionDAL()
        {
            return new ColorDAL();
        }

        public static IColorDAL GetDAL()
        {
            return new ColorDAL();
        }
    }
}
