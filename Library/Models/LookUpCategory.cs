using System.Linq;

namespace Library.Models
{
    public class LookUpCategory
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public List<LookUp>? LookUps { get; set; }
    }
}
