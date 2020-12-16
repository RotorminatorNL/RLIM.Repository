using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CertificateCollection
    {
        private readonly List<Certificate> certificates = new List<Certificate>();

        public IAdmin Create(string name, int tier)
        {
            CertificateDTO certificateDTO = new CertificateDTO
            {
                Name = name,
                Tier = tier
            };

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                if (!CertificateFactoryDAL.GetCollectionDAL().Create(certificateDTO))
                {
                    return new Error("Certificate", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Certificate");
            }

            return new Success("Certificate", "Create");
        }

        public Certificate Get(int id)
        {
            return new Certificate(CertificateFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Certificate> GetAll()
        {
            foreach (CertificateDTO certificateDTO in CertificateFactoryDAL.GetCollectionDAL().GetAll())
            {
                certificates.Add(new Certificate(certificateDTO));
            }

            return certificates;
        }

        public IAdmin Delete(int id)
        {
            if (!CertificateFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Certificate", "Delete");
            }

            return new Success("Certificate", "Delete");
        }
    }
}
