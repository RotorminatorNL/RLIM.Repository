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

        private List<MainItemModel> GetMainItemModels()
        {
            List<MainItemModel> mainItemModels = new List<MainItemModel>();

            foreach (MainItem mainItem in new MainItemCollection().GetAll())
            {
                mainItemModels.Add(new MainItemModel
                {
                    ID = mainItem.ID,
                    Name = mainItem.Name,
                    CategoryDisplay = GetCategoryModel(mainItem.CategoryID).Name,
                    PlatformDisplay = GetPlatformModel(mainItem.PlatformID).Name,
                    QualityDisplay = GetQualityModel(mainItem.QualityID).Display,
                    SubItemModels = GetSubItemModels(mainItem.GetSubItems())
                });
            }

            return mainItemModels;
        }

        public IActionResult Index()
        {
            ViewBag.MainItems = GetMainItemModels();

            return View();
        }
    }
}
