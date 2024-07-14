using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;

namespace ADStarter.DataAccess.Repository
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        private readonly ApplicationDBContext _db;

        public ProposalRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Proposal proposal)
        {
            _db.Proposals.Update(proposal);
        }
    }
}
