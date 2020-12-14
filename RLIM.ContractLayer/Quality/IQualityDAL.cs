using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.ContractLayer
{
    public interface IQualityDAL
    {
        bool Update(QualityDTO qualityDTO);
    }
}
