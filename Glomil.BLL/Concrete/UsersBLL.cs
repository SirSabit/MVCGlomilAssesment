using Glomil.BLL.Abstract;
using Glomil.DAL.Repositories.Abstract;
using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Concrete
{
   public class UsersBLL:IUsersBLL
    {
        private IUsersDal usersDal;
        public UsersBLL(IUsersDal usersDal)
        {
            this.usersDal = usersDal;
        }

        public List<Users> GetUser(string nickName,string password)
        {
            var user = usersDal.Get(x => x.NickName == nickName && x.Password == password);

            return user;            
        }

        public void AddUser(Users user)
        {
            usersDal.Add(user);            
        }
    }
}
