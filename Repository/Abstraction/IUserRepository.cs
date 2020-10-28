using DomainModels.Entities;
using DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
        PagingModel<User> GetAllUsers(int page, int pageSize, string sort, string sortDir);

        User GetUserById(int Id);

        User AddUser(User user);
        int UpdateUser(User user);

        int DeleteUser(int Id);

    }
}
