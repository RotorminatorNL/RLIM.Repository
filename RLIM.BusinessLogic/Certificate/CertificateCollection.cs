using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CertificateCollection
    {
        public void Create(string name, int tier)
        {
            CertificateDTO certificateDTO = new CertificateDTO
            {
                Name = name,
                Tier = tier
            };

            CertificateFactoryDAL.GetCollectionDAL().Create(certificateDTO);
        }

        public Certificate Get(int id)
        {
            return new Certificate(CertificateFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Certificate> GetAll()
        {
            List<Certificate> certificates = new List<Certificate>();

            foreach (CertificateDTO certificateDTO in CertificateFactoryDAL.GetCollectionDAL().GetAll())
            {
                certificates.Add(new Certificate(certificateDTO));
            }

            return certificates;
        }

        public void Delete(int id)
        {
            CertificateFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }
}
