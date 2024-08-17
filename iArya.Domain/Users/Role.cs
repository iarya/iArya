using iArya.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iArya.Domain.Users
{
    public class Role: Base
    {
        [Key]
        public  int  RoleId { get; set; }

        [Required]
        [MaxLength(250)]
        public string RoleName { get; set; }

        [Required]
        [MaxLength(350)]
        public string RoleTitle { get; set; }


        public List<User>? Users { get; set; }

    }
}
