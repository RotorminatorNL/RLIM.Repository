using System.ComponentModel.DataAnnotations;

namespace RLIM.UserInterface.Models
{
    public class MainItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name = "Category")]
        public string CategoryDisplay { get; set; }

        [Display(Name = "Platform")]
        public int PlatformID { get; set; }
        [Display(Name = "Platform")]
        public string PlatformDisplay { get; set; }

        [Display(Name = "Quality")]
        public int QualityID { get; set; }
        [Display(Name = "Quality")]
        public string QualityDisplay { get; set; }
    }
}
