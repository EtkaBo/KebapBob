using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Services.InterFaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts(int userId);
        void UpdateProduct(ProductViewModel vm);
        void CreateProduct(ProductViewModel vm);
        void DeleteProduct(ProductViewModel vm);
    }
}
