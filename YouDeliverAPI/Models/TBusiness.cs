using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouDeliverAPI.Models
{
    public class TBusiness
    {
        [Key]
        public int BusinessId { get; set; }

        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TUsers? Users { get; set; }
        public string? BusinessName { get; set; }   
        public string? BusinessPhone { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessCity { get; set; }
        public string? BusinessBarangay { get; set; }
        public DateTime DateRegistered { get; set; }


    }
}
    