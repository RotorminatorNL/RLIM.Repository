using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class QualityDAL : IQualityCollectionDAL, IQualityDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(QualityDTO qualityDTO)
        {
            // code
        }

        public QualityDTO Get(int id)
        {
            QualityDTO qualityDTO = null;

            // code

            return qualityDTO;
        }

        public List<QualityDTO> GetAll()
        {
            List<QualityDTO> qualityDTOs = new List<QualityDTO>();

            // code

            return qualityDTOs;
        }

        public void Update(QualityDTO qualityDTO)
        {
            // code
        }

        public void Delete(int id)
        {
            // code
        }
    }
}
