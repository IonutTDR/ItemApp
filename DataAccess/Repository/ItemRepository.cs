using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class ItemRepository : IItemRepository
    {
        private ItemContext _ctx;
        public ItemRepository(ItemContext ctx)
        {
            _ctx = ctx;
        }

        public void AddComment(int itemId, Comment comment)
        {
            _ctx.Items.Where(i => i.Id == itemId).FirstOrDefault().Comments.Add(comment);
            _ctx.SaveChanges();
        }

        public void AddItem(Item item)
        {
            _ctx.Items.Add(item);
            _ctx.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _ctx.Comments.Find(id);
            _ctx.Comments.Remove(comment);
            _ctx.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _ctx.Items.Find(id);
            _ctx.Items.Remove(item);
            _ctx.SaveChanges();
        }

        public Comment GetCommentForItem(int itemId, int id)
        {
            return _ctx.Comments.Where(c => c.ItemId == itemId && c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Comment> GetCommentsForItem(int itemId)
        {
            return _ctx.Comments.Where(c => c.ItemId == itemId).ToList();
        }

        public Item GetItem(int id)
        {
            return _ctx.Items.Where(i => i.Id == id).FirstOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return _ctx.Items.Include(i => i.Comments).ToList();
        }

        public bool ItemExists(int id)
        {
            return _ctx.Items.Any(i => i.Id == id);
        }

        public void UpdateComment(int itemid, Comment comment)
        {
            var commentToUpdate = GetCommentForItem(itemid, comment.Id);

            commentToUpdate.Text = comment.Text;
            

            _ctx.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            var itemToUpdate = GetItem(item.Id);

            itemToUpdate.Title = item.Title;
            itemToUpdate.Description = item.Description;
            itemToUpdate.State = item.State;


            _ctx.SaveChanges();

        }
        public bool CommentExists(int id)
        {
            return _ctx.Comments.Any(c => c.Id == id);
        }
    }
}
