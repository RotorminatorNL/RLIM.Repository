using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Quality
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;
        public int Rank { get; private set; }
        private readonly int previousRank;

        public Quality(QualityDTO qualityDTO)
        {
            ID = qualityDTO.ID;
            Name = qualityDTO.Name;
            previousName = qualityDTO.Name;
            Rank = qualityDTO.Rank;
            previousRank = qualityDTO.Rank;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetRank(int rank)
        {
            Rank = rank;
        }

        public IAdmin Update()
        {
            QualityDTO qualityDTO = new QualityDTO
            {
                ID = ID,
                Name = Name,
                Rank = Rank
            };

            if (QualityFactoryDAL.GetCollectionDAL().GetID(qualityDTO) == 0)
            {
                if (!QualityFactoryDAL.GetDAL().Update(qualityDTO))
                {
                    return new Error("Quality", "Update");
                }
            }
            else
            {
                Name = previousName;
                Rank = previousRank;
                return new AlreadyExisting("Quality");
            }

            return new Success("Quality", "Update");
        }
    }
}
