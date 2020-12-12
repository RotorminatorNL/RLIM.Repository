using System.Collections.Generic;

namespace RLIM.ContractLayer
{
    public interface ICertificateCollectionDAL
    {
        bool Create(CertificateDTO certificateDTO);
        CertificateDTO Get(int id);
        int GetID(CertificateDTO certificateDTO);
        List<CertificateDTO> GetAll();
        bool Delete(int id);
    }
}
