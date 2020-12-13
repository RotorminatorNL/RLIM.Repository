using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CategoryCollection
    {
        public IAdmin Create(string name)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Name = name
            };

            if (CategoryFactoryDAL.GetCollectionDAL().GetID(categoryDTO) == 0)
            {
                if (!CategoryFactoryDAL.GetCollectionDAL().Create(categoryDTO))
                {
                    return new Error("Category", "Added");
                }
            }
            else
            {
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Added");
        }

        public Category Get(int id)
        {
            return new Category(CategoryFactoryDAL.GetCollectionDAL().Get(id));
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            foreach (CategoryDTO categoryDTO in CategoryFactoryDAL.GetCollectionDAL().GetAll())
            {
                categories.Add(new Category(categoryDTO));
            }

            return categories;
        }

        public IAdmin Delete(int id)
        {
            if (!CategoryFactoryDAL.GetCollectionDAL().Delete(id))
            {
                return new Error("Category", "Removed");
            }

            return new Success("Category", "Removed");
        }
    }

}
