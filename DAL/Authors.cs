using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Deneme.DAL
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Books> Books { get; set; }= new List<Books>();
    }
}
