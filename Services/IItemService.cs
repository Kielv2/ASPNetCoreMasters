using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IItemService
    {
        public IEnumerable<ItemDTO> GetAll();
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);
        public ItemDTO Get(int ItemId);
        public void Add(ItemDTO itemDTO);
        public void Update(ItemDTO itemDTO);
        public void Delete(int id);
    }
}
