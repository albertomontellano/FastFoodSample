using System.ComponentModel.DataAnnotations;
using FastFoodWebApplication.EnumsAndConstants;

namespace FastFoodWebApplication.Models
{
    public class ProductModel
    {
        [Display(Name = "Nombre del Producto :")]
        [Required(ErrorMessage = "El nombre de producto es requerido.")]
        [StringLength(40, ErrorMessage = "Tamanio maximo 40 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
     
        public string Name { get; set; }

        [Display(Name = "Descripcion :")]
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [StringLength(40, ErrorMessage = "Tamanio maximo 40 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string Description { get; set; }
     
        [Display(Name = "Precio :")]
        [Required(ErrorMessage = "El precio es requerido.")]
        [StringLength(40, ErrorMessage = "Tamanio maximo 40 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public decimal Price { get; set; }

        [Display(Name = "Imagen del producto :")]
        [StringLength(300, ErrorMessage = "Tamanio maximo 300 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string ImageLocation { get; set; }
        
    }
}