using Glomil.BLL.Abstract;
using Glomil.DAL.Repositories.Abstract;
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
    }
}
