using ProyectoEstructura.Entities.POCOEntities;
using ProyectoEstructura.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification);
    }
}
