using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Services
{
   public interface IOrderService
    {
        List<OrderViewModel> GetOrders();
        void UpdateOrder(OrderViewModel vm);
        string CreateOrder(OrderViewModel vm);
        void DeleteOrder(OrderViewModel vm);

    }
}
