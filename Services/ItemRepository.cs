using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _ctx;

        public ItemRepository(ItemContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public void AddItem(Item item)
        {
            _ctx.Items.Add(item);
            _ctx.SaveChanges();
        }

        public Item GetItem(int id)
        {
            if (!ItemExists(id))
                throw new Exception($"The item with this {id} does not exist!");
            return _ctx.Items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _ctx.Items.Include(c => c.Comments).ToList();
        }

        public bool ItemExists(int id)
        {
            return _ctx.Items.Any(i => i.Id == id);
        }
    }
}
