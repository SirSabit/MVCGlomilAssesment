using Glomil.Entities.Entities;

namespace Glomil.BLL.Abstract
{
    public interface IUsersBLL
    {
        public Users UserLogin(string nickName, string password);
        public void AddUser(Users user);

        public Users GetUserbyID(int id);
    }
}
