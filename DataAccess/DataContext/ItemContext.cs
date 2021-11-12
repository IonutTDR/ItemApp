using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataContext
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options ) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
