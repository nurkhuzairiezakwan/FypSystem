<<<<<<< HEAD
using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
=======
﻿using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
>>>>>>> Student

namespace ADStarter.DataAccess.Repository
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
<<<<<<< HEAD
        private readonly ApplicationDBContext _db;

=======
        private ApplicationDBContext _db;
>>>>>>> Student
        public ProposalRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
<<<<<<< HEAD

        public void Update(Proposal proposal)
        {
            _db.Proposals.Update(proposal);
        }
=======
        public void Update(Proposal obj)
        {
            _db.Proposals.Update(obj);
        }

>>>>>>> Student
    }
}
