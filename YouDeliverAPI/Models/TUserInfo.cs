using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouDeliverAPI.Models
{
    public class TUserInfo
    {
        [Key]
        public int Id { get; set; }

        public virtual int userId { get; set; }
        [ForeignKey("userId")]
        public virtual TUsers? Users { get; set; }

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Barangay { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Avatar { get; set; }
    }
}
