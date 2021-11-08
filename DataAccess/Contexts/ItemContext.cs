using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
