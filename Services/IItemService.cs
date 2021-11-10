using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IItemService
    {
        Models.Item AddItem(Models.ItemToCreate item);
        Models.Item GetItem(int id);
        IEnumerable<Models.Item> GetItems();
        void UpdateItem(Models.Item item);
        void DeleteItem(int id);
        Models.Comment AddComment(int itemId, Models.CommentToCreate comment);
        IEnumerable<Models.Comment> GetCommentsForItem(int itemId);
        Models.Comment GetCommentForItem(int itemId, int id);
        void UpdateComment(int itemId, Models.CommentToUpdate comment);
        void DeleteComment(int itemId, int id);
    }
}
