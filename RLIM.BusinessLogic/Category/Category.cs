using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Category
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Category(CategoryDTO categoryDTO)
        {
            ID = categoryDTO.ID;
            Name = categoryDTO.Name;
        }

        public IAdmin Update(string name)
        {
            Name = name;

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(new CategoryDTO { Name = name }) != ID)
            {
                if (!CategoryFactoryDAL.GetDAL().Update(new CategoryDTO { ID = ID, Name = Name }))
                {
                    return new Error("Category", "Changed");
                }
            }
            else
            {
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Changed");
        }
    }
}
