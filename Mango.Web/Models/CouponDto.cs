using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Range(1, 50)]
        public double DiscountAmount { get; set; }
        [Required]
        public int MinAmount { get; set; }

    }
}
