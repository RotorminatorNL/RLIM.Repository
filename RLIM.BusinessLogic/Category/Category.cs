using RLIM.BusinessLogic.MessageToUI.Admin;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;

namespace RLIM.BusinessLogic
{
    public class Category
    {
        private ICategoryCollectionDAL categoryCollectionDAL;
        private ICategoryDAL categoryDAL;

        public int ID { get; private set; }
        public string Name { get; private set; }
        private readonly string previousName;

        public Category(CategoryDTO categoryDTO)
        {
            ID = categoryDTO.ID;
            Name = categoryDTO.Name;
            previousName = categoryDTO.Name;

            categoryDAL = CategoryFactoryDAL.GetDAL();
            categoryCollectionDAL = CategoryFactoryDAL.GetCollectionDAL();
        }

        public void SetName(string name)
        {
            Name = name != "" ? name : Name;
        }

        public IMessageToAdmin Update()
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                ID = ID,
                Name = Name
            };

            if (categoryCollectionDAL.GetID(categoryDTO) == 0)
            {
                if (!categoryDAL.Update(categoryDTO))
                {
                    return new Error("Category", "Update");
                }
            }
            else
            {
                Name = previousName;
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Update");
        }

        public IMessageToAdmin Update(ICategoryCollectionDAL categoryCollectionDAL, ICategoryDAL categoryDAL)
        {
            this.categoryCollectionDAL = categoryCollectionDAL;
            this.categoryDAL = categoryDAL;

            CategoryDTO categoryDTO = new CategoryDTO
            {
                ID = ID,
                Name = Name
            };

            if (categoryCollectionDAL.GetID(categoryDTO) == 0)
            {
                if (!categoryDAL.Update(categoryDTO))
                {
                    return new Error("Category", "Update");
                }
            }
            else
            {
                Name = previousName;
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Update");
        }
    }
}
