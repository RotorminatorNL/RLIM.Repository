using Microsoft.AspNetCore.Mvc;
using RLIM.BusinessLogic;
using RLIM.UI.Models;
using System.Collections.Generic;

namespace RLIM.UI.Controllers
{
    public class SubItemController : Controller
    {
        public IActionResult Index()
        {
            List<SubItemModel> subItemModels = new List<SubItemModel>();

            foreach (SubItem subItem in new SubItemCollection().GetAll())
            {
                subItemModels.Add(new SubItemModel
                {
                    ID = subItem.ID,
                    MainItemID = subItem.MainItemID,
                    Certificate = new CertificateModel 
                    { 
                        ID = subItem.CertifcateDTO.ID,
                        Name = subItem.CertifcateDTO.Name,
                        Tier = subItem.CertifcateDTO.Tier
                    },
                    Color = new ColorModel
                    {
                        ID = subItem.ColorDTO.ID,
                        Name = subItem.ColorDTO.Name,
                        Hex = subItem.ColorDTO.Hex
                    }
                });
            }

            return View(subItemModels);
        }
    }
}
