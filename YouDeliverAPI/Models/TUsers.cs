using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YouDeliverAPI.Models
{
    public class TUsers
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? AccountType { get; set; }

        public int? IsVerified { get; set; }

        public int? IsActive { get; set; }

        public int? IsSuspended { get; set; }

        public int? IsVip { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
