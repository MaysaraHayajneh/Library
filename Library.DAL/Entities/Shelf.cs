using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Library.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Name In English")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name In Arabic")]
        public string ArabicName {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name In French")]
        public string FrenchName { get; set; }
        [Display(Name ="Mark as active")]
        public bool IsAvalible { get; set; }
        public int BookCount { get; set; }
    }
}
