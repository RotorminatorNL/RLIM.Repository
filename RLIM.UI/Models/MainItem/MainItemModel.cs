using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class MainItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to select a Category.")]
        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }
        public string CategoryDisplay { get; set; }

        [Required(ErrorMessage = "You need to select a Platform.")]
        public int PlatformID { get; set; }
        public PlatformModel Platform { get; set; }
        public string PlatformDisplay { get; set; }

        [Required(ErrorMessage = "You need to select a Quality.")]
        public int QualityID { get; set; }
        public QualityModel Quality { get; set; }
        public string QualityDisplay { get; set; }
    }
}
