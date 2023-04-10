using _153504_Pryhozhy.Domain.Abstractions;
using _153504_Pryhozhy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153504_Pryhozhy.Persistense.Repository
{
    public class FakeEmployeePositionRepository : IRepository<EmployeePosition>
    {

        List<EmployeePosition> _employeePositions;
        public FakeEmployeePositionRepository()
        {
            _employeePositions = new List<EmployeePosition>() {
                new EmployeePosition() { Id=1, Name= "Consultant", Salary=1000, JobDuties=new List<JobDuty>()},
            new EmployeePosition() { Id = 1, Name = "Waiter", Salary = 1500, JobDuties = new List<JobDuty>() } };
        }
        public Task AddAsync(EmployeePosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EmployeePosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeePosition> FirstOrDefaultAsync(Expression<Func<EmployeePosition, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeePosition> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<EmployeePosition, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<EmployeePosition>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _employeePositions);
        }

        public Task<IReadOnlyList<EmployeePosition>> ListAsync(Expression<Func<EmployeePosition, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<EmployeePosition, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EmployeePosition entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
