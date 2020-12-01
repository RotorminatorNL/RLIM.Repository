using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class SubItem
    {
        public int ID { get; private set; }
        public int MainItemID { get; private set; }

        public int CertificateID { get; private set; }
        public CertificateDTO CertifcateDTO { get; private set; }

        public int ColorID { get; private set; }
        public ColorDTO ColorDTO { get; private set; }

        public SubItem(SubItemDTO subItemDTO)
        {
            ID = subItemDTO.ID;
            MainItemID = subItemDTO.MainItemID;

            CertificateID = subItemDTO.CertificateID;
            CertifcateDTO = GetCertificateDTO(CertificateID);

            ColorID = subItemDTO.ColorID;
            ColorDTO = ColorFactoryDAL.GetCollectionDAL().Get(ColorID);
        }

        private CertificateDTO GetCertificateDTO(int id)
        {
            if (id != 0)
            {
                return CertificateFactoryDAL.GetCollectionDAL().Get(id);
            }

            return new CertificateDTO { ID = 0, Name = "None", Tier = 0 };
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
