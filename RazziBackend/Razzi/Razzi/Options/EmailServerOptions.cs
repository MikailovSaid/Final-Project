using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Options
{
    public class EmailServerOptions
    {

        public const string  EmailServer = "EmailServer";

        public string Name { get; set; } = default;

        public string Email { get; set; } = default;

        public string Password { get; set; } = default;
    }
}
