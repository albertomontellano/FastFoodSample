using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.DataAccess
{
    public interface IProductData
    {
        void CreateProduct(ProductModel productModel);

        void DeleteProduct(int ProductId);

        void EditProduct(int productId);
    }
}