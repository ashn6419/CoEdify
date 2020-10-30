using Repository.Abstraction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IUnitOfWork
    {
        ILoginRepository loginRepo { get; }
        IQualificationRepository qualificationRepo { get; }
        IRoleRepository roleRepo { get; }
        IUserRepository userRepo { get; }
        ILoginAttemptRepository LoginAttemptRepo { get; } 
        ITaskRepository TaskRepo { get; }
        ITaskItemRepository TaskItemRepo { get; }
    }
}
