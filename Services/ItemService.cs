using DomainModels;
using Microsoft.Extensions.Logging;
using Repositories;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ItemService:IItemService
    {
        private readonly List<int> numbers = new List<int> { 1, 2, 3 };
        public readonly IItemRepository _itemRepository;
        private readonly ILogger<ItemService> _logger;

        public ItemService( IItemRepository itemRepository, ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;

        }
        public IEnumerable<ItemDTO> GetAll()
        {
            _logger.LogInformation("Getting all Items - {RequestTime}", DateTime.Now);
            var items = _itemRepository.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { Id = s.Id, Text = s.Text });
            return response;
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            _logger.LogInformation("Getting Items with Filter - {RequestTime}", DateTime.Now);
            var items = _itemRepository.All();
            IEnumerable<ItemDTO> response = items.Where(x => x.Text == filters.Text).Select(s => new ItemDTO() { Id = s.Id, Text = s.Text });
            return response;
        }

        public ItemDTO Get(int itemId)
        {
            _logger.LogInformation("Getting Items by Id. ItemId = {ItemId}. {RequestTime}", itemId.ToString(), DateTime.Now);
            var items = _itemRepository.All();
            return items.Select(s => new ItemDTO() { Id = s.Id, Text = s.Text }).Where(x => x.Id == itemId).FirstOrDefault();

        }

        public void Add(ItemDTO itemDTO)
        {
            _logger.LogInformation("Adding Item. {RequestTime}", DateTime.Now);
            Item item = new Item();
            item.Text = itemDTO.Text;
            item.Id = itemDTO.Id;
            _itemRepository.Save(item);

        }

        public void Update(ItemDTO itemDTO)
        {
            _logger.LogInformation("Updating Item. {RequestTime}", DateTime.Now);
            Item item = new Item();
            item.Text = itemDTO.Text;
            item.Id = itemDTO.Id;
            _itemRepository.Save(item);
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Deleting Item. {RequestTime}", DateTime.Now);
            _itemRepository.Delete(id);

        }
        public IEnumerable<int> GetAll(int userId)
        {
            _logger.LogInformation("Getting all Items - {RequestTime}", DateTime.Now);
            var arr = new int[] {1, 2, 3 };
            return arr;
        }

        public void Save(ItemDTO itemDTO)
        {
            _logger.LogInformation("Saving item - {RequestTime}", DateTime.Now);
            var item = new Item();
            item.Text = itemDTO.Text;

            Console.WriteLine("Saved");
        }

        public string GetItem(int Id)
        {

            return Id.ToString();
        }

        //public IEnumerable<ItemDTO> GetAll()
        //{
        //    var items = new List<ItemDTO>();

        //    items.Add(new ItemDTO { Id = 1, Text = "test1" });
        //    items.Add(new ItemDTO { Id = 2, Text = "test2" });

        //    IEnumerable <ItemDTO> result = items;

        //    return result;
        //}

    }
}
