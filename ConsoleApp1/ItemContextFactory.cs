﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataContext
{
    public class ItemContextFactory : IDesignTimeDbContextFactory<ItemContext>
    {
        public ItemContext CreateDbContext(string[] args)
        {
            AppConfiguration app = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<ItemContext>();

            optionsBuilder.UseSqlServer(app.SqlConnectionString);

            return new ItemContext(optionsBuilder.Options);
        }
    }
}
