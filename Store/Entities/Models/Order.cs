using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine> Lines { get; set; }=new List<CartLine>();
        [Required(ErrorMessage ="Name field is required")]
        public String? Name { get; set; }
        [Required(ErrorMessage ="Line1 field is required")]
        public String? Line1 { get; set; }
        [Required(ErrorMessage ="Line2 field is required")]
        public String? Line2 { get; set; }
        [Required(ErrorMessage ="Line3 field is required")]
        public String? Line3 { get; set; }
        [Required(ErrorMessage ="City field is required")]
        public String? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; }
        public Order()
        {
            OrderedAt=DateTime.Now;
        }
    }
}