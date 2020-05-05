using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.UI40Smart.MVC.Day02.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public double Salary { get; set; }

        [MaxLength(256)]
        [Required]
        public string Address { get; set; }

        [Required]
        public Gender Gender { get; set; }

    }
}