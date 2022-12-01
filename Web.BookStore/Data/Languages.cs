using System.ComponentModel.DataAnnotations.Schema;

namespace Web.BookStore.Data
{
    public class Languages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
