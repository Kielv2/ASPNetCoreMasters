using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ItemRepository : IItemRepository 
    {
        public IQueryable<Item> All()
        {
            var dataContext = new DataContext();

            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Item item)
        {   
            throw new NotImplementedException();
        }
    }
}
