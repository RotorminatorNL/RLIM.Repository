﻿using System.Collections.Generic;

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
