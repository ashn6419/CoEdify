using DomainModels.Entities;
using DomainModels.ViewModels;
using System.Collections.Generic;

namespace Repository.Abstraction
{
    public interface ILoginRepository : IRepository<UserLogin>
    {
        IEnumerable<UserLoginModel> GetAll();

        UserLoginModel GetUserLoginById(int Id);
        UserLoginModel GetUserLogin(string Useremail);

        int AddUser(UserLogin userLogin);
        int UpdateUserPassword(UserLogin user);

        int DeleteUser(int Id);

        UserLoginModel DoLogin(UserLogin user);

    }
}
