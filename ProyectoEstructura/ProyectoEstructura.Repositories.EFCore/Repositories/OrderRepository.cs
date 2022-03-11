using ProyectoEstructura.Entities.Interfaces;
using ProyectoEstructura.Entities.POCOEntities;
using ProyectoEstructura.Entities.Specifications;
using ProyectoEstructura.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly ProyectoEstructuraContext Context;
        public OrderRepository(ProyectoEstructuraContext context) =>
            Context = context;

        public void Create(Order order)
        {
            Context.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDelegate);
        }
    }
}
