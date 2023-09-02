using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Srv.Cliente.Domain.Models
{
    public class ValidateSessionModel
    {
        public bool Success { get; set; }
        public string? RefreshToken { get; set; }
        public string? DataExpiracao { get; set; }
    }
}
