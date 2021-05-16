using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TeamFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

    }
}
