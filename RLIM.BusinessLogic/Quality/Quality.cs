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

        public void Update(string name, int rank)
        {
            Name = name;
            Rank = rank;

            QualityFactoryDAL.GetDAL().Update(new QualityDTO
            {
                ID = ID,
                Name = Name,
                Rank = Rank
            });
        }
    }
}
