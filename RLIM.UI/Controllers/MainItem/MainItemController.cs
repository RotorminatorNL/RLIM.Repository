using Microsoft.AspNetCore.Mvc;
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

        private PlatformModel GetPlatform(int id)
        {
            Platform platform = new PlatformCollection().Get(id);

            return new PlatformModel
            {
                ID = platform.ID,
                Name = platform.Name
            };
        }

        private QualityModel GetQuality(int id)
        {
            Quality quality = new QualityCollection().Get(id);

            return new QualityModel
            {
                ID = quality.ID,
                Name = quality.Name,
                Rank = quality.Rank
            };
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
                    Category = GetCategory(mainItem.CategoryID),
                    Platform = GetPlatform(mainItem.PlatformID),
                    Quality = GetQuality(mainItem.QualityID)
                });
            }

            return mainItems;
        }

        public IActionResult Index()
        {
            return View(GetMainItems());
        }
    }
}
