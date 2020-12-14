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
        public int ColorID { get; private set; }

        public SubItem(SubItemDTO subItemDTO)
        {
            ID = subItemDTO.ID;
            MainItemID = subItemDTO.MainItemID;
            CertificateID = subItemDTO.CertificateID;
            ColorID = subItemDTO.ColorID;
        }

        public IAdmin Update(int mainItemID, int certificateID, int colorID)
        {
            SubItemDTO subItemDTO = new SubItemDTO
            {
                ID = ID,
                MainItemID = mainItemID,
                CertificateID = certificateID,
                ColorID = colorID
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
                return new AlreadyExisting("Sub-Item");
            }

            return new Success("Sub-Item", "Update");
        }
    }
}
