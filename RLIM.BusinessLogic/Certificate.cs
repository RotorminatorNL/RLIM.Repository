using System;
using System.Collections.Generic;
using System.Text;
using RLIM.FactoryDAL;
using RLIM.ContractLayer;

namespace RLIM.BusinessLogic
{
    public class Certificate
    {
        private int id;
        private string name;
        private int tier;

        public Certificate(CertificateDTO certificateDTO)
        {
            id = certificateDTO.Id;
            name = certificateDTO.Name;
            tier = certificateDTO.Tier;
        }

        public void Update()
        {
            ICertificateDAL certificateDAL = CertificateFactoryDAL.CertificateDAL();
            // code
        }
    }
}
