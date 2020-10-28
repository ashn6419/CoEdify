using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface ITaskRepository : IRepository<Tasks>
    {
        IEnumerable<Tasks> GetAll();
        Tasks GetById(int id);
        int Add(Tasks task);
        int Update(Tasks task);
        int Delete(int id);
    }
}
