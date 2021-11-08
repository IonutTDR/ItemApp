using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        Item GetItem(int id);
        IEnumerable<Item> GetItems();
        bool ItemExists(int id);
    }
}
