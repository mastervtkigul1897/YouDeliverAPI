using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouDeliverAPI.Models
{
    public class TDelivery
    {
        [Key]
        public int DeliveryId { get; set; }

        public virtual int DUserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TUsers? Users { get; set; }

        public virtual int ReferenceId { get; set; }
        [ForeignKey("ReferenceId")]
        public virtual TPurchase? Purchase { get; set; }

        public string? Status { get; set; }

        public DateTime DateAccepted { get; set; }


    }
}
