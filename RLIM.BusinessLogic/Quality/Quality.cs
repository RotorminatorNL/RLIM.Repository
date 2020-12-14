using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Quality
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }

        public Quality(QualityDTO qualityDTO)
        {
            ID = qualityDTO.ID;
            Name = qualityDTO.Name;
            Rank = qualityDTO.Rank;
        }

        public IAdmin Update(string name, int rank)
        {
            QualityDTO qualityDTO = new QualityDTO
            {
                ID = ID,
                Name = name,
                Rank = rank
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
                return new AlreadyExisting("Quality");
            }

            return new Success("Quality", "Update");
        }
    }
}
