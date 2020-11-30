using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IQualityCollectionDAL
    {
        void Create(QualityDTO qualityDTO);
        QualityDTO Get(int id);
        List<QualityDTO> GetAll();
        void Delete(int id);
    }
}
