using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.DataAccess;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductData ProductData;
        private readonly IPictureHandler PictureHandler;
        public ProductController()
        {
            ProductData = new ProductFromDb();
            PictureHandler = new PictureHanldler();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel productModel,  HttpPostedFileBase fileUpload)

        {
            Stream stream = null;
            var fileName = "";
            var fullPictureName = "";
          
            
            string PictureNamePrefix = Guid.NewGuid().ToString();
            fileName = Path.GetFileName(fileUpload.FileName);
            fullPictureName = PictureNamePrefix + "_" + fileName;
            productModel.ImageLocation = fullPictureName;

            stream = fileUpload.InputStream;
            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);

             
            ProductData.CreateProduct(productModel);
            PictureHandler.SavePictureInFile(fileBinary, fullPictureName);

            return View();
        }

    }
}