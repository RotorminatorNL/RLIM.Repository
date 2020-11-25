using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class CertificateFactoryDAL
    {
        public static ICertificateDAL GetDAL()
        {
            return new CertificateDAL();
        }

        public static ICertificateCollectionDAL GetCollectionDAL()
        {
            return new CertificateDAL();
        }
    }
}
