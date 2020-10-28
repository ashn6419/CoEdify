using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface ITaskItemRepository :IRepository<TaskItem>
    {
        IEnumerable<TaskItem> GetAll();

        IEnumerable<TaskItem> GetAllByTaskId(int TaskId); 
        TaskItem GetById(int id);
        int Add(TaskItem task);
        int Update(TaskItem task);
        int Delete(int id);
    }
}
