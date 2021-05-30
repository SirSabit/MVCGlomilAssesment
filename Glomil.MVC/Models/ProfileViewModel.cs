using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glomil.MVC.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
