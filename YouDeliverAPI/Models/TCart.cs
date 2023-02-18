using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouDeliverAPI.Models
{
    public class TCart
    {
        [Key]
        public int CartId { get; set; }

        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TUsers? Users { get; set; }

        public virtual int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual TBusiness? Business { get; set; }

        public virtual int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual TProducts? Products { get; set; }

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }


    }
}
