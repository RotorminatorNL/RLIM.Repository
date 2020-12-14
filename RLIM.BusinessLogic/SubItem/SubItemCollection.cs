using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class SubItemCollection
    {
        public IAdmin Create(int mainItemID, int certificateID, int colorID)
        {

            SubItemDTO subItemDTO = new SubItemDTO
            {
                MainItemID = mainItemID,
                CertificateID = certificateID,
                ColorID = colorID
            };

            if (SubItemFactoryDAL.GetCollectionDAL().GetID(subItemDTO) == 0)
            {
                if (!SubItemFactoryDAL.GetCollectionDAL().Create(subItemDTO))
                {
                    return new Error("Sub-Item", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Sub-Item");
            }

            return new Success("Sub-Item", "Create");
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

        public IAdmin Delete(int id)
        {
            if (!SubItemFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Sub-Item", "Delete");
            }

            return new Success("Sub-Item", "Delete");
        }
    }
}
