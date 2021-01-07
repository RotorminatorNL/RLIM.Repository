using RLIM.FactoryDAL;
using RLIM.ContractLayer;
using RLIM.BusinessLogic.MessageToUI.Admin;

namespace RLIM.BusinessLogic
{
    public class Certificate
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;
        public int Tier { get; private set; }
        private readonly int previousTier;

        public Certificate(CertificateDTO certificateDTO)
        {
            ID = certificateDTO.ID;
            Name = certificateDTO.Name;
            previousName = certificateDTO.Name;
            Tier = certificateDTO.Tier;
            previousTier = certificateDTO.Tier;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetTier(int tier)
        {
            Tier = tier;
        }

        public IMessageToAdmin Update()
        {
            CertificateDTO certificateDTO = new CertificateDTO
            {
                ID = ID,
                Name = Name,
                Tier = Tier
            };

            if (CertificateFactoryDAL.GetCollectionDAL().GetID(certificateDTO) == 0)
            {
                if (!CertificateFactoryDAL.GetDAL().Update(certificateDTO))
                {
                    return new Error("Certificate", "Update");
                }
            }
            else
            {
                Name = previousName;
                Tier = previousTier;
                return new AlreadyExisting("Certificate");
            }

            return new Success("Certificate", "Update");
        }
    }
}
