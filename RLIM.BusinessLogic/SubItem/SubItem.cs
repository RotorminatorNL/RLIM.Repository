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

        public void Update(int mainItemID, int certificateID, int colorID)
        {
            MainItemID = mainItemID;
            CertificateID = certificateID;
            ColorID = colorID;

            SubItemFactoryDAL.GetDAL().Update(new SubItemDTO
            {
                ID = ID,
                MainItemID = MainItemID,
                CertificateID = CertificateID,
                ColorID = ColorID
            });
        }
    }
}
