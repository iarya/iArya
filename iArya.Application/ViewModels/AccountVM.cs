using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.Application.ViewModels
{
  public class RegisterVM
    {
        
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }


        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MaxLength(30)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }


    public class LoginVM
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        public bool RememberMe{ get; set; }


    }


}
