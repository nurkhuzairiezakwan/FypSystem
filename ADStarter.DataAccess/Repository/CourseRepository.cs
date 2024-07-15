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
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDBContext _db;
        public CourseRepository(ApplicationDBContext db) : base(db) 
        { 
            _db = db;
        }
        public void Update(Course obj)
        {
            _db.Courses.Update(obj);
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _db.Courses.FindAsync(id);
        }

    }
}
