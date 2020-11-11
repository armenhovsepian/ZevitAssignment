using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(18)]
        public string ZipCode { get; set; }

        [StringLength(180)]
        public string Street { get; set; }

        [StringLength(60)]
        public string State { get; set; }

        [StringLength(90)]
        public string Country { get; set; }

        [StringLength(100)]
        public string City { get; set; }

    }
}
