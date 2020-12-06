using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLIM.UI.Controllers
{
    public class MainItemController : Controller
    {
        private CategoryModel GetCategory(int id)
        {
            Category category = new CategoryCollection().Get(id);

            return new CategoryModel
            {
                ID = category.ID,
                Name = category.Name
            };
        }

        private List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            foreach (Category category in new CategoryCollection().GetAll())
            {
                categories.Add(new CategoryModel
                {
                    ID = category.ID,
                    Name = category.Name
                });
            }

            return categories;
        }

        private PlatformModel GetPlatform(int id)
        {
            Platform platform = new PlatformCollection().Get(id);

            return new PlatformModel
            {
                ID = platform.ID,
                Name = platform.Name
            };
        }

        private List<PlatformModel> GetPlatforms()
        {
            List<PlatformModel> platforms = new List<PlatformModel>();

            foreach (Platform platform in new PlatformCollection().GetAll())
            {
                platforms.Add(new PlatformModel
                {
                    ID = platform.ID,
                    Name = platform.Name
                });
            }

            return platforms;
        }

        private QualityModel GetQuality(int id)
        {
            Quality quality = new QualityCollection().Get(id);

            return new QualityModel
            {
                ID = quality.ID,
                Name = quality.Name,
                Rank = quality.Rank,
                Display = $"{quality.Name} ({quality.Rank})"
            };
        }

        private List<QualityModel> GetQualities()
        {
            List<QualityModel> qualities = new List<QualityModel>();

            foreach (Quality quality in new QualityCollection().GetAll())
            {
                qualities.Add(new QualityModel
                {
                    ID = quality.ID,
                    Name = quality.Name,
                    Rank = quality.Rank,
                    Display = $"{quality.Name} ({quality.Rank})"
                });
            }

            return qualities;
        }

        private List<MainItemModel> GetMainItems()
        {
            List<MainItemModel> mainItems = new List<MainItemModel>();

            foreach (MainItem mainItem in new MainItemCollection().GetAll())
            {
                mainItems.Add(new MainItemModel
                {
                    ID = mainItem.ID,
                    Name = mainItem.Name,
                    CategoryDisplay = GetCategory(mainItem.CategoryID).Name,
                    PlatformDisplay = GetPlatform(mainItem.PlatformID).Name,
                    QualityDisplay = GetQuality(mainItem.QualityID).Display
                });
            }

            return mainItems;
        }

        public IActionResult Index()
        {
            return View(GetMainItems());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Platforms = GetPlatforms();
            ViewBag.Qualities = GetQualities();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MainItemModel model)
        {
            if (ModelState.IsValid)
            {
                new MainItemCollection().Create(model.Name, model.CategoryID, model.PlatformID, model.QualityID);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
    }
}
