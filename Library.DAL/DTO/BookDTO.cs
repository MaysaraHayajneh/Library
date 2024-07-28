using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DTO
{
    public class BookDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name In English")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name In Arabic")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name In French")]
        public string FrenchName { get; set; }

        [Required(ErrorMessage = "please upload your image")]
        [Display(Name = "Upload Image")]
        [NotMapped]
        public IFormFile ImgFormFile { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "the Author")]
        public string Author { get; set; }

        [Range(0.01, 1000, ErrorMessage = "the number must be between 0.01 -1000")]
        [Display(Name = "Price")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "please upload your pdf")]
        [Display(Name = "Upload pdfFile")]
        [NotMapped]
        public IFormFile pdfFormFile { get; set; }
        public byte[]? pdfContent { get; set; }
        public string? pdfFileName { get; set; }

        [ForeignKey("shelf")]
        public int ShelfId { get; set; }
        [ValidateNever]
        [Display(Name = "Shelfs")]
        public Shelf shelf { get; set; }
    }
}
