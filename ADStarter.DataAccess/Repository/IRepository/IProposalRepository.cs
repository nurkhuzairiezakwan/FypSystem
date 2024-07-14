using ADStarter.Models;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        void Update(Proposal proposal);
    }
}
