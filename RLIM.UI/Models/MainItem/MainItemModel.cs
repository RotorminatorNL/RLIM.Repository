using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class MainItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to select a Category")]
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }

        [Required(ErrorMessage = "No specific Platform? Please select 'All'.")]
        public int PlatformId { get; set; }
        public PlatformModel PlatformModel { get; set; }

        [Required(ErrorMessage = "You need to select a Quality")]
        public int QualityId { get; set; }
        public QualityModel QualityModel { get; set; }
    }
}
