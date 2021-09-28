using DomainModels;
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

        public ItemService( IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;

        }
        public IEnumerable<ItemDTO> GetAll()
        {
            var items = _itemRepository.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { Id = s.Id, Text = s.Text });
            return response;
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            var items = _itemRepository.All();
            IEnumerable<ItemDTO> response = items.Where(x => x.Text == filters.Text).Select(s => new ItemDTO() { Id = s.Id, Text = s.Text });
            return response;
        }

        public ItemDTO Get(int itemId)
        {

            var items = _itemRepository.All();
            return items.Select(s => new ItemDTO() { Id = s.Id, Text = s.Text }).Where(x => x.Id == itemId).FirstOrDefault();

        }

        public void Add(ItemDTO itemDTO)
        {
            Item item = new Item();
            item.Text = itemDTO.Text;
            item.Id = itemDTO.Id;
            _itemRepository.Save(item);

        }

        public void Update(ItemDTO itemDTO)
        {
            Item item = new Item();
            item.Text = itemDTO.Text;
            item.Id = itemDTO.Id;
            _itemRepository.Save(item);
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);

        }
        public IEnumerable<int> GetAll(int userId)
        {
            var arr = new int[] {1, 2, 3 };
            return arr;
        }

        public void Save(ItemDTO itemDTO)
        {
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
