using RLIM.BusinessLogic.MessageToUI.Admin;
using RLIM.ContractLayer;
using RLIM.FactoryDAL;
using System.Collections.Generic;

namespace RLIM.BusinessLogic
{
    public class CategoryCollection
    {
        private readonly List<Category> categories = new List<Category>();
        private readonly ICategoryCollectionDAL categoryCollectionDAL;

        public CategoryCollection()
        {
            categoryCollectionDAL = CategoryFactoryDAL.GetCollectionDAL();
        }

        public CategoryCollection(ICategoryCollectionDAL categoryCollectionDAL)
        {
            this.categoryCollectionDAL = categoryCollectionDAL;
        }

        public IMessageToAdmin Create(string name)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Name = name
            };

            if (categoryCollectionDAL.GetID(categoryDTO) == 0)
            {
                if (!categoryCollectionDAL.Create(categoryDTO))
                {
                    return new Error("Category", "Create");
                }
            }
            else
            {
                return new AlreadyExisting("Category");
            }

            return new Success("Category", "Create");
        }

        public Category Get(int id)
        {
            return new Category(categoryCollectionDAL.Get(id));
        }

        public List<Category> GetAll()
        {
            foreach (CategoryDTO categoryDTO in categoryCollectionDAL.GetAll())
            {
                categories.Add(new Category(categoryDTO));
            }

            return categories;
        }

        public IMessageToAdmin Delete(int id)
        {
            if (!categoryCollectionDAL.Delete(id))
            {
                return new Error("Category", "Delete");
            }

            return new Success("Category", "Delete");
        }
    }

}
