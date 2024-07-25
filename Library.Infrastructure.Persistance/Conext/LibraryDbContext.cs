using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext:IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext>options):base(options) 
        {
            
        }

       
        public DbSet<Shelf> shelves { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<LookUp> lookUp { get; set; }
        public DbSet<LookUpCategory> lookUpCategory { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach(var ForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(O => O.GetForeignKeys()))
            {
                ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<LookUpCategory>().HasData(

                new LookUpCategory { Id = 1, Name = "TypeOfShelf", Code = 1, CreateAt = DateTime.UtcNow }
            );


            modelBuilder.Entity<LookUp>().HasData(
                  new LookUp { Id = 1, LookUpCategoryId = 1, Name = "Drama", ArabicName = "دراما",FrenchName= "drame", CreateAt = DateTime.UtcNow },
                  new LookUp { Id = 2, LookUpCategoryId = 1, Name = "business",ArabicName= "أعمال",FrenchName= "entreprise", CreateAt = DateTime.UtcNow },
                  new LookUp { Id = 3, LookUpCategoryId = 1, Name = "Science fiction", ArabicName= "خيال علمي",FrenchName= "la science-fiction", CreateAt = DateTime.UtcNow },
                  new LookUp { Id = 4, LookUpCategoryId = 1, Name = "Fantasy",ArabicName= "فانتازي",FrenchName= "Fantaisie", CreateAt = DateTime.UtcNow },
                  new LookUp { Id = 5, LookUpCategoryId = 1, Name = "Thriller",ArabicName= "تشويق",FrenchName= "le film à suspense", CreateAt = DateTime.UtcNow },
                  new LookUp { Id = 6, LookUpCategoryId = 1, Name = "Mystery",ArabicName= "غموض",FrenchName= "Mystère", CreateAt = DateTime.UtcNow }
            );

        }


    }
}
