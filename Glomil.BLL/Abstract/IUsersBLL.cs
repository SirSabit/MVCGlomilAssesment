using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Abstract
{
    public interface IUsersBLL
    {
        public List<Users> GetUser(string nickName, string password);
        public void AddUser(Users user);
    }
}
