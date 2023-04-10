using _153504_Pryhozhy.Domain.Entities;

namespace _153504_Pryhozhy.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<EmployeePosition> EmployeePositionRepository { get; }
        IRepository<JobDuty> JobDutyRepository { get; }
        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
