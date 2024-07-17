<<<<<<< HEAD
using ADStarter.Models;
=======
﻿using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> Student

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
<<<<<<< HEAD
        void Update(Student student);

        Task<Student> GetByIdAsync(string id);
=======
        void Update(Student obj);
>>>>>>> Student
    }
}
