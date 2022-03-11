using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Repositories.EFCore.DataContext
{
    class ProyectoEstructuraContextFactory : IDesignTimeDbContextFactory<ProyectoEstructuraContext>
    {
        public ProyectoEstructuraContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                 new DbContextOptionsBuilder<ProyectoEstructuraContext>();
            OptionBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb; database=PruebaCleanArchitectureDb");
            return new ProyectoEstructuraContext(OptionBuilder.Options);

        }
    }
}
