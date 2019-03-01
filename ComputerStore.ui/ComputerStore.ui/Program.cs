using Microsoft.EntityFrameworkCore;
using System;
using CSC = ComputerStore.Context;

namespace ComputerStore.ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CSC.Project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;

            var dbContext = new CSC.Project0Context(options);
        }
    }
}
