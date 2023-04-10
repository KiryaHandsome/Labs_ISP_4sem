using _153504_Pryhozhy.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_Pryhozhy.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<EmployeePosition>> _employeePositionRepository;
        private readonly Lazy<IRepository<JobDuty>> _jobDutyRepository;
        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _employeePositionRepository = new Lazy<IRepository<EmployeePosition>>(() =>
            new EfRepository<EmployeePosition>(context));
            _jobDutyRepository = new Lazy<IRepository<JobDuty>>(() =>
            new EfRepository<JobDuty>(context));
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
