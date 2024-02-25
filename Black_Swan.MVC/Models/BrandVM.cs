using System.ComponentModel.DataAnnotations;

namespace Black_Swan.MVC.Models
{
    public class BrandVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
