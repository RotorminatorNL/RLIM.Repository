using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.BusinessLogic
{
    public class SubItemCollection
    {
        public void Create(int mainItemID, int certificateID, int colorID)
        {

            SubItemDTO subItemDTO = new SubItemDTO
            {
                MainItemID = mainItemID,
                CertificateID = certificateID,
                ColorID = colorID
            };

            if (SubItemFactoryDAL.GetCollectionDAL().GetID(subItemDTO) == 0)
            {
                SubItemFactoryDAL.GetCollectionDAL().Create(subItemDTO);
            }
        }

        public SubItem Get(int id)
        {
            return new SubItem(SubItemFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<SubItem> GetAll()
        {
            List<SubItem> subItems = new List<SubItem>();

            foreach (SubItemDTO subItemDTO in SubItemFactoryDAL.GetCollectionDAL().GetAll())
            {
                subItems.Add(new SubItem(subItemDTO));
            }

            return subItems;
        }

        public void Delete(int id)
        {
            SubItemFactoryDAL.GetCollectionDAL().Delete(id);
        }
    }
}
