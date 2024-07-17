using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
<<<<<<< HEAD
=======
using ADStarter.Models;
>>>>>>> Student
using Microsoft.EntityFrameworkCore.Storage;

namespace ADStarter.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ICourseRepository Course { get; private set; }
<<<<<<< HEAD
        public IStudentRepository Students { get; private set; }
        public IProposalRepository Proposals { get; private set; }
=======
        public IStudentRepository Student { get; private set; }
        public IProposalRepository Proposal { get; private set; }
>>>>>>> Student

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Course = new CourseRepository(_db);
<<<<<<< HEAD
            Students = new StudentRepository(_db);
            Proposals = new ProposalRepository(_db);
=======
            Student = new StudentRepository(_db);
            Proposal = new ProposalRepository(_db);
>>>>>>> Student
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
