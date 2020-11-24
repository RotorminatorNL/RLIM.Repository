using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface ICertificateCollectionDAL
    {
        void Create(CertificateDTO certificateDTO);
        CertificateDTO Get(int id);
        List<CertificateDTO> GetAll();
        void Delete(int id);
    }
}
