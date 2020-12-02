using Clip2020Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clip2020Api.Repositories
{
    interface IUserCollection
    {
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(string id);

    Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
    }
}
