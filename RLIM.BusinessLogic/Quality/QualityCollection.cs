using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class QualityCollection
    {
        private readonly List<Quality> qualities = new List<Quality>();

        public IAdmin Create(string name, int rank)
        {
            QualityDTO qualityDTO = new QualityDTO
            {
                Name = name,
                Rank = rank
            };

            if (QualityFactoryDAL.GetCollectionDAL().GetID(qualityDTO) == 0)
            {
                if (!QualityFactoryDAL.GetCollectionDAL().Create(qualityDTO))
                {
                    return new Error("Quality", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Quality");
            }

            return new Success("Quality", "Create");
        }

        public Quality Get(int id)
        {
            return new Quality(QualityFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Quality> GetAll()
        {
            foreach (QualityDTO qualityDTO in QualityFactoryDAL.GetCollectionDAL().GetAll())
            {
                qualities.Add(new Quality(qualityDTO));
            }

            return qualities;
        }

        public IAdmin Delete(int id)
        {
            if (!QualityFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Quality", "Delete");
            }

            return new Success("Quality", "Delete");
        }
    }

}
