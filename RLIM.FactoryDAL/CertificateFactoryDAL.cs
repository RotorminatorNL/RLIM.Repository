using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class CertificateFactoryDAL
    {
        public static ICertificateCollectionDAL GetCollectionDAL()
        {
            return new CertificateDAL();
        }

        public static ICertificateDAL GetDAL()
        {
            return new CertificateDAL();
        }
    }
}
