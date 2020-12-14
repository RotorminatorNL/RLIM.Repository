using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IQualityCollectionDAL
    {
        bool Create(QualityDTO qualityDTO);
        QualityDTO Get(int id);
        int GetID(QualityDTO qualityDTO);
        List<QualityDTO> GetAll();
        bool Delete(int id);
    }
}
