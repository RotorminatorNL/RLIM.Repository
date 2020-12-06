using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class MainItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Category.")]
        public int CategoryID { get; set; }
        [Display(Name = "Category")]
        public string CategoryDisplay { get; set; }

        [Display(Name = "Platform")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Platform.")]
        public int PlatformID { get; set; }
        [Display(Name = "Platform")]
        public string PlatformDisplay { get; set; }

        [Display(Name = "Quality")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a Quality.")]
        public int QualityID { get; set; }
        [Display(Name = "Quality")]
        public string QualityDisplay { get; set; }
    }
}
