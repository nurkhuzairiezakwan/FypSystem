using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
        IProposalRepository Proposal { get; }

        void Save();
        IDbContextTransaction BeginTransaction();
    }
}