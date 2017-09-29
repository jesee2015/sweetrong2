using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Domain
{
    public class Product
    {
        [Key]
        public Guid PId { get; set; }
        [Required]
        public string PName { get; set; }
        [StringLength(32)]
        public string PDesc { get; set; }
        public decimal PPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
