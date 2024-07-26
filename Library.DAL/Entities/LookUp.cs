using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class LookUp
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string FrenchName { get; set; }
        public string? Description { get; set; }
        public LookUpCategory LookUpCategory { get; set; }

        [ForeignKey("LookUpCategory")]
        public int LookUpCategoryId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
