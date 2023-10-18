using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public string Id { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^\d+")]
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}
