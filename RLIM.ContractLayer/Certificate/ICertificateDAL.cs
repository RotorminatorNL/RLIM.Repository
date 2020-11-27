using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ICertificateDAL
    {
        void Update(CertificateDTO certificateDTO);
    }
}
