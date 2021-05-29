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
        public List<Users> getUser(string nickName, string password);
    }
}
