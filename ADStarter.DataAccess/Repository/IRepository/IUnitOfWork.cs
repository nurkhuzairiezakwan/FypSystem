using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }
        IProposalRepository Proposal { get; }

        void Save();
        IDbContextTransaction BeginTransaction();
    }
}
