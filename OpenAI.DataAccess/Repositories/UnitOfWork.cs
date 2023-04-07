
using Enoca.DataAccess.Repositories.IRepositories;
using OpenAI.DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OAContext _db;

        public UnitOfWork(OAContext db)
        {
            _db = db;
          
        }

       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
