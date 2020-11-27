using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class ColorFactoryDAL
    {
        public static IColorDAL GetDAL()
        {
            return new ColorDAL();
        }

        public static IColorCollectionDAL GetCollectionDAL()
        {
            return new ColorDAL();
        }
    }
}
