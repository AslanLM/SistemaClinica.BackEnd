using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
