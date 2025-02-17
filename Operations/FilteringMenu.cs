using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Deneme.Operations
{
    public class FilteringMenu
    {
        Filtering filtering = new Filtering();
        public async Task DisplayFilterinMenuAsync()
        {
            string name;
            int? pubYear=null;
            string genre;
            string author;
            string pubYearInput;
            Console.WriteLine("Enter the fields you want to filter, you can leave the others blank.");
            Console.WriteLine("Name:");
            name=Console.ReadLine();
            Console.WriteLine("Publication Year:");
            pubYearInput = (Console.ReadLine());
            if (string.IsNullOrEmpty(pubYearInput))
            {
                pubYear = (int?)null;
            }
            Console.WriteLine("Genre:");
            genre=Console.ReadLine();
            Console.WriteLine("Author:");
            author=Console.ReadLine();
            await filtering.FilteringMethodAsync(name, pubYear, genre, author);
        }

    }
}
