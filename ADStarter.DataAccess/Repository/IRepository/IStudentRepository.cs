using ADStarter.Models;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);

        Task<Student> GetByIdAsync(string id);
    }
}
