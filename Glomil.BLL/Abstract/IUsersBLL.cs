using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Abstract
{
    public interface IUsersBLL
    {
        public Users UserLogin(string nickName, string password);
        public void AddUser(Users user);

        public Users GetUserbyID(int id);
    }
}
