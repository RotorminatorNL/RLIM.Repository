using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class PlatformModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }
    }
}
