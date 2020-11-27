using System;
using System.Collections.Generic;
using System.Text;
using RLIM.FactoryDAL;
using RLIM.ContractLayer;

namespace RLIM.BusinessLogic
{
    public class Certificate
    {
        private readonly ICertificateDAL certificateDAL = CertificateFactoryDAL.GetDAL();

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Tier { get; private set; }

        public Certificate(CertificateDTO certificateDTO)
        {
            ID = certificateDTO.ID;
            Name = certificateDTO.Name;
            Tier = certificateDTO.Tier;
        }

        public void Update(string name, int tier)
        {
            Name = name;
            Tier = tier;

            CertificateDTO certificateDTO = new CertificateDTO
            {
                ID = ID,
                Name = Name,
                Tier = Tier
            };

            certificateDAL.Update(certificateDTO);
        }
    }
}
