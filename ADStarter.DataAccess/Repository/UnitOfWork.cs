using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace ADStarter.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ICourseRepository Course { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IProposalRepository Proposals { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Course = new CourseRepository(_db);
            Students = new StudentRepository(_db);
            Proposals = new ProposalRepository(_db);
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
