using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.ViewModels.Account
{
    public class LoginVM
    {
        [Required, MaxLength(255)]
        public string Login { get; set; }
        [Required, DataType(DataType.Password), MaxLength(16)]
        public string Password { get; set; }
    }
}
