using System.ComponentModel.DataAnnotations;

namespace RLIM.UserInterface.Models
{
    public class QualityModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to give it a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to give it a Rank.")]
        public int Rank { get; set; }

        public string Display { get; set; }
    }
}
