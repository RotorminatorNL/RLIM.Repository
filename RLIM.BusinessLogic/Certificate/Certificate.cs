using System;
using System.Collections.Generic;
using System.Text;
using RLIM.FactoryDAL;
using RLIM.ContractLayer;
using RLIM.BusinessLogic.MessageToUI;

namespace RLIM.BusinessLogic
{
    public class Certificate
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Tier { get; private set; }

        public Certificate(CertificateDTO certificateDTO)
        {
            ID = certificateDTO.ID;
            Name = certificateDTO.Name;
            Tier = certificateDTO.Tier;
        }

        public IAdmin Update(string name, int tier)
        {
            CertificateDTO certificateDTO = new CertificateDTO
            {
                ID = ID,
                Name = name,
                Tier = tier
            };

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                if (!CertificateFactoryDAL.GetDAL().Update(certificateDTO))
                {
                    return new Error("Certificate", "Update");
                }
            }
            else
            {
                return new AlreadyExisting("Certificate");
            }

            return new Success("Certificate", "Update");
        }
    }
}
