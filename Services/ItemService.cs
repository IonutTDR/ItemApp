using AutoMapper;
using DataAccess.Repository;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;
        private IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
        }
        public Models.Item AddItem(ItemToCreate item)
        {
            var itemToAdd = _mapper.Map<DataAccess.Entities.Item>(item);
            _itemRepository.AddItem(itemToAdd);
            return _mapper.Map<Models.Item>(itemToAdd);
        }

        public Item GetItem(int id)
        {
            if (!_itemRepository.ItemExists(id))
                throw new Exception($"The item with id {id} does not exist!");
            return _mapper.Map<Models.Item>(_itemRepository.GetItem(id));
        }

        public IEnumerable<Item> GetItems()
        {
            return _mapper.Map<IEnumerable<Models.Item>>(_itemRepository.GetItems());
        }

        public void UpdateItem(Item item)
        {
            if (!_itemRepository.ItemExists(item.Id))
                throw new Exception($"The item with id {item.Id} does not exist!");
            var itemToUpdate = _mapper.Map<DataAccess.Entities.Item>(item);

            _itemRepository.UpdateItem(itemToUpdate);
        }

        public void DeleteItem(int id)
        {
            if (!_itemRepository.ItemExists(id))
                throw new Exception($"The item with id {id} does not exist!");

            _itemRepository.DeleteItem(id);
        }

        public Models.Comment AddComment(int itemId, CommentToCreate comment)
        {
            if(!_itemRepository.ItemExists(itemId))
                throw new Exception($"The item with id {itemId} does not exist!");

            var commentToAdd = _mapper.Map<DataAccess.Entities.Comment>(comment);

            _itemRepository.AddComment(itemId, commentToAdd);

            return _mapper.Map<Models.Comment>(commentToAdd);
        }

        public IEnumerable<Comment> GetCommentsForItem(int itemId)
        {
            if (!_itemRepository.ItemExists(itemId))
                throw new Exception($"The item with id {itemId} does not exist!");
            return _mapper.Map<IEnumerable<Models.Comment>>(_itemRepository.GetCommentsForItem(itemId));
        }

        public Comment GetCommentForItem(int itemId, int id)
        {
            if (!_itemRepository.ItemExists(itemId))
                throw new Exception($"The item with id {itemId} does not exist!");
            if (!_itemRepository.CommentExists(id))
                throw new Exception($"The comment with id {id} does not exist!");
            return _mapper.Map<Models.Comment>(_itemRepository.GetCommentForItem(itemId, id));
        }

        public void UpdateComment(int itemId, CommentToUpdate comment)
        {
            if (!_itemRepository.ItemExists(itemId))
                throw new Exception($"The item with id {itemId} does not exist!");
            if (!_itemRepository.CommentExists(comment.Id))
                throw new Exception($"The comment with id {comment.Id} does not exist!");
            var commentToUpdate = _mapper.Map<DataAccess.Entities.Comment>(comment);
            _itemRepository.UpdateComment(itemId, commentToUpdate);
        }

        public void DeleteComment(int itemId, int id)
        {
            if (!_itemRepository.ItemExists(itemId))
                throw new Exception($"The item with id {itemId} does not exist!");
            if (!_itemRepository.CommentExists(id))
                throw new Exception($"The comment with id {id} does not exist!");

            _itemRepository.DeleteComment(id);
        }
    }
}
