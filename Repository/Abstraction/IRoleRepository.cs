using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface IRoleRepository : IRepository<Role> 
    {
        IEnumerable<Role> GetAll();

        Role GetRoleById(int Id); 
      
        int AddRole(Role role); 
        int UpdateRole(Role role); 

        int DeleteRole(int Id); 
    }
}
