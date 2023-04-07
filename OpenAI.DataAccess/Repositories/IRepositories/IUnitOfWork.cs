using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
