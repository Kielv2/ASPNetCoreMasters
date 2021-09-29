using DomainModels;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class DataContext
    {
        public List<Item> Items = new List<Item>() { new Item() { Id = 1, Text = "test1" },
                                                     new Item() { Id = 2, Text = "test2" },
                                                     new Item() { Id = 3, Text = "test3" },
                                                   };
    }
}
