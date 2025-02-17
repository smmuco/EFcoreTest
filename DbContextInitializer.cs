using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using EFCore_Deneme.DAL;

namespace EFCore_Deneme
{
    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration;
        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
