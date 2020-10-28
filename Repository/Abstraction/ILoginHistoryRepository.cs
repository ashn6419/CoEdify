using DomainModels.Entities;
using System.Collections.Generic;

namespace Repository.Abstraction
{
    public interface ILoginHistoryRepository : IRepository<LoginHistory> 
    {
        IEnumerable<LoginHistory> GetAll();

        LoginHistory GetLoginHisoryById(int Id); 

        int AddLoginHistory(LoginHistory loginHistory);
    }
}
