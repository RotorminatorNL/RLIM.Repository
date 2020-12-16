using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class SubItem
    {
        public int ID { get; private set; }
        public int MainItemID { get; private set; }
        public int CertificateID { get; private set; }
        private readonly int previousCertificateID;
        public int ColorID { get; private set; }
        private readonly int previousColorID;

        public SubItem(SubItemDTO subItemDTO)
        {
            ID = subItemDTO.ID;
            MainItemID = subItemDTO.MainItemID;

            CertificateID = subItemDTO.CertificateID;
            previousCertificateID = subItemDTO.CertificateID;

            ColorID = subItemDTO.ColorID;
            previousColorID = subItemDTO.ColorID;
        }

        public void SetCertificateID(int id)
        {
            CertificateID = id;
        }

        public void SetColorID(int id)
        {
            ColorID = id;
        }

        public IAdmin Update()
        {
            SubItemDTO subItemDTO = new SubItemDTO
            {
                ID = ID,
                MainItemID = MainItemID,
                CertificateID = CertificateID,
                ColorID = ColorID
            };

            if (SubItemFactoryDAL.GetCollectionDAL().GetID(subItemDTO) == 0)
            {
                if (!SubItemFactoryDAL.GetDAL().Update(subItemDTO))
                {
                    return new Error("Sub-Item", "Update");
                }
            }
            else
            {
                CertificateID = previousCertificateID;
                ColorID = previousColorID;

                return new AlreadyExisting("Sub-Item");
            }

            return new Success("Sub-Item", "Update");
        }
    }
}
