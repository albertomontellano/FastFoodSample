using System;
using FastFoodWebApplication.Models;
namespace FastFoodWebApplication.DataAccess
{
    public class ProductFromDb: IProductData
    {
        private readonly FastFoodDbEntities FastFoodDbEntitiesInstance;
         public ProductFromDb()
        {
            FastFoodDbEntitiesInstance = new FastFoodDbEntities();
        }
         public void CreateProduct(ProductModel productModel)
         {

             var product = new Product();
             product.Name = productModel.Name;
             product.Description = productModel.Description;
             product.Price = productModel.Price;
             product.ImageLocation = productModel.ImageLocation;
             product.CreatedDate = DateTime.UtcNow;

             FastFoodDbEntitiesInstance.Products.Add(product);
             FastFoodDbEntitiesInstance.SaveChanges();

             //Save image in folder

         }


         public void DeleteProduct(int personId)
         {
             throw new NotImplementedException();
         }

         public void EditProduct(int personId)
         {
             throw new NotImplementedException();
         }
    }
}