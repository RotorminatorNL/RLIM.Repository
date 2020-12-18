using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RLIM.Tests
{
    public class TestCategoryDAL : ICategoryCollectionDAL, ICategoryDAL
    {
        private readonly List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

        private int GetFreeID()
        {
            int id;

            try
            {
                id = categoryDTOs[categoryDTOs.Count - 1].ID + 1;
            }
            catch (Exception)
            {
                id = 1;
            }

            return id;
        }

        public bool Create(CategoryDTO categoryDTO)
        {
            bool isCreated = false;

            try
            {
                if (GetID(categoryDTO) == 0 && categoryDTO.Name != "")
                {
                    categoryDTO.ID = GetFreeID();
                    categoryDTOs.Add(categoryDTO);
                    isCreated = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return isCreated;
        }

        public CategoryDTO Get(int id)
        {
            CategoryDTO categoryDTO = new CategoryDTO { ID = 0, Name = "No Category" };

            try
            {
                foreach (CategoryDTO category in categoryDTOs)
                {
                    if (category.ID == id)
                    {
                        categoryDTO = category;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return categoryDTO;
        }

        public int GetID(CategoryDTO categoryDTO)
        {
            int id = 0;

            foreach (CategoryDTO category in categoryDTOs)
            {
                id = category.Name == categoryDTO.Name ? category.ID : id;
            }

            return id;
        }

        public List<CategoryDTO> GetAll()
        {
            return categoryDTOs;
        }

        public bool Update(CategoryDTO categoryDTO)
        {
            bool isUpdated = false;

            try
            {
                if (GetID(categoryDTO) == 0 && categoryDTO.Name != "")
                {
                    Get(categoryDTO.ID).Name = categoryDTO.Name;
                    isUpdated = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            try
            {
                foreach (CategoryDTO category in categoryDTOs)
                {
                    if (category.ID == id)
                    {
                        categoryDTOs.Remove(category);
                        isDeleted = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return isDeleted;
        }
    }
}
