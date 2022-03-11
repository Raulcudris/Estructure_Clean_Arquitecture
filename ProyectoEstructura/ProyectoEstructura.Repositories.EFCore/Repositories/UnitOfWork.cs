using ProyectoEstructura.Entities.Interfaces;
using ProyectoEstructura.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ProyectoEstructuraContext Context;
        public UnitOfWork(ProyectoEstructuraContext context) =>
            Context = context;
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
