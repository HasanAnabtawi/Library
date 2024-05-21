using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class BookModel
    {


        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation property for the category related to this Book
        public virtual CategoryModel Category{ get; set; }
        
        public string? ISBN { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly PublicationDate { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        

    }
}
