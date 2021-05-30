using System;

namespace Glomil.MVC.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string PasswordCheck { get; set; }
    }
}
