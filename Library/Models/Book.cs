using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Name In English")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name="Name In Arabic")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Name In French")]
        public string FrenchName { get; set; }

        [Required(ErrorMessage ="please upload your image")]
        [Display(Name= "Upload Image")] 
        [NotMapped]
        public IFormFile ImgFormFile { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name="the Author")]
        public string Author { get; set; }

        [Range(0.01, 1000, ErrorMessage = "the number must be between 0.01 -1000")]
        [Display(Name="Price")]
        public decimal price { get; set; }
        [Required(ErrorMessage ="please upload your pdf")]
        [Display(Name = "Upload pdfFile")]
        [NotMapped]
        public IFormFile pdfFormFile { get; set; }
        public byte[]? pdfContent { get; set; }
        public string? pdfFileName { get; set; }

        [ForeignKey("shelf")]
        public int ShelfId { get; set; }
        [ValidateNever]
        [Display(Name ="Shelfs")]
        public Shelf shelf { get; set; }
    }
}
