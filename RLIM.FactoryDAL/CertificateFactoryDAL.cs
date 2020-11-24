using RLIM.ContractLayer;
using RLIM.DataAccess;

namespace RLIM.FactoryDAL
{
    public static class CertificateFactoryDAL
    {
        public static ICertificateDAL CertificateDAL()
        {
            return new CertificateDAL();
        }

        public static ICertificateCollectionDAL CertificateCollectionDAL()
        {
            return new CertificateDAL();
        }
    }
}
