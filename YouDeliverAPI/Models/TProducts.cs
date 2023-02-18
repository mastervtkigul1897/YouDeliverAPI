using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouDeliverAPI.Models
{
    public class TProducts
    {
        [Key]
        public int ProductId { get; set; }

        public virtual int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual TBusiness? Business { get; set; }

        public string? ProductName { get; set; }
        
        public string? Image { get; set; }

        public int? Price { get; set; }

        public string? ProductDescription { get; set; }

        public int? Stock { get; set; }

    }
}
