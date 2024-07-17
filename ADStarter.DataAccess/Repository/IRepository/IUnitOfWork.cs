using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
<<<<<<< HEAD
        IStudentRepository Students { get; }
        IProposalRepository Proposals { get; }
=======
        IStudentRepository Student { get; }
        IProposalRepository Proposal { get; }

>>>>>>> Student
        void Save();
        IDbContextTransaction BeginTransaction();
    }
}
