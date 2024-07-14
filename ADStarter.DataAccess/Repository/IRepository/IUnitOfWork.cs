using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
        IStudentRepository Students { get; }
        IProposalRepository Proposals { get; }
        void Save();
        IDbContextTransaction BeginTransaction();
    }
}
