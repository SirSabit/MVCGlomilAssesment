using Glomil.BLL.Abstract;
using Glomil.DAL.Repositories.Abstract;
using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Concrete
{
    public class UsersBLL : IUsersBLL
    {
        private IUsersDal usersDal;
        public UsersBLL(IUsersDal usersDal)
        {
            this.usersDal = usersDal;
        }

        public Users UserLogin(string nickName,string password)
        {
            var user = usersDal.GetBy(x => x.NickName == nickName && x.Password == password);

            return user;            
        }

        public void AddUser(Users user)
        {
            usersDal.Add(user);            
        }
      

       public Users GetUserbyID(int id)
        {
            return usersDal.GetBy(x => x.Id == id);
        }
       
    }
}
