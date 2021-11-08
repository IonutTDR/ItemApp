using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ItemContextFactory : IDesignTimeDbContextFactory<ItemContext>
    {

        public ItemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItemContext>();
            var connectionString = @"Server=DESKTOP-OSPL9NT;Database=ItemsDB;Trusted_Connection=True;";
            optionsBuilder = optionsBuilder.UseSqlServer(
                connectionString,
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            return new ItemContext(optionsBuilder.Options);
        }
    }
}
