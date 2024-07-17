using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDBContext _db;
        public StudentRepository(ApplicationDBContext db) : base(db) 
        { 
            _db = db;
        }
        public void Update(Student obj)
        {
            _db.Students.Update(obj);
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _db.Students.FindAsync(id);
        }

    }
}
