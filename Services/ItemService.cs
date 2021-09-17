using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll(int userId)
        {
            var arr = new string[] {"Book", "Pencil", "Pen" };
            return arr;
        }

    }
}
