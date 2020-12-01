using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class QualityFactoryDAL
    {
        public static IQualityCollectionDAL GetCollectionDAL()
        {
            return new QualityDAL();
        }

        public static IQualityDAL GetDAL()
        {
            return new QualityDAL();
        }
    }
}
