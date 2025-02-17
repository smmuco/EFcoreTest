using EFCore_Deneme;
using EFCore_Deneme.DAL;
using EFCore_Deneme.Operations;
using Microsoft.Extensions.Configuration;



DbContextInitializer.Build();
using (var context = new AppDbContext())
{
    Menu menu =new Menu();
    BooksOperations booksOperations = new BooksOperations();
    bool running=true;
    do
    {
        menu.ShowMenu();
        string choice = Console.ReadLine();
        menu.Choices(choice);
        if (choice == "6")
        {
            running = false;
        }
        Console.WriteLine("\nProcess in progress.\n");
        Thread.Sleep(500);
    }
    while (running);
}