using DatabaseModel;
using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Services.InterFaces
{
    public class ProductService : IProductService
    {

        public List<ProductViewModel> GetProducts(int userId)
        {
            using (var context = new KebapBobEntities())
            {
                return context.Product
                    .Where(z => z.UserID == userId).Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        ItemName = x.Name,
                        itemDescription = x.Description
                    }).ToList();
            }
        }

        public List<ProductViewModel> ReturnProductName(int userId)
        {
            using (var context = new KebapBobEntities())
            {
                return context.Product
                    .Where(s => s.UserID == userId)
                    .Select(x => new ProductViewModel
                    {
                        ItemName = x.Name,

                    }).ToList();
            }
        }

        public void UpdateProduct(ProductViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {
                var product = context.Product.FirstOrDefault(x => x.Id == vm.Id);
                if (product == null)
                {
                    throw new Exception("Product couldn't found");
                }
                product.Name = vm.ItemName;
                product.Description = vm.itemDescription;

                context.SaveChanges();
            }
        }

        public void CreateProduct(ProductViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {
                var newProduct = new Product
                {
                    Name = vm.ItemName,
                    Description = vm.itemDescription,
                    UserID = vm.UserId
                };

                context.Product.Add(newProduct);
                context.SaveChanges();
            }
        }


        public void DeleteProduct(ProductViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {
                var deleteProduct = context.Product

                    .FirstOrDefault(x => x.Id == vm.Id);

                if (deleteProduct == null)
                {
                    throw new Exception("Product couldn't found");
                }

                deleteProduct.Id = vm.Id;
                deleteProduct.Name = vm.ItemName;
                deleteProduct.Description = vm.itemDescription;

                context.Product.Remove(deleteProduct);
                context.SaveChanges();

            }
        }


    }
}
