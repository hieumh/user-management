using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Domains.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birth { get; set; }

        [Column("Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Column("Password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string? Password { get; set; }
    }
}