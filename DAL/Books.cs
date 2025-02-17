using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Deneme.DAL
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
        public bool? IsAvailable { get; set; } = true;
        //[ForeignKey ("AuthorId")]
        public int? AuthorId { get; set; }
        public Authors Author { get; set; }

    }
}
