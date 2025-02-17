using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_Deneme.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Deneme.Operations
{
    public class Filtering
    {
        public AppDbContext context;
        public Filtering()
        {
            context=new AppDbContext();
        }
        public async Task FilteringMethodAsync(string? title, int? publicationYear, string? genre,string? authorName )
        {
            IQueryable<Books> query = context.Books.Include(b => b.Author);
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title == title);
            }
            if (publicationYear.HasValue)
            {
                query= query.Where(b=>b.PublicationYear == publicationYear);
            }
            if (!string.IsNullOrEmpty(genre))
            {
                query= query.Where(query=>query.Genre == genre);
            }
            if (!string.IsNullOrEmpty(authorName)) 
            {
                query= query.Where(b=>b.Author.Name == authorName);
            }
            query=query.Where(b=>b.IsAvailable == true);
            var filteredBooks=await query.ToListAsync();
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"Title:{book.Title}, Publication Year:{book.PublicationYear}, Genre:{book.Genre}, Author Name:{book.Author.Name}");
            }
        }
    }

}
