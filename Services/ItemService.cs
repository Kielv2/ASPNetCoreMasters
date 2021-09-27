using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
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
    }
}
