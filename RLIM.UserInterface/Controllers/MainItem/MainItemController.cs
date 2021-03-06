﻿using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.BusinessLogic.MessageToUI.Admin;
using RLIM.UserInterface.Models;
using System.Collections.Generic;

namespace RLIM.UserInterface.Controllers
{
    [Route("/Main-Item/[action]")]
    [Route("/Main-Item/{id}/[action]")]
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
                    Display = $"{quality.Name} ({quality.Rank})"
                });
            }

            return qualities;
        }

        private MainItemModel GetMainItem(int id)
        {
            MainItem mainItem = new MainItemCollection().Get(id);

            return new MainItemModel
            {
                ID = mainItem.ID,
                Name = mainItem.Name,
                CategoryID = mainItem.CategoryID,
                CategoryDisplay = GetCategory(mainItem.CategoryID).Name,
                PlatformID = mainItem.PlatformID,
                PlatformDisplay = GetPlatform(mainItem.PlatformID).Name,
                QualityID = mainItem.QualityID,
                QualityDisplay = GetQuality(mainItem.QualityID).Display
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
                    CategoryDisplay = GetCategory(mainItem.CategoryID).Name,
                    PlatformDisplay = GetPlatform(mainItem.PlatformID).Name,
                    QualityDisplay = GetQuality(mainItem.QualityID).Display
                });
            }

            return mainItems;
        }

        private IActionResult MessageHandler(IMessageToAdmin msg, MainItemModel model, string action)
        {
            TempData["MessageTitle"] = msg.Title;
            TempData["MessageText"] = msg.Text;

            if (msg.Status == "Error")
            {
                if (action == "Create")
                {
                    TempData["MainItemName"] = model.Name;
                    TempData["CategoryID"] = model.CategoryID;
                    TempData["PlatformID"] = model.CategoryID;
                    TempData["QualityID"] = model.CategoryID;
                    return RedirectToAction("Create", "MainItem");
                }
                else
                {
                    return RedirectToRoute("Main-Item_ID_Action", new { model.ID });
                }
            }

            return RedirectToAction("Index", "MainItem");
        }

        [Route("/Main-Items")]
        public IActionResult Index()
        {
            return View(GetMainItems());
        }

        public IActionResult Attributes()
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Platforms = GetPlatforms();
            ViewBag.Qualities = GetQualities();

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Platforms = GetPlatforms();
            ViewBag.Qualities = GetQualities();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MainItemModel model)
        {
            if (ModelState.IsValid)
            {
                IMessageToAdmin msg = new MainItemCollection().Create(model.Name, model.CategoryID, model.PlatformID, model.QualityID);
                return MessageHandler(msg, model, "Create");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                ViewBag.Categories = GetCategories();
                ViewBag.Platforms = GetPlatforms();
                ViewBag.Qualities = GetQualities();

                return View(GetMainItem(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MainItemModel model)
        {
            if (ModelState.IsValid)
            {
                MainItem mainItem = new MainItemCollection().Get(model.ID);
                mainItem.SetName(model.Name);
                mainItem.SetCategoryID(model.CategoryID);
                mainItem.SetPlatformID(model.PlatformID);
                mainItem.SetQualityID(model.QualityID);

                return MessageHandler(mainItem.Update(), model, "Update");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return View(GetMainItem(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MainItemModel model)
        {
            if (ModelState.IsValid)
            {
                IMessageToAdmin msg = new MainItemCollection().Delete(model.ID);
                return MessageHandler(msg, model, "Create"); 
            }

            return RedirectToAction("Index");
        }
    }
}
