using ProyectoEstructura.Entities.Interfaces;
using ProyectoEstructura.Entities.POCOEntities;
using ProyectoEstructura.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly ProyectoEstructuraContext Context;
        public OrderDetailRepository(ProyectoEstructuraContext context) =>
            Context = context;

        public void Create(OrderDetail orderDetail)
        {
            Context.Add(orderDetail);
        }
    }
}
