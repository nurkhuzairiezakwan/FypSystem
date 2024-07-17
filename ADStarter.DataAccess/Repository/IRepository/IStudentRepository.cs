using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetByIdAsync(int id);
        void Update(Student obj);
    }
}
