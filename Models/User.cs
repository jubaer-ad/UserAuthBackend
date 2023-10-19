using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters.")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^\d+", ErrorMessage = "Mobile number must be a number")]
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] HashedSalt { get; set; }
    }
}
