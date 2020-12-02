using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class QualityCollection
    {
        public void Create(string name, int rank)
        {
            QualityDTO qualityDTO = new QualityDTO
            {
                Name = name,
                Rank = rank
            };

            QualityFactoryDAL.GetCollectionDAL().Create(qualityDTO);
        }

        public Quality Get(int id)
        {
            return new Quality(QualityFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Quality> GetAll()
        {
            List<Quality> qualities = new List<Quality>();

            foreach (QualityDTO qualityDTO in QualityFactoryDAL.GetCollectionDAL().GetAll())
            {
                qualities.Add(new Quality(qualityDTO));
            }

            return qualities;
        }

        public void Delete(int id)
        {
            QualityFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }

}
