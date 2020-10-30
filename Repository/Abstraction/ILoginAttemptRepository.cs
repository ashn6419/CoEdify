using DomainModels.Entities;
using System.Collections.Generic;

namespace Repository.Abstraction
{
    public interface ILoginAttemptRepository : IRepository<LoginAttempt>  
    {
        IEnumerable<LoginAttempt> GetAll();

        LoginAttempt GetLoginHisoryById(int Id); 

        int AddLoginAttempt(LoginAttempt loginAttempt);  
    }
}
