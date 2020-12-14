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
            CategoryDTO categoryDTO = new CategoryDTO
            {
                ID = ID,
                Name = name
            };

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(categoryDTO) == 0)
            {
                if (!CategoryFactoryDAL.GetDAL().Update(categoryDTO))
                {
                    return new Error("Category", "Update");
                }
            }
            else
            {
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Update");
        }
    }
}
