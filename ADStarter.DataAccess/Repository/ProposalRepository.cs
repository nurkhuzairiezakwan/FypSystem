using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        private ApplicationDBContext _db;
        public ProposalRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Proposal obj)
        {
            _db.Proposals.Update(obj);
        }

    }
}
