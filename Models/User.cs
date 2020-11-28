using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTeste.Models
{
    public class User : BaseModel
    {
        public string Login { get; set; }

        public string password { get; set; }

        public string Role { get; set; }
    }
}
