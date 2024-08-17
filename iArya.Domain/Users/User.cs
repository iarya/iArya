using iArya.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.Domain.Users
{
    public class User : Base
    {
        [Key]
        public int UserId { get; set; }


        public int RoleId { get; set; }


        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }


        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MaxLength(400)]
        public string Password { get; set; }


        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
