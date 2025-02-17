using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_Deneme.DAL;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Deneme.Operations
{
    public class BooksOperations
    {
        public AppDbContext context;
        public BooksOperations()
        {
            context = new AppDbContext();
        }
        public BooksOperations(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CreatingBooksAsync(string title, int publicationYear, string genre, string author)
        {
            var authors=context.Authors.FirstOrDefault(x=>x.Name == author);
            if (authors == null)
            {
                var newAuthors = new Authors() { Name = author };
                await context.Authors.AddAsync(newAuthors);
                await context.Books.AddAsync(new() { Title = title, PublicationYear = publicationYear, Genre = genre, Author=newAuthors});
                await context.SaveChangesAsync();
            }
            else if (authors!=null)
            {
                await context.Books.AddAsync(new() { Title = title, PublicationYear = publicationYear, Genre = genre, Author=authors});
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdatingBooksAsync(string title,string titleTwo, int publicationYear, string genre)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Title == title);
            if (book == null)
            {
                Console.WriteLine("There is no such book.");
            }
            else if (book != null)
            {
                book.Title = titleTwo;
                book.PublicationYear = publicationYear;
                book.Genre = genre;
                await context.SaveChangesAsync();
            }

        }
        public async Task DeletingBooksAsync(string name)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Title == name);
            if (book == null)
            {
                Console.WriteLine("There is no such book.");
            }
            else if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }
        public async Task ListofBooksAsync()
        {
            var book = await context.Books.Include(b=>b.Author).Where(b=>b.IsAvailable==true).ToListAsync();
            //var book= await context
            //    .Books.Include(b=>b.Author).ToListAsync();
            foreach (var b in book)
            {
                Console.WriteLine($"Title:{b.Title}, Publication year:{b.PublicationYear}, Genre:{b.Genre}, Author:{b.Author.Name}");
            }
        }
        public async Task ListofAuthorsBooksAsync(string name)
        {
            var author = await context.Authors
                .Include(a=>a.Books)
                .FirstOrDefaultAsync(x => x.Name == name);
            if (author == null)
            {
                Console.WriteLine("There is no such author");
            }
            else if (author != null)
            {
                foreach (var a in author.Books)
                {
                    Console.WriteLine($"{a.Title}, {a.PublicationYear}, {a.Genre}.\n");
                }
            }
        }
    }
}
