
using System.ComponentModel.DataAnnotations;
using FastFoodWebApplication.EnumsAndConstants;

namespace FastFoodWebApplication.Models
{
    public class PersonModel
    {
        [Display(Name = "Nombre Completo :")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(40, ErrorMessage = "Tamanio maximo 40 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string Name {get;set;}

        [Display(Name = "NIT :")]
        [Required(ErrorMessage = "El NIT es requerido.")]
        [StringLength(20, ErrorMessage = "Tamanio maximo 20 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string Nit { get; set; }

        [Display(Name = "Direccion :")]
        [Required(ErrorMessage = "La direccion es requerida.")]
        [StringLength(80, ErrorMessage = "Tamanio maximo 80 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string Address { get; set; }

        [Display(Name = "Telefono fijo o celular :")]
        [Required(ErrorMessage = "El telefono es requerido.")]
        [StringLength(20, ErrorMessage = "Tamanio maximo 20 caracteres.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string PhoneNumber { get; set; }


        [Display(Name = "Latitude :")]
        [Required(ErrorMessage = "Latitud es requerida.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string AddressLatitude { get; set; }

        [Display(Name = "Longitud :")]
        [Required(ErrorMessage = "Longitud es requerido.")]
        [RegularExpression(FastFoodConstants.HtmlNotAllowedRegex, ErrorMessage = FastFoodConstants.HtmlTagsNotAllowed)]
        public string AddressLongitude {get;set;}
    }
}