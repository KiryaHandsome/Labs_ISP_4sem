using _153504_Pryhozhy.Domain.Abstractions;
using _153504_Pryhozhy.Domain.Entities;
using System.Linq.Expressions;

namespace _153504_Pryhozhy.Persistense.Repository
{
    public class FakeJobDutyRepository : IRepository<JobDuty>
    {

        List<JobDuty> _list = new List<JobDuty>();
        public FakeJobDutyRepository()
        {
            Random rand = new Random();
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                    _list.Add(new JobDuty()
                    {
                        Id = k,
                        Name = $"Duty {k++}",
                        Description = $"Description {i}.{j}",
                        Experience = i,
                        DutyImportance = j,
                    });
        }
        public Task AddAsync(JobDuty entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(JobDuty entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<JobDuty> FirstOrDefaultAsync(Expression<Func<JobDuty, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<JobDuty> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<JobDuty, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<JobDuty>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<JobDuty>> ListAsync(Expression<Func<JobDuty, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<JobDuty, object>>[] includesProperties)
        {
            return await Task.Run(() => _list.AsQueryable().Where(filter).ToList());
        }

        public Task UpdateAsync(JobDuty entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
