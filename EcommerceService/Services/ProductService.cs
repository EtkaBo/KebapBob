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

        public List<ProductViewModel> GetProducts()
        {
            using (var context = new KebapBobEntities())
            {
                return context.Product.Select(x => new ProductViewModel
                {
                    ItemName = x.Name,
                    itemDescription = x.Description

                }).ToList();
            }
        }

        public void UpdateProduct(ProductViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {
                var updatedProduct = context.Product.FirstOrDefault(x => x.Id == vm.Id);
                if (updatedProduct == null)
                {
                    throw new Exception("Product couldn't found");
                }
                updatedProduct.Name = vm.ItemName;
                updatedProduct.Description = vm.itemDescription;

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
                    Description = vm.itemDescription
                };

                context.Product.Add(newProduct);
                context.SaveChanges();
            }
        }


        public void DeleteProduct(ProductViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {
                var deleteProduct = context.Product.FirstOrDefault(x => x.Id == vm.Id);

                if(deleteProduct == null)
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
