<<<<<<< HEAD
using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
=======
﻿using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
>>>>>>> Student

namespace ADStarter.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
<<<<<<< HEAD
        private readonly ApplicationDBContext _db;

=======
        private ApplicationDBContext _db;
>>>>>>> Student
        public StudentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
<<<<<<< HEAD

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _db.Students.FindAsync(id);
        }
=======
        public void Update(Student obj)
        {
            _db.Students.Update(obj);
        }

>>>>>>> Student
    }
}
