using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpectrumCC.Interfaces;
using SpectrumCC.Users;
using SQLite.Net;

namespace SpectrumCC
{
    public class SQLiteUserStore : IUser
    {
        private SQLiteConnection _connection;
        public SQLiteUserStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTable<User>();
        }

        public void AddUser(User user)
        {
            _connection.Insert(user);
        }

        public User GetUser(int id)
        {
            return _connection.Find<User>(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return  _connection.Table<User>().ToList();
        }

        public bool IsUserExist(string userName, string password)
        {
            var isUserExists = _connection.Table<User>().Any(x => x.UserName == userName && x.Password == password);
            return isUserExists;
        }
    }
}
