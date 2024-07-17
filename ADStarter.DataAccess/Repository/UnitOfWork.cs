using ADStarter.DataAccess.Data;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public ICourseRepository Course { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IProposalRepository Proposal { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Course = new CourseRepository(_db);
            Student = new StudentRepository(_db);
            Proposal = new ProposalRepository(_db);
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