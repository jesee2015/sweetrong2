using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Domain
{
    public class User
    {
        [Key]
        public Guid UId { get; set; }
        [Required]
        public string UName { get; set; }
        [StringLength(32)]
        public string UPwd { get; set; }
        public string UAddress { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
