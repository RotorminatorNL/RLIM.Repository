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
            Name = name;
            Tier = tier;

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(new CertificateDTO { Name = name, Tier = tier }) != ID)
            {
                if (!CertificateFactoryDAL.GetDAL().Update(new CertificateDTO { ID = ID, Name = Name, Tier = Tier }))
                {
                    return new Error("Certificate", "Changed");
                }
            }
            else
            {
                return new AlreadyExisting("Certificate");
            }

            return new Success("Certificate", "Changed");
        }
    }
}
