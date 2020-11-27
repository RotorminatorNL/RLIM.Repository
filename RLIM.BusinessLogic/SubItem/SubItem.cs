using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class SubItem
    {
        public int ID { get; private set; }
        public int MainItemID { get; private set; }
        public CertificateDTO CertifcateDTO { get; private set; }
        public ColorDTO ColorDTO { get; private set; }
        
        public SubItem(SubItemDTO subItemDTO)
        {
            ID = subItemDTO.ID;
            MainItemID = subItemDTO.MainItemID;
            CertifcateDTO = GetCertificateDTO(subItemDTO.CertificateID);
            ColorDTO = ColorFactoryDAL.GetCollectionDAL().Get(subItemDTO.ColorID);
        }

        private CertificateDTO GetCertificateDTO(int id)
        {
            if (id != 0)
            {
                return CertificateFactoryDAL.GetCollectionDAL().Get(id);
            }

            return new CertificateDTO { ID = 0, Name = "None", Tier = 0 };
        }

        public void Update()
        {
            // code
        }
    }
}
