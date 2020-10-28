using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using Repository.Implementation;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration configuration;
        public UnitOfWork(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        private ILoginRepository _loginRepo;
        public ILoginRepository loginRepo
        {
            get
            {
                if (_loginRepo == null)
                    _loginRepo = new LoginRepository(configuration);

                return _loginRepo;
            }
        }

        private IQualificationRepository _qualificationRepo;
        public IQualificationRepository qualificationRepo
        {
            get
            {
                if (_qualificationRepo == null)
                    _qualificationRepo = new QualificationRepository(configuration);

                return _qualificationRepo;
            }
        }

        private IRoleRepository _roleRepo;
        public IRoleRepository roleRepo
        {
            get
            {
                if (_roleRepo == null)
                    _roleRepo = new RoleRepository(configuration);

                return _roleRepo;
            }
        }

        private IUserRepository _userRepo;
        public IUserRepository userRepo
        {
            get
            {
                if (_userRepo == null)
                    _userRepo = new UserRepository(configuration);

                return _userRepo;
            }
        }

        private ILoginHistoryRepository _loginHistoryRepo;
        public ILoginHistoryRepository LoginHistoryRepo
        {
            get
            {
                if (_loginHistoryRepo == null)
                    _loginHistoryRepo = new LoginHistoryRepository(configuration);

                return _loginHistoryRepo;
            }
        }

        private ITaskRepository _taskRepo;
        public ITaskRepository TaskRepo
        {
            get
            {
                if (_taskRepo == null)
                    _taskRepo = new TaskRepository(configuration);
                return _taskRepo;
            }
        }
        private ITaskItemRepository _taskItemRepo;
        public ITaskItemRepository TaskItemRepo
        {
            get
            {
                if (_taskItemRepo == null)
                    _taskItemRepo = new TaskItemRepository(configuration);
                return _taskItemRepo;
            }
        }
    }
}
