using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpectrumCC.Users;

namespace SpectrumCC.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        bool IsUserExist(string userName, string password);
    }
}
