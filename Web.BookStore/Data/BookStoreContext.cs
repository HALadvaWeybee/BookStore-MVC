using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Web.BookStore.Data
{
    public class BookStoreContext: DbContext
    {
         public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
         {
             
         }
         public DbSet<Books> Books {get; set;}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=DESKTOP-VUSIS3U\\MSSQLSERVER01;Database=BookStoreMVC;trusted_connection=true;encrypt=false");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}
