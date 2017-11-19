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
        List<OrderViewModel> GetOrders(int userId);
        void UpdateOrder(OrderViewModel vm);
        void CreateOrder(OrderViewModel vm);
        void DeleteOrder(OrderViewModel vm);
    }
}
