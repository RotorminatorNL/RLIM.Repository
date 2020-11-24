using RLIM.ContractLayer;
using System.Collections.Generic;

namespace RLIM.DataAccess
{
    public class CertificateDAL : ICertificateCollectionDAL, ICertificateDAL
    {
        public void Create(CertificateDTO certificateDTO)
        {

        }

        public CertificateDTO Get(int id)
        {
            return null;
        }

        public List<CertificateDTO> GetAll()
        {
            return null;
        }

        public void Update(int id, string name, int tier)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
