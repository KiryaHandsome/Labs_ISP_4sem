using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_Pryhozhy.Domain.Entities
{
    public class EmployeePosition : Entity
    {
        public double Salary { get; set; }
        public List<JobDuty> JobDuties { get; set; }
    }
}
