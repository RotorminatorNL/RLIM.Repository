using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UserInterface.Controllers
{
    public class UserController : Controller
    {
        private CertificateModel GetCertificateModel(int id)
        {
            Certificate certificate = new CertificateCollection().Get(id);

            return new CertificateModel
            {
                Display = certificate.ID == 0 ? certificate.Name : $"{certificate.Name} ({certificate.Tier})"
            };
        }

        private ColorModel GetColorModel(int id)
        {
            Color color = new ColorCollection().Get(id);

            return new ColorModel
            {
                Display = color.ID == 0 ? color.Name : $"{color.Name} ({color.Hex})"
            };
        }

        private List<SubItemModel> GetSubItemModels(List<SubItem> subItems)
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            foreach (SubItem subItem in subItems)
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    CertificateDisplay = GetCertificateModel(subItem.CertificateID).Display,
                    ColorDisplay = GetColorModel(subItem.ColorID).Display
                });
            }

            return subItemModels;
        }

        private CategoryModel GetCategoryModel(int id)
        {
            Category category = new CategoryCollection().Get(id);

            return new CategoryModel
            {
                Name = category.Name
            };
        }

        private List<CategoryModel> GetCategoryModels()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            foreach (Category category in new CategoryCollection().GetAll())
            {
                string[] categoryNameArr = category.Name.Split(" ");
                string newCategoryName = "";
                if (categoryNameArr.Length > 1)
                {
                    newCategoryName = $"{categoryNameArr[0]}-{categoryNameArr[1]}";
                }

                categories.Add(new CategoryModel
                {
                    ID = category.ID,
                    Name = newCategoryName == "" ? category.Name : newCategoryName
                });
            }

            return categories;
        }

        private PlatformModel GetPlatformModel(int id)
        {
            Platform platform = new PlatformCollection().Get(id);

            return new PlatformModel
            {
                Name = platform.Name
            };
        }

        private QualityModel GetQualityModel(int id)
        {
            Quality quality = new QualityCollection().Get(id);

            return new QualityModel
            {
                Display = $"{quality.Name} ({quality.Rank})"
            };
        }

        private List<MainItemModel> GetMainItemModels(string categoryName)
        {
            List<MainItemModel> mainItemModels = new List<MainItemModel>();

            foreach (MainItem mainItem in new MainItemCollection().GetAll())
            {
                CategoryModel category = GetCategoryModel(mainItem.CategoryID);

                if (categoryName == "All" || category.Name == categoryName)
                {
                    mainItemModels.Add(new MainItemModel
                    {
                        ID = mainItem.ID,
                        Name = mainItem.Name,
                        CategoryDisplay = category.Name,
                        PlatformDisplay = GetPlatformModel(mainItem.PlatformID).Name,
                        QualityDisplay = GetQualityModel(mainItem.QualityID).Display,
                        SubItemModels = GetSubItemModels(mainItem.GetSubItems())
                    });
                }
            }

            return mainItemModels;
        }

        [Route("[controller]/[action]/{categoryName}")]
        public IActionResult Show(string categoryName)
        {
            ViewBag.SelectedCategory = categoryName;

            try
            {
                string[] categoryNameArr = categoryName.Split("-");
                categoryName = $"{categoryNameArr[0]} {categoryNameArr[1]}";
            }
            catch (Exception)
            {

            }

            ViewBag.Categories = GetCategoryModels();
            ViewBag.MainItems = GetMainItemModels(categoryName);

            return View();
        }
    }
}
