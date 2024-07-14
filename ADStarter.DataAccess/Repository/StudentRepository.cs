using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;

namespace ADStarter.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDBContext _db;

        public StudentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _db.Students.FindAsync(id);
        }
    }
}
