using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class CertificateCollection
    {
        List<Certificate> certificates = new List<Certificate>();
        private ICertificateCollectionDAL certificateCollectionDAL = CertificateFactoryDAL.GetCollectionDAL();

        public void Create(string name, int tier)
        {
            CertificateDTO certificateDTO = new CertificateDTO
            {
                Name = name,
                Tier = tier
            };

            certificateCollectionDAL.Create(certificateDTO);
        }

        public List<Certificate> GetaAll()
        {
            foreach (CertificateDTO certificateDTO in certificateCollectionDAL.GetAll())
            {
                certificates.Add(new Certificate(certificateDTO));
            }

            return certificates;
        }

        public void Get()
        {
            // code
        }

        public void Delete()
        {
            // code
        }
    }
}
