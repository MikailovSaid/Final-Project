using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.ViewModels.Account
{
    public class ChangePasswordVM
    {
        [Required, MaxLength(16), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(16), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
