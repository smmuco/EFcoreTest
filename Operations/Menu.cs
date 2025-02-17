using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_Deneme.DAL;

namespace EFCore_Deneme.Operations
{
    public class Menu
    {
        public async void Choices(string A)
        {

            BooksOperations booksOperations = new BooksOperations();
            FilteringMenu filteringMenu = new FilteringMenu();
            string name;
            string nameTwo;
            int pubYear;
            string genre;
            string author;

            switch (A)
            {
                case "1":
                    Console.Write("Enter the book name:");
                    name = Console.ReadLine();
                    Console.Write("Enter the Publication year:");
                    pubYear=int.Parse(Console.ReadLine());
                    Console.Write("Enter the genre of book:");
                    genre=Console.ReadLine();
                    Console.Write("Enter the name of Author:");
                    author=Console.ReadLine();
                    await booksOperations.CreatingBooksAsync(name, pubYear, genre, author);
                    Console.WriteLine("book added successfully.");
                    break;
                case "2":
                    Console.Write("Enter the name of the book you want to change");
                    nameTwo=Console.ReadLine();
                    Console.Write("Enter the new book name:");
                    name = Console.ReadLine();
                    Console.Write("Enter the Publication year:");
                    pubYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the genre of book:");
                    genre= Console.ReadLine();
                    await booksOperations.UpdatingBooksAsync(name,nameTwo, pubYear, genre);
                    Console.WriteLine("The book has been updated successfully.");
                    break;
                case "3":
                    Console.Write("Enter the name of the book you want to delete:");
                    name = Console.ReadLine();
                    await booksOperations.DeletingBooksAsync(name);
                    Console.WriteLine("The book was deleted successfully.");
                    break;
                case "4":
                    Console.WriteLine("List of all books:\n");
                    await booksOperations.ListofBooksAsync();
                    break;
                case "5":
                    Console.Write("the name of the author you want to search:");
                    author = Console.ReadLine();
                    await booksOperations.ListofAuthorsBooksAsync(author);
                    break;
                case "6":
                    await filteringMenu.DisplayFilterinMenuAsync();
                    break;
                case "7":
                    Console.WriteLine("Exited");
                    break;
                default:
                    Console.WriteLine("You entered the wrong number.");
                    break;
            }

        }
        public void ShowMenu()
        {
            Console.WriteLine("\n Book Management System ");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Update a Book");
            Console.WriteLine("3. Delete a Book");
            Console.WriteLine("4. List All Books");
            Console.WriteLine("5. List Books by Author");
            Console.WriteLine("6. Filter Books");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}
