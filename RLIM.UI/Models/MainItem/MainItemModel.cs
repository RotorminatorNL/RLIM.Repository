using System.ComponentModel.DataAnnotations;

namespace RLIM.UI.Models
{
    public class MainItemModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Platform { get; set; }
        public string Quality { get; set; }
    }
}
