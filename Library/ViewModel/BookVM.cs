using Library.DAL.DTO;
using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.PresentationLayer.ViewModel
{
    public class BookVM
    {
        public Book? Book { get; set; }
        public List<SelectList>? shelves { get; set; }
    }
}
