using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class MainItemModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to select a Category")]
        public CategoryModel Category { get; set; }

        [Required(ErrorMessage = "No specific Platform? Please select 'All'.")]
        public PlatformModel Platform { get; set; }

        [Required(ErrorMessage = "You need to select a Quality")]
        public QualityModel Quality { get; set; }
    }
}
