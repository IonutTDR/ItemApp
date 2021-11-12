using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        Item GetItem(int id);
        IEnumerable<Item> GetItems();
        void DeleteItem(int id);
        bool ItemExists(int id);
        void UpdateItem(int id, Item item);
        void AddComment(int itemId, Entities.Comment comment);
        IEnumerable<Entities.Comment> GetCommentsForItem(int itemId);
        Entities.Comment GetCommentForItem(int itemId, int id);
        void UpdateComment(int itemid, int id, Entities.Comment comment);
        void DeleteComment(int id);
        bool CommentExists(int id);

    }
}
