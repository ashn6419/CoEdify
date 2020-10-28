using DomainModels.Entities;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Repository.Abstraction
{
    public interface ILoginRepository : IRepository<UserLogin>
    {
        IEnumerable<UserLogin> GetAll();

        UserLogin GetUserLoginById(int Id);
        UserLogin GetUserLogin(string Useremail); 

        int AddUser(UserLogin userLogin);
        int UpdateUserPassword(UserLogin user);

        int DeleteUser(int Id);

        UserLogin DoLogin(UserLogin user);

    }
}
