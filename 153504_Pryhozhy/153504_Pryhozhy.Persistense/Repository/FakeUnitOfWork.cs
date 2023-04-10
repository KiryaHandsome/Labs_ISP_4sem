using _153504_Pryhozhy.Domain.Abstractions;
using _153504_Pryhozhy.Domain.Entities;
using _153504_Pryhozhy.Persistense.Data;

namespace _153504_Pryhozhy.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<EmployeePosition>> _employeePositionRepository;
        private readonly Lazy<IRepository<JobDuty>> _jobDutyRepository;

        public FakeUnitOfWork(AppDbContext context)
        {
            _context = context;
            _employeePositionRepository = new Lazy<IRepository<EmployeePosition>>(() => new FakeEmployeePositionRepository());
            _jobDutyRepository = new Lazy<IRepository<JobDuty>>(() => new FakeJobDutyRepository());
        }

        public IRepository<EmployeePosition> EmployeePositionRepository => _employeePositionRepository.Value;

        public IRepository<JobDuty> JobDutyRepository => _jobDutyRepository.Value;
        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
