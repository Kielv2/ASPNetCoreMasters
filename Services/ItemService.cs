using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService:IItemService
    {
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

        public IEnumerable<ItemDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public ItemDTO Get(int ItemId)
        {
            throw new NotImplementedException();
        }

        public void Add(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public void Add(int id)
        {
            throw new NotImplementedException();
        }
    }
}
